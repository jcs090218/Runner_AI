/**
 * $File: RA_AppManager.cs $
 * $Date: 2022-09-17 21:27:56 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;
using JCSUnity;

/// <summary>
/// 
/// </summary>
public class RA_AppManager : JCS_Manager<RA_AppManager>
{
    /* Variables */

    [Header("** Check Variables (RA_AppManager) **")]

    [SerializeField]
    private NeuralNetwork mNeuralNetwork = null;

    [Header("** Runtime Variables (RA_AppManager) **")]

    [Tooltip("Input layer")]
    [SerializeField]
    private InputLayer mInputLayer = null;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mNeuralNetwork = new NeuralNetwork(mInputLayer, 1, 1);
    }
}
