/**
 * $File: NeuralNetwork.cs $
 * $Date: 2022-09-17 20:52:38 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Neural network that holds all layers.
/// </summary>
public class NeuralNetwork : MonoBehaviour
{
    /* Variables */

    private static readonly System.Random Random = new System.Random();

    [Header("** Initialize Variables (NeuralNetwork) **")]

    [Tooltip("Data type to store neural network.")]
    [SerializeField]
    private NeuralNetworkData mData = null;

    [Tooltip("Initialize this neural network from a file.")]
    [SerializeField]
    private bool mInitFromPath = false;

    [Tooltip("File to save and load.")]
    [SerializeField]
    private string mSaveLoadPath = "";

    /* Setter & Getter */

    public NeuralNetworkData Data { get { return this.mData; } }

    /* Functions */

    private void Awake()
    {
        mSaveLoadPath = Path.Combine(Application.persistentDataPath, mSaveLoadPath);

        if (mInitFromPath)
            Load();
        else
            mData.Init();
    }


    public Layer Train(List<float> inputs)
    {
        return this.Data.outputLayer;
    }

    /// <summary>
    /// Generate random value for bias and weight.
    /// </summary>
    public static double GetRandom()
    {
        // TODO(jenchieh): use Unity built-in random generator?
        return 2 * Random.NextDouble() - 1;
    }

    /// <summary>
    /// Save the neural network to a file specified by PATH.
    /// </summary>
    public void Save()
    {
        Save(mSaveLoadPath);
    }
    public void Save(string path)
    {
        mData.Save<NeuralNetworkData>(path);
    }

    /// <summary>
    /// Load the neural network from a file specified by PATH.
    /// </summary>
    public void Load()
    {
        Load(mSaveLoadPath);
    }
    public void Load(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("Failed to load neural network data from, " + path);
            return;
        }

        mData = NeuralNetworkData.LoadFromFile<NeuralNetworkData>(path);
    }
}
