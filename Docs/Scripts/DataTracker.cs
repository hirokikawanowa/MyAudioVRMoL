using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Tracks participant experiment data and can save the data to a file.
/// </summary>
public class DataTracker : MonoBehaviour
{
    /// <summary>
    /// The name of the file to be saved with the tracked data.
    /// </summary>
    private const string FILE_NAME = "PARTICIPANT_TEST_DATA.txt";

    /// <summary>
    /// Contains all the text to be saved to a file when the experiment is finished.
    /// </summary>
    private List<string> dataToBeSaved = new List<string>();

    /// <summary>
    /// Saves the tracked data to a file.
    /// </summary>
    public void SaveTrackedData()
    {
        string filePath = Application.dataPath + FILE_NAME;

        File.WriteAllLines(filePath, dataToBeSaved);
    }

    /// <summary>
    /// Adds the given string as a new line to the tracked data.
    /// </summary>
    /// <param name="newLine"> A new line of tracked data to be saved. </param>
    public void AddNewTrackedDataLine(string newLine)
    {
        dataToBeSaved.Add(newLine);
    }
}
