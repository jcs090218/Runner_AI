/**
 * $File: Layer.cs $
 * $Date: 2022-09-17 20:50:41 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all neural network layers.
/// </summary>
[System.Serializable]
public abstract class Layer
{
    /* Variables */

    public List<Neuron> neurons = new List<Neuron>();

    /* Setter & Getter */

    /* Functions */

    public void Randomize(float min, float max)
    {
        foreach (var neuron in neurons)
        {
            neuron.bias = Random.Range(min, max);
            neuron.weight = Random.Range(min, max);
        }
    }
}
