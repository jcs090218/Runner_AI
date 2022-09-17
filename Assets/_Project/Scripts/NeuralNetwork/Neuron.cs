/**
 * $File: Neuron.cs $
 * $Date: 2022-09-17 17:20:17 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System;

/// <summary>
/// Neuron node in neural network.
/// </summary>
[Serializable]
public class Neuron
{
    /* Variables */

    public ActivationType activationType = ActivationType.Identity;

    public float bias = 0.0f;

    public float weight = 0.0f;  // this is also `input` and `output`

    /* Setter & Getter */

    /* Functions */

    private float Process()
    {
        return weight + bias;
    }
}
