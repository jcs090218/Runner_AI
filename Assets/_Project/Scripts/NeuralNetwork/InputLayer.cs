/**
 * $File: InputLayer.cs $
 * $Date: 2022-09-17 20:47:42 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
[Serializable]
public class InputLayer : Layer
{
    /* Variables */

    /* Setter & Getter */

    /* Functions */

    public InputLayer(List<float> inputs)
    {
        foreach (var input in inputs)
        {
            var neuron = new Neuron();
            neuron.weight = input;

            this.neurons.Add(neuron);
        }
    }

    public void UpdateInputs(List<float> inputs)
    {
        int index = 0;
        foreach (var neuron in neurons)
        {
            neuron.weight = inputs[index];
            ++index;
        }
    }
}
