/**
 * $File: NeuralNetwork.cs $
 * $Date: 2022-09-17 20:52:38 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Neural network that holds all layers.
/// </summary>
[System.Serializable]
public class NeuralNetwork
{
    /* Variables */

    private static readonly System.Random Random = new System.Random();

    [Header("** Runtime Variables (NeuralNetwork) **")]

    public InputLayer inputLayer = null;
    public List<HiddenLayer> hiddenLayers = null;
    public OutputLayer outputLayer = null;

    [Header("- Random Initialization")]

    [Tooltip("Minimum number for randomization.")]
    public float min = -1.0f;

    [Tooltip("Maximum number for randomization.")]
    public float max = 1.0f;

    /* Setter & Getter */

    /* Functions */

    public Layer Train(List<float> inputs)
    {
        return this.outputLayer;
    }

    /// <summary>
    /// Generate random value for bias and weight.
    /// </summary>
    public static double GetRandom()
    {
        return 2 * Random.NextDouble() - 1;
    }
}
