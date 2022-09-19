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

    /* Setter & Getter */

    // Neuron on the left. (see graph)
    public Neuron InputNeuron { get; set; }
    // Neuron on the right. (see graph)
    public Neuron OutputNeuron { get; set; }
    // Weights control the signal (or the strength of the connection) between
    // two neurons.
    public double Weight { get; set; }
    public double WeightDelta { get; set; }

    /* Functions */

    public Synapse(Neuron inputNeuron, Neuron outputNeuron)
    {
        InputNeuron = inputNeuron;
        OutputNeuron = outputNeuron;
        Weight = NeuralNetwork.GetRandom();
    }
}
