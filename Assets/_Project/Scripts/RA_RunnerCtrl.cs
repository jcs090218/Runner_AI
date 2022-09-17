/**
 * $File: RA_RunnerCtrl.cs $
 * $Date: 2022-09-03 01:10:51 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RA_RunnerCtrl : MonoBehaviour
{
    /* Variables */

    private Collider mCollider = null;

    private RA_CharAnimCtrl mCharAnimCtrl = null;

    private CharacterController mCharacterController = null;

    [Header("** Check Variables (RA_RunnerCtrl) **")]

    [SerializeField]
    private float mMovement = 0.0f;

    [SerializeField]
    private bool mDead = false;

    [Header("** Runtime Variables (RA_RunnerCtrl) **")]

    [SerializeField]
    private NeuralNetwork mNeuralNetwork = null;

    [SerializeField]
    private bool mRandomIt = false;

    [Range(0.0f, 30.0f)]
    [SerializeField]
    private float mMoveSpeed = 10.0f;

    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float mRotateSpeed = 2.5f;

    [Range(0.0f, 30.0f)]
    [SerializeField]
    private float mRayLength = 10.0f;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        this.mCharacterController = this.GetComponent<CharacterController>();

        this.mCollider = this.GetComponent<Collider>();

        this.mCharAnimCtrl = this.GetComponentInChildren<RA_CharAnimCtrl>();

        if (mRandomIt)
            mNeuralNetwork.Randomize();
    }

    private void Update()
    {
        Think();

        Move();

        HandleAnimator();
    }

    private void Move()
    {
        // Rotate the charater based on Horizonal Input & later NN Output
        transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * mMovement * mRotateSpeed);

        mCharacterController.Move(transform.forward * Time.deltaTime * mMoveSpeed);
    }

    private void Think()
    {
        // Set up a raycast hit for knowing what we hit
        RaycastHit hit;

        // Set up out 5 feelers for undertanding the world
        Vector3[] feelers = new Vector3[]
        {
            // 0 = L
            transform.TransformDirection(Vector3.left),
            // 1 - FL
            transform.TransformDirection(Vector3.left+Vector3.forward),
            // 2 - F
            transform.TransformDirection(Vector3.forward),
            // 3 = FR
            transform.TransformDirection(Vector3.right + Vector3.forward),
            // 4 = R
            transform.TransformDirection(Vector3.right),
        };

        int index = 0;
        var inputs = new List<float>(mNeuralNetwork.inputLayer.neurons.Count);

        foreach (var feeler in feelers)
        {
            // See what all feelers feel
            if (Physics.Raycast(transform.position, feeler, out hit))
            {
                // If feelers feel something other than Forrest & nothing
                if (hit.collider != null && hit.collider != mCollider)
                {
                    // Set the input[i] to be the distance of feeler[i]
                    inputs[index] = hit.distance;
                }
            }

            Debug.DrawRay(transform.position, feeler * mRayLength, Color.red);
            ++index;
        }

        var outputLayer = mNeuralNetwork.Process(inputs);

        mMovement = mDead ? 0 : outputLayer.neurons[0].weight;
    }

    private void HandleAnimator()
    {
        if (mDead)
        {
            this.mCharAnimCtrl.Die_0();
            return;
        }

        if (mMovement == 0.0f)
            this.mCharAnimCtrl.Idle();
        else
            this.mCharAnimCtrl.Run();
    }
}
