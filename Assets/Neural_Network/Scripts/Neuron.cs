/**
 * $File: Neuron.cs $
 * $Date: 2022-09-17 17:20:17 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Neuron node in neural network.
/// </summary>
[System.Serializable]
public class Neuron
{
    /* Variables */

    public ActivationType activationType = ActivationType.Identity;

    public List<Synapse> inputSynapses = null;
    public List<Synapse> outputSynapses = null;

    public double bias = 0.0f;
    public double biasDelta = 0.0f;
    public double gradient = 0.0f;
    public double value = 0.0f;

    /* Setter & Getter */

    /* Functions */

    /// <summary>
    /// For the input layer.
    /// </summary>
    public Neuron()
    {
        this.inputSynapses = new List<Synapse>();
        this.outputSynapses = new List<Synapse>();
        this.bias = NeuralNetwork.GetRandom();
    }

    /// <summary>
    /// For the rest of the layers (hidden and output).
    /// </summary>
    /// <param name="prevLayer"> Previouse layer for the input neurons. </param>
    public Neuron(Layer prevLayer) : this()
    {
        foreach (var inputNeuron in prevLayer.neurons)
        {
            // create a synapse
            var synapse = new Synapse(inputNeuron, this);
            // and connect the two neurons
            inputNeuron.outputSynapses.Add(synapse);  // connect to the left
            inputSynapses.Add(synapse);               // connect to the right
        }
    }

    /// <summary>
    /// Calculate the value while in forward propogation (predicting).
    /// </summary>
    public virtual double CalculateValue()
    {
        value = ActivationFunctions.Do(activationType, inputSynapses.Sum(a => a.weight * a.inputNeuron.value) + bias);
        return value;
    }

    public double CalculateError(double target)
    {
        return target - value;
    }
}
