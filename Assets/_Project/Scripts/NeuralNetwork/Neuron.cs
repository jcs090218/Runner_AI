/**
 * $File: Neuron.cs $
 * $Date: 2022-09-17 17:20:17 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright � 2022 by Shen, Jen-Chieh $
 */
using System;
using System.Collections.Generic;

/// <summary>
/// Neuron node in neural network.
/// </summary>
[Serializable]
public class Neuron
{
    /* Variables */

    public ActivationType activationType = ActivationType.Identity;

    public float bias = 0.0f;  // this is constant

    public float weight = 0.0f;  // this is also `input` and `output`

    /* Setter & Getter */

    /* Functions */

    public float Process(Layer prevLayer)
    {
        float sum = Sum(prevLayer.neurons);

        weight = (float)ActivationFunctions.Do(activationType, sum + bias);

        return weight;
    }

    /// <summary>
    /// The summation of a[0-n] * b[0-n]
    /// </summary>
    private float Sum(List<Neuron> neurons)
    {
        float result = 0.0f;

        foreach (var neuron in neurons)
            result += neuron.weight * weight;

        return result;
    }
}
