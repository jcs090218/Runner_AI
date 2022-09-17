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
/// 
/// </summary>
public class NeuralNetwork
{
    /* Variables */

    public InputLayer inputLayer = new InputLayer();
    public List<HiddenLayer> hiddenLayers = null;
    public OutputLayer outputLayer = new OutputLayer();

    /* Setter & Getter */

    /* Functions */

    public NeuralNetwork(int hiddenLayers)
    {
        this.hiddenLayers = new List<HiddenLayer>(hiddenLayers);
    }
}
