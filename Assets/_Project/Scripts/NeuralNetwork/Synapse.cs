/**
 * $File: Synapse.cs $
 * $Date: 2022-09-19 01:50:54 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */

/// <summary>
/// Synapse live in each neuron.
/// </summary>
public class Synapse
{
    /* Variables */

    public Neuron InputNeuron { get; set; }
    public Neuron OutputNeuron { get; set; }
    public double Weight { get; set; }
    public double WeightDelta { get; set; }

    /* Setter & Getter */

    /* Functions */

    public Synapse(Neuron inputNeuron, Neuron outputNeuron)
    {
        InputNeuron = inputNeuron;
        OutputNeuron = outputNeuron;
        Weight = NeuralNetwork.GetRandom();
    }
}
