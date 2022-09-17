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

    public InputLayer inputLayer = null;
    public List<HiddenLayer> hiddenLayers = null;
    public OutputLayer outputLayer = new OutputLayer();

    /* Setter & Getter */

    /* Functions */

    public NeuralNetwork(InputLayer inputLayer, int hiddenLayers, int output)
    {
        this.inputLayer = inputLayer;
        this.hiddenLayers = new List<HiddenLayer>(hiddenLayers);
        this.outputLayer.neurons = new List<Neuron>(output);
    }
}
