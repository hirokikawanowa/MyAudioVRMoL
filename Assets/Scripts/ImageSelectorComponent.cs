using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ImageSelectorComponent.cs
// Author: Brigham Moll
// Date created: 08/05/2020

/// <summary>
/// Represents a single image in the ImageSelector.
/// </summary>
public class ImageSelectorComponent : MonoBehaviour
{
    /// <summary>
    /// Where, from left to right in the image selector, this component is.
    /// </summary>
    public enum ImageSelectorComponentPosition
    {
        Left = 1,
        Middle,
        Right,
        Invalid
    }
    public ImageSelectorComponentPosition ImageSelectorComponentOrderPosition = ImageSelectorComponentPosition.Invalid;

    /// <summary>
    /// Sets the image of this ImageSelectorComponent.
    /// </summary>
    public void SetImage(Material newImage)
    {
        GetComponent<MeshRenderer>().material = newImage;
    }

    /// <summary>
    /// If user taps an ImageSelectorComponent, use the image displayed on it for the Placeable being spawned next.
    /// </summary>
    /// <param name="other"> Collision information. </param>
    private void OnTriggerEnter(Collider other)
    {
        SphereCollider coll = null;
        if (other.gameObject.TryGetComponent(out coll))
        {
            transform.parent.GetComponent<ImageSelectorScript>().SelectImage(GetComponent<MeshRenderer>().material, ImageSelectorComponentOrderPosition);
        }
    }
}
