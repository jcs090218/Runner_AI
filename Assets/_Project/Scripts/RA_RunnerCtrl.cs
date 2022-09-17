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

[RequireComponent(typeof(CharacterController))]
public class RA_RunnerCtrl : MonoBehaviour
{
    /* Variables */

    private Collider mCollider = null;

    private CharacterController mCharacterController = null;

    [Header("** Check Variables (RA_RunnerCtrl) **")]

    [SerializeField]
    private NeuralNetwork mNeuralNetwork = null;

    [SerializeField]
    private float mMovement = 0.0f;

    [Header("** Runtime Variables (RA_RunnerCtrl) **")]

    [Tooltip("Inputs, the initial DNA.")]
    [SerializeField]
    private List<float> mInputs = null;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        this.mCharacterController = this.GetComponent<CharacterController>();

        this.mCollider = this.GetComponent<Collider>();

        var hiddens = new List<int>() { 5 };  // 1 layer, 5 neurons

        mNeuralNetwork.Init(mInputs, hiddens, 1);
    }

    private void Update()
    {
        //Think();

        //Move();
    }

    private void Move()
    {
        // Rotate the charater based on Horizonal Input & later NN Output
        transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * mMovement * 2.5f);
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

            Debug.DrawRay(transform.position, feeler * 10, Color.red);
            ++index;
        }

        var outputLayer = mNeuralNetwork.Process(mInputs);

        var appm = RA_AppManager.instance;
        mMovement = appm.ended ? 0 : outputLayer.neurons[0].weight;
    }
}
