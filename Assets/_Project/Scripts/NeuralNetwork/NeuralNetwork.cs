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

    public Layer inputLayer = new Layer();
    public List<Layer> hiddenLayers = null;
    public Layer outputLayer = new Layer();

    /* Setter & Getter */

    /* Functions */

    public NeuralNetwork(int inputs, List<int> hiddens, int outputs)
    {
        this.inputLayer.neurons = new List<Neuron>(inputs);
        this.hiddenLayers = new List<Layer>(hiddens.Count);
        /* Initialize all neurons in hidden layers */
        {
            int index = 0;
            foreach (var hiddenLayer in this.hiddenLayers)
            {
                hiddenLayer.neurons = new List<Neuron>(hiddens[index]);
            }
        }
        this.outputLayer.neurons = new List<Neuron>(outputs);
    }

    public Layer Process()
    {
        return outputLayer;
    }
}
