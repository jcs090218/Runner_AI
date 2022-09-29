/**
 * $File: NeuralNetworkData.cs $
 * $Date: 2022-09-29 14:53:45 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Neural Network data.
/// </summary>
[System.Serializable]
public class NeuralNetworkData
{
    /* Variables */

    [Tooltip("")]
    public InputLayer inputLayer = null;

    [Tooltip("")]
    public List<HiddenLayer> hiddenLayers = null;

    [Tooltip("")]
    public OutputLayer outputLayer = null;

    [Tooltip("Number of inputs.")]
    [Range(1, 30)]
    public int inputSize = 3;

    [Tooltip("Number of neurons in each hidden layer.")]
    public List<int> hiddenSizes = null;

    [Tooltip("Number of outputs.")]
    [Range(1, 30)]
    public int outputSize = 1;

    [Tooltip("")]
    public double learnRate = 0.4f;

    [Tooltip("")]
    public double momentum = 0.9f;

    /* Setter & Getter */

    /* Functions */

    public void Init()
    {
        if (hiddenSizes.Count == 0)
        {
            Debug.LogWarning("Neural Network with hidden sizes of 0 is not allowed");
            return;
        }

        inputLayer = new InputLayer(inputSize);
        InitHiddenLayers();
        // Assign with the previous hidden layer.
        outputLayer = new OutputLayer(outputSize, hiddenLayers[hiddenSizes.Count - 1]);
    }

    private void InitHiddenLayers()
    {
        for (int index = 0; index < hiddenSizes.Count; ++index)
        {
            // Find the previous layer on the left
            Layer prevLayer = (index == 0) ? inputLayer : hiddenLayers[index - 1];
            hiddenLayers.Add(new HiddenLayer(hiddenSizes[index], prevLayer));
        }
    }

    /// <summary>
    /// Save the game data into xml file format.
    /// </summary>
    /// <typeparam name="T"> type of the data save. </typeparam>
    /// <param name="filePath"> where to save. </param>
    /// <param name="fileName"> name of the file u want to save. </param>
    public void Save<T>(string path)
    {
        string filePath = Path.GetDirectoryName(path);

        Directory.CreateDirectory(filePath);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            var XML = new XmlSerializer(typeof(T));
            XML.Serialize(stream, this);
        }
    }

    /// <summary>
    /// Load the game data from a directory file path.
    /// </summary>
    /// <typeparam name="T"> type of the game data u want to load. </typeparam>
    /// <param name="fullFilePath"> file path to the file. </param>
    /// <returns>
    /// Full game data. If the file does not exists returns 
    /// null references.
    /// </returns>
    public static T LoadFromFile<T>(string path)
    {
        if (!File.Exists(path))
            return default(T);

        using (var stream = new FileStream(path, FileMode.Open))
        {
            var xml = new XmlSerializer(typeof(T));
            return (T)xml.Deserialize(stream);
        }
    }
}
