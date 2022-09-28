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

    [Tooltip("Number of neurons in one hidden layer.")]
    [Range(1, 30)]
    public int hiddenSize = 4;  // TODO: should we turn this into a list?

    [Tooltip("Number of outputs.")]
    [Range(1, 30)]
    public int outputSize = 1;

    [Tooltip("Number of the hidden layers.")]
    [Range(1, 30)]
    public int numHiddenLayers = 1;

    [Header("** Runtime Variables (NeuralNetwork) **")]

    [Tooltip("")]
    public double learnRate = 0.4f;

    [Tooltip("")]
    public double momentum = 0.9f;

    [Header("- Random Initialization")]

    [Tooltip("Minimum number for randomization.")]
    public float min = -1.0f;

    [Tooltip("Maximum number for randomization.")]
    public float max = 1.0f;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        inputLayer = new InputLayer(inputSize);
        InitHiddenLayers();
        // Assign with the previous hidden layer.
        outputLayer = new OutputLayer(outputSize, hiddenLayers[numHiddenLayers - 1]);
    }

    private void InitHiddenLayers()
    {
        for (int index = 0; index < numHiddenLayers; ++index)
        {
            // Find the previous layer on the left
            Layer prevLayer = (index == 0) ? inputLayer : hiddenLayers[index - 1];
            hiddenLayers.Add(new HiddenLayer(hiddenSize, prevLayer));
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
