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

/// <summary>
/// Neural network that holds all layers.
/// </summary>
[Serializable]
public class NeuralNetwork
{
    /* Variables */

    public InputLayer inputLayer = null;
    public List<HiddenLayer> hiddenLayers = new List<HiddenLayer>();
    public OutputLayer outputLayer = null;

    /* Setter & Getter */

    /* Functions */

    public void Init(List<float> inputs, List<int> hiddens, int outputs)
    {
        inputLayer = new InputLayer(inputs);

        for (int count = 0; count < hiddens.Count; ++count)
        {
            var hiddenLayer = new HiddenLayer(hiddens[count]);
            this.hiddenLayers.Add(hiddenLayer);
        }

        outputLayer = new OutputLayer(outputs);
    }

    public Layer Process(List<float> inputs)
    {
        return this.outputLayer;
    }
}
