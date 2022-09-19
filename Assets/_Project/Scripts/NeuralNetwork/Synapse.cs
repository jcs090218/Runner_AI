/**
 * $File: Synapse.cs $
 * $Date: 2022-09-19 01:50:54 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */

/// <summary>
/// Synapse live in between each neuron.
/// </summary>
public class Synapse
{
    /* Variables */

    // Neuron on the left. (see graph)
    public Neuron inputNeuron = null;
    // Neuron on the right. (see graph)
    public Neuron outputNeuron = null;

    // Weights control the signal (or the strength of the connection) between
    // two neurons.
    public double weight = 0.0f;
    public double weightDelta = 0.0f;

    /* Setter & Getter */

    /* Functions */

    public Synapse(Neuron inputNeuron, Neuron outputNeuron)
    {
        this.inputNeuron = inputNeuron;
        this.outputNeuron = outputNeuron;
        this.weight = NeuralNetwork.GetRandom();
    }
}
