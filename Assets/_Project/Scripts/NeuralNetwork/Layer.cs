/**
 * $File: Layer.cs $
 * $Date: 2022-09-17 20:50:41 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;

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

}
