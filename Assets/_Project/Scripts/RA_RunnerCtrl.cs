/**
 * $File: RA_RunnerCtrl.cs $
 * $Date: 2022-09-03 01:10:51 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using UnityEngine;
using JCSUnity;

[RequireComponent(typeof(CharacterController))]
public class RA_RunnerCtrl : MonoBehaviour
{
    /* Variables */

    private Vector3 mDeadPosition = Vector3.zero;

    private Collider mCollider = null;

    private RA_CharAnimCtrl mCharAnimCtrl = null;

    private CharacterController mCharacterController = null;

    [Header("** Check Variables (RA_RunnerCtrl) **")]

    [SerializeField]
    private Vector3 mVelocity = Vector3.zero;

    [Tooltip("Movement unit vector, either turn left/right.")]
    [SerializeField]
    private float mMovement = 0.0f;

    [SerializeField]
    private bool mDead = false;

    [SerializeField]
    private List<float> mInputs = null;

    [SerializeField]
    private float mFitness = 0.0f;

    [Header("** Initialize Variables (RA_RunnerCtrl) **")]

    [SerializeField]
    private NeuralNetwork mNeuralNetwork = null;

    [Header("** Runtime Variables (RA_RunnerCtrl) **")]

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
        this.mCharAnimCtrl.AnimEvents.SetRunner(this);

        //if (mRandomIt)
        //    mNeuralNetwork.Randomize();

        // Set up inputs
        mInputs.Clear();

        List<Neuron> neurons = mNeuralNetwork.inputLayer.neurons;

        for (int index = 0; index < neurons.Count; ++index)
        {
            //mInputs.Add(neurons[index].weight);
        }
    }

    private void Update()
    {
        if (mCharacterController.isGrounded && JCS_Mathf.IsNegative(mVelocity.y))
        {
            mVelocity.y = -0.001f;
            mVelocity.z = mMoveSpeed;  // always move forward
        }
        else
        {
            mVelocity.z = 0.0f;
        }

        Think();

        Move();

        HandleAnimator();
    }

    public void Kill()
    {
        if (mDeadPosition == this.transform.position)
            return;

        this.mDead = true;
        this.mCharacterController.enabled = false;
        this.mDeadPosition = this.transform.position;

        // TODO: ..
    }

    public void CallRevive()
    {
        var appm = RA_AppManager.instance;

        if (!appm.autoRevive)
            return;

        Revive();
    }

    public void Revive()
    {
        if (!mDead)
            return;

        var appm = RA_AppManager.instance;

        ++appm.generation;

        this.mDead = false;
        this.mCharacterController.enabled = true;
        {
            this.transform.position = appm.revivePoint.position;
            this.transform.eulerAngles = appm.revivePoint.eulerAngles;
        }
        this.mDeadPosition = appm.revivePoint.position;

        mFitness = 0.0f;
    }

    private void Move()
    {
        if (mDead)
            return;

        mVelocity.y -= (JCS_GameConstant.GRAVITY * Time.deltaTime * JCS_GameSettings.instance.GRAVITY_PRODUCT);

        Vector3 jumpMotion = Vector3.up * mVelocity.y;
        Vector3 moveMotion = transform.forward * mVelocity.z;

        Vector3 motion = jumpMotion + moveMotion;

        // Rotate the charater based on Horizonal Input & later NN Output
        transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * mMovement * mRotateSpeed);

        mCharacterController.Move(motion * Time.deltaTime);
    }

    private void Think()
    {
        if (mDead)
            return;

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

        foreach (var feeler in feelers)
        {
            // See what all feelers feel
            if (Physics.Raycast(transform.position, feeler, out hit))
            {
                // If feelers feel something other than Forrest & nothing
                if (hit.collider != null && hit.collider != mCollider)
                {
                    // Set the input[i] to be the distance of feeler[i]
                    mInputs[index] = hit.distance;
                }
            }

            Debug.DrawRay(transform.position, feeler * mRayLength, Color.red);
            ++index;
        }

        var outputLayer = mNeuralNetwork.Train(mInputs);

        //mMovement = mDead ? 0 : outputLayer.neurons[0].weight;
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
