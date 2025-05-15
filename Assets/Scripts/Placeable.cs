using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Placeable.cs
// Author: Brigham Moll
// Date created: 24/09/2020

/// <summary>
/// A Placeable represents an item to be remembered by the participant in the memory palace simulation.
/// </summary>
public class Placeable : MonoBehaviour
{
    /// <summary>
    /// The lowest position a Placeable is allowed to be at in the Y-axis.
    /// This is to prevent it slipping through the floor somehow.
    /// </summary>
    public const float LOWEST_ALLOWED_PLACEABLE_Y_POSITION = 2.1f;

    /// <summary>
    /// Materials used to make the Placeable glow when placed.
    /// </summary>
    public Material StandardPlaceableMaterial;
    public Material GlowingPlaceableMaterial;

    /// <summary>
    /// Triggered when this Placeable has had its placement finished being confirmed.
    /// </summary>
    public delegate void PlaceableEventHandler();
    public event PlaceableEventHandler ConfirmPlacementEvent;

    /// <summary>
    /// Triggered when the Placeable is grabbed, and not activated yet, to activate it.
    /// </summary>
    public event PlaceableEventHandler ActivatePlaceableEvent;
    public event PlaceableEventHandler DeactivatePlaceableEvent;

    /// <summary>
    /// An audio source on the Placeable that will play its placement sound.
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Whether this Placeable has been placed yet.
    /// </summary>
    private bool _placementInProcess = false;

    /// <summary>
    /// Whether this Placeable has been activated yet.
    /// </summary>
    private bool _activated = false;

    /// <summary>
    /// Whether this Placeable has been placed yet.
    /// </summary>
    private bool _placed = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_placed)
        {
            if (_placementInProcess)
            {
                // If the sound has finished playing, solidify the placement of this Placeable.
                Destroy(GetComponent<OVRGrabbable>());
                Destroy(GetComponent<Rigidbody>());
                Destroy(GetComponent<Collider>());

                _placed = true;

                // Trigger the event for telling the ExperimentManager to continue the experiment.
                ConfirmPlacementEvent.Invoke();

                _placementInProcess = false;
            }

            // If the placeable drops below the visible ground, bring it back up to a grabbable space.
            Vector3 originalPosition = transform.position;
            if (transform.position.y < LOWEST_ALLOWED_PLACEABLE_Y_POSITION)
            {
                transform.SetPositionAndRotation(new Vector3(originalPosition.x, LOWEST_ALLOWED_PLACEABLE_Y_POSITION, originalPosition.z), transform.rotation);
                transform.GetComponent<Rigidbody>().linearVelocity = transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }

            // Activate this placeable if it is grabbed by the participant.
            if (GetComponent<OVRGrabbable>().isGrabbed && !_activated)
            {
                ActivatePlaceable();
            }
        }
    }

    /// <summary>
    /// Activates a placeable and makes it use gravity.
    /// </summary>
    public void ActivatePlaceable()
    {
        _activated = true;

        // Activate Placeable. (Make it use gravity.)
        GetComponent<Rigidbody>().useGravity = true;

        // Trigger activation event.
        ActivatePlaceableEvent.Invoke();
    }

    /// <summary>
    /// Deactivates a placeable and makes it stop using gravity.
    /// </summary>
    public void DeactivatePlaceable()
    {
        _activated = false;

        // Deactivate Placeable. (Make it stop using gravity.)
        GetComponent<Rigidbody>().useGravity = false;

        // Trigger activation event.
        DeactivatePlaceableEvent.Invoke();
    }

    /// <summary>
    /// Makes this Placeable immovable and plays the sound for completing placement.
    /// </summary>
    public void ConfirmPlacement()
    {
        // Make the placement sound play.
        _audioSource.Play();

        transform.GetComponent<Rigidbody>().linearVelocity = transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // Make the placeable glow for a few seconds.
        GetComponent<MeshRenderer>().material = GlowingPlaceableMaterial;

        _placementInProcess = true;
    }
}
