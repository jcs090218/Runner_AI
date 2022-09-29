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

/// <summary>
/// Neural Network data.
/// </summary>
[System.Serializable]
public class NeuralNetworkData
{
    /* Variables */

    public InputLayer inputLayer = null;

    public List<HiddenLayer> hiddenLayers = null;

    public OutputLayer outputLayer = null;

    /* Setter & Getter */

    /* Functions */

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
