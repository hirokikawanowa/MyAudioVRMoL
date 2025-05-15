using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collectible.cs
// Author: Brigham Moll
// Created: 03/08/2020

/// <summary>
/// Represents a single collectible to be collected by a user during the exploration phase.
/// </summary>
public class Collectible : MonoBehaviour
{
    /// <summary>
    /// The ExperimentManager.
    /// </summary>
    ExperimentManagerScript experimentManager = null;

    void Start()
    {
        // Set a reference to the experiment manager.
        experimentManager = FindObjectOfType<ExperimentManagerScript>();
    }

    /// <summary>
    /// When touching a collectible, destroy it.
    /// </summary>
    /// <param name="other"> Collision information. </param>
    private void OnTriggerEnter(Collider other)
    {
        experimentManager.DestroyCollectible(gameObject);
    }
}
