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
public class NeuralNetwork : MonoBehaviour
{
    /* Variables */

    private static readonly System.Random Random = new System.Random();

    [Header("** Check Variables (NeuralNetwork) **")]

    public InputLayer inputLayer = null;

    public List<HiddenLayer> hiddenLayers = null;

    public OutputLayer outputLayer = null;

    [Header("** Initialize Variables (NeuralNetwork) **")]

    [Tooltip("Number of inputs.")]
    [Range(1, 30)]
    public int inputSize = 3;

    [Tooltip("Number of neurons in each hidden layer.")]
    public List<int> hiddenSizes = null;

    [Tooltip("Number of outputs.")]
    [Range(1, 30)]
    public int outputSize = 1;

    [Header("** Runtime Variables (NeuralNetwork) **")]

    [Tooltip("")]
    public double learnRate = 0.4f;

    [Tooltip("")]
    public double momentum = 0.9f;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        if (hiddenSizes.Count == 0)
        {
            Debug.LogWarning("Neural Network with hidden sizes of 0 is not allowed");
            return;
        }

        inputLayer = new InputLayer(inputSize);
        InitHiddenLayers();
        // Assign with the previous hidden layer.
        outputLayer = new OutputLayer(outputSize, hiddenLayers[hiddenSizes.Count - 1]);
    }

    private void InitHiddenLayers()
    {
        for (int index = 0; index < hiddenSizes.Count; ++index)
        {
            // Find the previous layer on the left
            Layer prevLayer = (index == 0) ? inputLayer : hiddenLayers[index - 1];
            hiddenLayers.Add(new HiddenLayer(hiddenSizes[index], prevLayer));
        }
    }

    public Layer Train(List<float> inputs)
    {
        return this.outputLayer;
    }

    /// <summary>
    /// Generate random value for bias and weight.
    /// </summary>
    public static double GetRandom()
    {
        // TODO(jenchieh): use Unity built-in random generator?
        return 2 * Random.NextDouble() - 1;
    }
}
