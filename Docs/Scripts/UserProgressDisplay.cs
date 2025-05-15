using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays progress information for the current phase of the experiment to the participant.
/// </summary>
public class UserProgressDisplay : MonoBehaviour
{
    /// <summary>
    /// What is displayed for each type of phase's progress.
    /// </summary>
    private const string COLLECTIBLES_PROGRESS_TEXT = "Collectibles collected:\n";
    private const string PLACEABLES_PROGRESS_TEXT = "Placeables placed:\n";
    private const string NO_PHASE_TEXT = "No current phase\n in progress.";

    /// <summary>
    /// Text to show next to the time remaining.
    /// </summary>
    private const string TIME_REMAINING_TEXT = "Time remaining: ";

    /// <summary>
    /// How many seconds are in a minute. For conversion.
    /// </summary>
    private const int NUMBER_OF_SECONDS_IN_A_MINUTE = 60;

    /// <summary>
    /// The types of progress that can be displayed.
    /// </summary>
    public enum ProgressDisplayType
    {
        CollectiblePhase,
        PlaceablePhase
    }

    /// <summary>
    /// Where progress text is displayed.
    /// </summary>
    public TextMesh ProgressTextMesh;

    /// <summary>
    /// Shows remaining time.
    /// </summary>
    public TextMesh TimeTextMesh;

    /// <summary>
    /// Tells the progress display to show progress for either collectibles or placeables.
    /// </summary>
    /// <param name="currentNumber"> The current number of collectibles collected or placeables placed. </param>
    /// <param name="maxNumber"> The max number of placeables to place or collectibles to collect. </param>
    /// <param name="progressDisplayType"> Whether the progress is for a collectibles phase or placeables phase. </param>
    public void SetProgressText(int currentNumber, int maxNumber, ProgressDisplayType progressDisplayType)
    {
        if(progressDisplayType == ProgressDisplayType.CollectiblePhase)
        {
            ProgressTextMesh.text = COLLECTIBLES_PROGRESS_TEXT + currentNumber + "/" + maxNumber;
        }
        else if(progressDisplayType == ProgressDisplayType.PlaceablePhase)
        {
            ProgressTextMesh.text = PLACEABLES_PROGRESS_TEXT + currentNumber + "/" + maxNumber;
        }
    }

    /// <summary>
    /// Clears out any text on the progress display and shows the 'no current phase' progress text.
    /// </summary>
    public void ClearProgressText()
    {
        ProgressTextMesh.text = NO_PHASE_TEXT;
    }

    /// <summary>
    /// Sets the remaining time to be counted down from in the user progress display.
    /// </summary>
    public void SetRemainingTime(float secondsRemaining)
    {
        float leftoverSecondsRemaining = secondsRemaining % NUMBER_OF_SECONDS_IN_A_MINUTE;
        float minutesRemaining = (secondsRemaining - leftoverSecondsRemaining) / NUMBER_OF_SECONDS_IN_A_MINUTE;
        string leftoverSecondsText = "";
        // If there's one digit of seconds on the end of the display, show an extra 0 to the left of the one digit.
        if(leftoverSecondsRemaining < 10)
        {
            leftoverSecondsText = "0" + (int)leftoverSecondsRemaining;
        }
        else
        {
            leftoverSecondsText = "" + (int)leftoverSecondsRemaining;
        }
        TimeTextMesh.text = TIME_REMAINING_TEXT + (int)minutesRemaining + ":" + leftoverSecondsText;
    }
}
