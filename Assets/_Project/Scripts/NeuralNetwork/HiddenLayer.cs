/**
 * $File: HiddenLayer.cs $
 * $Date: 2022-09-17 20:47:11 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System;

/// <summary>
/// 
/// </summary>
[Serializable]
public class HiddenLayer : Layer
{
    /* Variables */

    /* Setter & Getter */

    /* Functions */

    public HiddenLayer(int neurons)
    {
        for (int index = 0; index < neurons; ++index)
        {
            var neuron = new Neuron();
            this.neurons.Add(neuron);
        }
    }
}
