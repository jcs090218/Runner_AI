/**
 * $File: OutputLayer.cs $
 * $Date: 2022-09-17 20:48:39 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System;

/// <summary>
/// Output layer.
/// </summary>
[Serializable]
public class OutputLayer : Layer
{
    /* Variables */

    /* Setter & Getter */

    /* Functions */

    public OutputLayer(int neurons)
    {
        for (int index = 0; index < neurons; ++index)
        {
            var neuron = new Neuron();
            this.neurons.Add(neuron);
        }
    }
}
