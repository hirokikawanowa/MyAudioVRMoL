using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ImageSelectorScript.cs
// Author: Brigham Moll
// Date created: 08/05/2020

/// <summary>
/// Allows a user to select an image for a Placeable.
/// </summary>
public class ImageSelectorScript : MonoBehaviour
{
    /// <summary>
    /// Images for all placeable items.
    /// </summary>
    public List<Material> placeableImages;

    /// <summary>
    /// Sets the first index to look at to find the three images to display.
    /// Then, shows those images.
    /// </summary>
    /// <param name="imageIndex"> The starting index where the next images to be displayed can be found. </param>
    public void SetLastItemImageIndex(int imageIndex)
    {
        // Populate image components with images (if available).
        foreach (ImageSelectorComponent imgSelectorComp in transform.GetComponentsInChildren<ImageSelectorComponent>())
        {
            imageIndex++;
            if (placeableImages.Count > imageIndex)
                imgSelectorComp.SetImage(placeableImages[imageIndex]);
        }
    }

    /// <summary>
    /// Called when a user selects an image.
    /// </summary>
    /// <param name="componentPosition"> Where, from left to right in the selector, the chosen image was. </param>
    /// <param name="imageSelected"> The image selected. </param>
    public void SelectImage(Material imageSelected, ImageSelectorComponent.ImageSelectorComponentPosition componentPosition)
    {
        FindObjectOfType<ExperimentManagerScript>().ConfirmImageSelection(imageSelected, componentPosition);
    }

    /// <summary>
    /// Set text on ImageSelector.
    /// </summary>
    /// <param name="itemText"> New text for ImageSelector. </param>
    public void SetItemText(string itemText)
    {
        GetComponentInChildren<TextMesh>().text = itemText;
    }
}
