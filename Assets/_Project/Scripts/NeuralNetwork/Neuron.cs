/**
 * $File: Neuron.cs $
 * $Date: 2022-09-17 17:20:17 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Neuron node in neural network.
/// </summary>
[System.Serializable]
public class Neuron
{
    /* Variables */

    public ActivationType activationType = ActivationType.Identity;

    public float bias = 0.0f;  // this is constant

    public List<float> weights = new List<float>();

    /* Setter & Getter */

    /* Functions */

    public Neuron()
    {

    }

    public void Randomize(float min, float max)
    {
        bias = Random.Range(min, max);

        // TODO: init weights
    }

    /// <summary>
    /// This returns the output/prediction.
    /// </summary>
    public float Process(Layer prevLayer)
    {
        float sum = Sum(prevLayer.neurons);

        return (float)ActivationFunctions.Do(activationType, sum + bias);
    }

    /// <summary>
    /// The summation of a[0-n] * b[0-n]
    /// </summary>
    private float Sum(List<Neuron> neurons)
    {
        float result = 0.0f;

        foreach (var neuron in neurons)
            result += neuron.weights[0] * weights[0];

        return result;
    }
}
