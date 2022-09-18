/**
 * $File: NeuralNetwork.cs $
 * $Date: 2022-09-17 20:52:38 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Neural network that holds all layers.
/// </summary>
[Serializable]
public class NeuralNetwork
{
    /* Variables */

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

    public void Randomize()
    {
        inputLayer.Randomize(min, max);
        foreach (var hiddenLayer in hiddenLayers)
        {
            hiddenLayer.Randomize(min, max);
        }
        outputLayer.Randomize(min, max);
    }

    public Layer Process(List<float> inputs)
    {
        inputLayer.UpdateInputs(inputs);

        Layer prevLayer = inputLayer;

        for (int layerIndex = 0; layerIndex < hiddenLayers.Count; ++layerIndex)
        {
            Layer layer = hiddenLayers[layerIndex];

            layer.Process(prevLayer);

            prevLayer = layer;
        }

        this.outputLayer.Process(prevLayer);

        return this.outputLayer;
    }
}
