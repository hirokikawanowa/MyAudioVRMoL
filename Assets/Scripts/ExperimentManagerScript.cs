using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ExperimentManagerScript.cs
// Author: Brigham Moll
// Date created: 06/05/2020

/// <summary>
/// Manages general operations in the experiment taking place within the memory palace.
/// </summary>
public class ExperimentManagerScript : MonoBehaviour
{
    #region CONSTANTS

    /// <summary>
    /// A test string to be used in the creation of a placeable to make sure text can be changed on the placeable.
    /// </summary>
    private const string TEST_PLACEABLE_ITEM_TEXT = "TEAPOT";

    /// <summary>
    /// Where to spawn new Placeables in the testing environment.
    /// </summary>
    private Vector3 TEST_PLACEABLE_SPAWN_LOCATION = new Vector3(0, 1.5f, 0);

    /// <summary>
    /// Where to place collectibles on the test level.
    /// </summary>
    private List<Vector3> TEST_COLLECTIBLE_LOCATIONS = new List<Vector3>()
    {
        new Vector3(-2.8f, 3, 2.5f),
        new Vector3(-0.5f, 3, 2.5f),
        new Vector3(-2.8f, 3, -1f),
        new Vector3(-4.5f, 3, -4.5f),
        new Vector3(-6f, 3, 0.3f),
        new Vector3(-5.6f, 3, -1.8f),
        new Vector3(-2f, 3, -3f),
        new Vector3(-1f, 3, -7f),
        new Vector3(4.5f, 3, -7.2f),
        new Vector3(4f, 3, -3.5f),
        new Vector3(4f, 3, 2.9f),
        new Vector3(4.7f, 3, -0.1f),
        new Vector3(1.8f, 3, -0.3f),
        new Vector3(-5.7f, 3, -7.3f),
    };

    /// <summary>
    /// Name of the container for the placeables.
    /// </summary>
    private const string PLACEABLE_CONTAINER_NAME = "PlaceableContainer";

    /// <summary>
    /// Name of the container for the collectibles.
    /// </summary>
    private const string COLLECTIBLE_CONTAINER_NAME = "CollectibleContainer";

    /// <summary>
    /// The name of the file to read the item list (strings) from. (For the 5 debug words.)
    /// </summary>
    private const string DEBUG_ITEM_LIST_FILE_NAME = "itemList.txt";

    /// <summary>
    /// The name of the file to read the item list (strings) from. (For the actual test.)
    /// </summary>
    private const string TEST_ITEM_LIST_FILE_NAME = "postTestRandomList.txt";

    /// <summary>
    /// Name of the file containing the word list for the post test in the second week of the experiment.
    /// </summary>
    private const string SECOND_WEEK_TEST_ITEM_LIST_FILE_NAME = "2ndpostTestRandomList30.txt";

    /// <summary>
    /// The number of seconds allowed to elapse in an experiment phase.
    /// </summary>
    private const float PHASE_TIME_LIMIT = 900;

    /// <summary>
    /// These strings are used in the data tracker.
    /// </summary>
    private const string NEW_COLLECTIBLE_PHASE_TITLE = "-- Collectible Phase --";
    private const string NEW_TEST_PLACEABLE_PHASE = "-- Testing Placeable Phase --";
    private const string NEW_TRAINING_PLACEABLE_PHASE = "-- Training Placeable Phase --";
    private const string COLLECTIBLE_COLLECTED_AT = "Collectable collected at: ";
    private const string PLACEABLE_PLACED_AT = "Placeable placed at: ";
    private const string PHASE_COMPLETION_TIME = "Phase completed in this many seconds: ";
    private const string AT_GLOBAL_LOCATION = ", at global location: ";
    private const string SECONDS_PAST_START = " seconds past start";
    private const string IMAGE_POSITION_SELECTION_TRACKING_STRING = "Image selected from a selector at position: ";
    private const string AT_TIME_STRING = " at time: ";
    private const string AT_POSITION = " at position: ";

    #endregion

    #region VARIABLES

    /// <summary>
    /// Whether it is the first experiment week. If true, it is, if false, it is the second week.
    /// Used to choose word list.
    /// </summary>
    public bool IS_FIRST_EXPERIMENT_WEEK = true;

    /// <summary>
    /// Container for all Placeables made in the experiment.
    /// </summary>
    private GameObject placeableContainer = null;

    /// <summary>
    /// The image selector prefab with the images/words for week 2 of experiments.
    /// </summary>
    public GameObject imageSelectorPrefabForWeekTwo = null;

    /// <summary>
    /// Container for all Collectibles made in the experiment.
    /// </summary>
    public GameObject collectibleContainer = null;

    /// <summary>
    /// The prefab used to generate a new Placeable instance.
    /// </summary>
    public GameObject placeablePrefab = null;

    /// <summary>
    /// The prefab used to generate a new Collectible instance.
    /// </summary>
    public GameObject collectiblePrefab = null;

    /// <summary>
    /// The prefab used to generate a blank ImageSelector.
    /// </summary>
    public GameObject imageSelectorPrefab = null;

    /// <summary>
    /// A debug image selector with only 5 words (apple, orange, jungle, monkey, speaker)
    /// </summary>
    public GameObject debugImageSelectorPrefab = null;

    /// <summary>
    /// The prefab used to generate the user progress display UI.
    /// </summary>
    public GameObject userProgressDisplayPrefab = null;

    /// <summary>
    /// How many collectibles the user has collected in the environment.
    /// </summary>
    public int CollectiblesCollected = 0;

    /// <summary>
    /// Tracks what participant data is being saved, and saves it.
    /// </summary>
    public DataTracker dataTracker;

    /// <summary>
    /// Contains the list of items to be memorized.
    /// </summary>
    private List<string> _trainingItemList = null;
    private List<string> _testingItemList = null;

    /// <summary>
    /// The current index of the item list relating to the item that was last put on a Placeable.
    /// </summary>
    private int _currentItemIndex = -1;

    /// <summary>
    /// The placeables that have been spawned so far.
    /// </summary>
    private List<Placeable> _placeablesCreated = new List<Placeable>();

    /// <summary>
    /// The placeables that have been spawned so far.
    /// </summary>
    private List<GameObject> _collectiblesCreated = new List<GameObject>();

    /// <summary>
    /// The ImageSelector currently being used, if not null.
    /// </summary>
    private ImageSelectorScript _currentImageSelector = null;

    /// <summary>
    /// Whether a placeable is currently active.
    /// </summary>
    private bool _placeableActive = false;

    /// <summary>
    /// Whether the user progress display is currently being shown.
    /// </summary>
    private bool _progressShown = false;

    /// <summary>
    /// Reference to the user GameObject.
    /// </summary>
    private GameObject _user = null;

    /// <summary>
    /// Reference to the user progress display in the scene (if there is one).
    /// </summary>
    private UserProgressDisplay _userProgressDisplay = null;

    /// <summary>
    /// Whether the testing placeables list is in use.
    /// </summary>
    private bool _testingPlaceablesInUse = false;

    /// <summary>
    /// True when the experiment is midway through changing phases.
    /// </summary>
    private bool _changingPhase = false;

    /// <summary>
    /// How many seconds remain in the current phase of the experiment.
    /// </summary>
    private float _remainingSecondsInPhase = 0;

    /// <summary>
    /// The time it was in the last frame update.
    /// </summary>
    private float _timeLastFrame = -1;

    /// <summary>
    /// Different possible experiment phases that the experiment could be in.
    /// </summary>
    private enum CurrentExperimentPhase
    {
        CollectiblesPhase = 0,
        ItemPlacementPhase = 1,
        NoCurrentPhase = 2
    }
    /// <summary>
    /// What phase of the experiment is currently being done.
    /// </summary>
    private CurrentExperimentPhase _currentExperimentPhase = CurrentExperimentPhase.NoCurrentPhase;

    #endregion

    #region METHODS

    // Start is called before the first frame update
    void Start()
    {
        // Set the reference to the user GameObject.
        _user = FindObjectOfType<CharacterController>().gameObject;

        // Prepare containers for Placeables and Collectibles.
        PrepareContainers();

        // Read an item list from a file.
        ReadItemLists();
    }

    // Update is called once per frame
    void Update()
    {
        // Update remaining time, if there is any.
        if (_remainingSecondsInPhase > 0)
        {
            UpdateRemainingTime();
        }
        else
        {
            if(_userProgressDisplay != null)
            {
                _userProgressDisplay.SetRemainingTime(0);
            }
        }

        // If Placeables are a thing..
        if (_currentExperimentPhase == CurrentExperimentPhase.ItemPlacementPhase && _placeablesCreated.Count > 0)
        {
            // If last Placeable somehow left its container, put it back.
            if (_placeablesCreated[_placeablesCreated.Count - 1] != null)
            {
                if (_placeablesCreated[_placeablesCreated.Count - 1].transform.parent == null)
                {
                    _placeablesCreated[_placeablesCreated.Count - 1].transform.SetParent(placeableContainer.transform);
                }
            }

            // If user presses Y, confirm the placement of a Placeable.
            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                ConfirmPlaceablePlacement();
            }
        }

        if(Input.GetKey(KeyCode.Alpha9))
        {
            // Save tracked data to a file.
            dataTracker.SaveTrackedData();
        }

        // You can end a phase, if there's one going.
        if (_currentExperimentPhase != CurrentExperimentPhase.NoCurrentPhase)
        {
            if (!_changingPhase)
            {
                if (Input.GetKey(KeyCode.Alpha0))
                {
                    // End current phase.
                    CleanupCurrentExperimentPhase();
                }
            }
        }
        else
        {
            // If there's no phase going, you can select a phase to start via keyboard.
            if (!_changingPhase)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    // Start collectibles phase.
                    StartCollectiblePhase();
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    // Start training placement phase.
                    StartItemPlacementPhase(true);
                }
                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    // Start testing placement phase.
                    StartItemPlacementPhase(false);
                }

                _remainingSecondsInPhase = PHASE_TIME_LIMIT;
                if (_userProgressDisplay != null)
                {
                    _userProgressDisplay.SetRemainingTime(_remainingSecondsInPhase);
                }
            }
        }

        // If user presses A, show the user progress display in front of them.
        if (OVRInput.GetDown(OVRInput.RawButton.A) && !_progressShown)
        {
            GameObject newDisplayObj = SpawnInFrontOfUser(userProgressDisplayPrefab);
            _userProgressDisplay = newDisplayObj.GetComponent<UserProgressDisplay>();

            UpdateProgressDisplay();

            _progressShown = true;
        }
        // When they let go of the button, hide the display.
        else if (OVRInput.GetUp(OVRInput.RawButton.A) && _progressShown)
        {
            if (_userProgressDisplay != null)
            {
                Destroy(_userProgressDisplay.gameObject);
                _userProgressDisplay = null;

                _progressShown = false;
            }
        }

        // By pressing X, one can call the last placeable (if not placed) back to be in front of them.
        if(OVRInput.GetDown(OVRInput.RawButton.X))
        {
            ReturnCurrentPlaceableToParticipant();
        }
    }

    /// <summary>
    /// Returns the currently active placeable, if there is one, to a position hovering before the participant.
    /// (This is so that if the placeable goes flying or drops out of reachable areas, it can be retrieved.)
    /// </summary>
    private void ReturnCurrentPlaceableToParticipant()
    {
        // Check if there is a currently active placeable.
        if(_placeableActive)
        {
            Placeable currentPlaceable = _placeablesCreated[_placeablesCreated.Count - 1];

            // Freeze the Placeable.
            currentPlaceable.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            currentPlaceable.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            // Deactivate the placeable.
            currentPlaceable.DeactivatePlaceable();

            // Bring it to the participant.
            currentPlaceable.transform.position = DetermineLocationInFrontOfUser();

            // Face placeable to participant.
            MakeObjectFaceParticipant(currentPlaceable.gameObject);
        }
    }

    /// <summary>
    /// Turns an object to face the user.
    /// </summary>
    /// <param name="objectToTurn"> The object to turn. </param>
    private void MakeObjectFaceParticipant(GameObject objectToTurn)
    {
        // Ensure only rotation on y-axis, and make the object face user.
        Vector3 targetPosition = new Vector3(_user.transform.position.x,
                           objectToTurn.transform.position.y,
                           _user.transform.position.z);
        objectToTurn.transform.LookAt(targetPosition);
    }

    /// <summary>
    /// Updates how much time is left in the current phase.
    /// </summary>
    private void UpdateRemainingTime()
    {
        if (_remainingSecondsInPhase != -1)
        {
            if (_timeLastFrame != -1)
            {
                // Compare last frame time to this frame's time.
                // Decrement seconds remaining by the difference.
                float timeDifference = Time.time - _timeLastFrame;
                _timeLastFrame = Time.time;
                _remainingSecondsInPhase = _remainingSecondsInPhase - timeDifference;
            }
            else
            {
                _timeLastFrame = Time.time;
            }

            // Display properly, if there is a display.
            if (_userProgressDisplay != null)
            {
                _userProgressDisplay.SetRemainingTime(_remainingSecondsInPhase);
            }

            if (_remainingSecondsInPhase <= 0)
            {
                // End the phase, time is up.
                Debug.Log("[ExperimentManager] PHASE ENDED, TIME IS UP.");
                _remainingSecondsInPhase = -1;
                CleanupCurrentExperimentPhase();
            }
        }
    }

    /// <summary>
    /// Updates the text on the progress display to show current collectible/placement progress.
    /// (Does not update time-portion of display.)
    /// </summary>
    private void UpdateProgressDisplay()
    {
        if (_userProgressDisplay != null)
        {
            if (_currentExperimentPhase == CurrentExperimentPhase.CollectiblesPhase)
            {
                _userProgressDisplay.SetProgressText(CollectiblesCollected, TEST_COLLECTIBLE_LOCATIONS.Count, UserProgressDisplay.ProgressDisplayType.CollectiblePhase);
            }
            else if (_currentExperimentPhase == CurrentExperimentPhase.ItemPlacementPhase)
            {
                _userProgressDisplay.SetProgressText(_currentItemIndex, GetCurrentItemListInUse().Count, UserProgressDisplay.ProgressDisplayType.PlaceablePhase);
            }
            else if (_currentExperimentPhase == CurrentExperimentPhase.NoCurrentPhase)
            {
                _userProgressDisplay.ClearProgressText();
            }
            else
            {
                Debug.LogError("[ExperimentManager] Unsupported experiment phase, cannot show progress information.");
            }
        }
    }

    /// <summary>
    /// Starts a collectible phase by spawning in all the collectibles for the palace.
    /// </summary>
    private void StartCollectiblePhase()
    {
        // Track new phase start.
        dataTracker.AddNewTrackedDataLine(NEW_COLLECTIBLE_PHASE_TITLE);

        _changingPhase = true;
        CleanupCurrentExperimentPhase();

        _currentExperimentPhase = CurrentExperimentPhase.CollectiblesPhase;

        // Instantiate collectibles.
        foreach (Vector3 position in TEST_COLLECTIBLE_LOCATIONS)
        {
            CreateCollectible(position);
        }
        _changingPhase = false;
    }

    /// <summary>
    /// Starts an item placement phase.
    /// </summary>
    /// <param name="trainingItems"> Set to true to use the 5 training items to be placed. </param>
    private void StartItemPlacementPhase(bool trainingItems)
    {
        _changingPhase = true;
        CleanupCurrentExperimentPhase();

        _currentExperimentPhase = CurrentExperimentPhase.ItemPlacementPhase;

        if(trainingItems)
        {
            // Track new phase start.
            dataTracker.AddNewTrackedDataLine(NEW_TRAINING_PLACEABLE_PHASE);
            _testingPlaceablesInUse = false;
        }
        else
        {
            // Track new phase start.
            dataTracker.AddNewTrackedDataLine(NEW_TEST_PLACEABLE_PHASE);
            _testingPlaceablesInUse = true;
        }

        RunImageSelector();
        _changingPhase = false;
    }

    /// <summary>
    /// Cleans up the current phase of the experiment so that no phase is being used.
    /// </summary>
    private void CleanupCurrentExperimentPhase()
    {
        _changingPhase = true;
        if (_currentExperimentPhase != CurrentExperimentPhase.NoCurrentPhase)
        {
            // Track new phase end.
            dataTracker.AddNewTrackedDataLine(PHASE_COMPLETION_TIME + (PHASE_TIME_LIMIT - _remainingSecondsInPhase));

            if (_currentExperimentPhase == CurrentExperimentPhase.CollectiblesPhase)
            {
                CleanupCollectiblePhase();
            }
            else if (_currentExperimentPhase == CurrentExperimentPhase.ItemPlacementPhase)
            {
                CleanupItemPlacementPhase();
            }

            _currentExperimentPhase = CurrentExperimentPhase.NoCurrentPhase;
            _timeLastFrame = -1;
            _remainingSecondsInPhase = -1;
            UpdateProgressDisplay();
        }
        _changingPhase = false;
    }

    /// <summary>
    /// Cleans out any remaining item placements from a previous item placement phase.
    /// </summary>
    private void CleanupItemPlacementPhase()
    {
        // Stop listening to the last Placeable's events, if a Placeable exists.
        if (_placeablesCreated.Count > 0)
        {
            _placeablesCreated[_placeablesCreated.Count - 1].ActivatePlaceableEvent -= OnActivatePlaceable;
            _placeablesCreated[_placeablesCreated.Count - 1].DeactivatePlaceableEvent -= OnDeactivatePlaceable;
            _placeablesCreated[_placeablesCreated.Count - 1].ConfirmPlacementEvent -= OnPlaceablePlacementConfirmed;
        }

        Destroy(placeableContainer);
        CreateNewPlaceablesContainer();

        _currentItemIndex = -1;
        _placeableActive = false;
        if (_currentImageSelector != null)
        {
            Destroy(_currentImageSelector.gameObject);
            _currentImageSelector = null;
        }
    }

    /// <summary>
    /// Cleans out any remaining collectibles from a previous collectible phase.
    /// </summary>
    private void CleanupCollectiblePhase()
    {
        Destroy(collectibleContainer);
        CreateNewCollectiblesContainer();

        CollectiblesCollected = 0;
    }

    /// <summary>
    /// Triggered when the placement of a Placeable is confirmed.
    /// </summary>
    private void ConfirmPlaceablePlacement()
    {
        // Start Placeable placement confirmation.
        _placeablesCreated[_placeablesCreated.Count - 1].ConfirmPlacement();
    }

    /// <summary>
    /// Placement has been completed for the Placeable, so now run the ImageSelector for the next item in the list.
    /// </summary>
    private void OnPlaceablePlacementConfirmed()
    {
        // Mark that a placeable was placed.
        dataTracker.AddNewTrackedDataLine(PLACEABLE_PLACED_AT + (PHASE_TIME_LIMIT - _remainingSecondsInPhase) + SECONDS_PAST_START + AT_GLOBAL_LOCATION + _placeablesCreated[_placeablesCreated.Count - 1].transform.position);

        // Stop listening to this Placeable's events.
        _placeablesCreated[_placeablesCreated.Count - 1].ActivatePlaceableEvent -= OnActivatePlaceable;
        _placeablesCreated[_placeablesCreated.Count - 1].DeactivatePlaceableEvent -= OnDeactivatePlaceable;
        _placeablesCreated[_placeablesCreated.Count - 1].ConfirmPlacementEvent -= OnPlaceablePlacementConfirmed;

        // Update the progress display.
        UpdateProgressDisplay();

        // Make a new Placeable.
        RunImageSelector();
    }

    /// <summary>
    /// Determines where in space is in front of the user.
    /// </summary>
    private Vector3 DetermineLocationInFrontOfUser()
    {
        Vector3 newLocation = _user.transform.position + (_user.transform.forward / 2.2f);
        newLocation.y += 0.5f;
        return newLocation;
    }

    /// <summary>
    /// Reads an item list (strings) from a file to be able to generate Placeables.
    /// Format of text file: Each line has an item to be memorized.
    /// (Will load both the testing items lists (long one and debug/testing one))
    /// </summary>
    private void ReadItemLists()
    {
        // Instantiate empty list.
        _trainingItemList = new List<string>();
        _testingItemList = new List<string>();

        // Get path for item list file.
        string trainingItemListFilePath = "";
        string testingItemListFilePath = "";

        trainingItemListFilePath = Application.dataPath + "\\" + DEBUG_ITEM_LIST_FILE_NAME;

        if (IS_FIRST_EXPERIMENT_WEEK)
        {
            testingItemListFilePath = Application.dataPath + "\\" + TEST_ITEM_LIST_FILE_NAME;
        }
        else
        {
            testingItemListFilePath = Application.dataPath + "\\" + SECOND_WEEK_TEST_ITEM_LIST_FILE_NAME;
        }

        // Read item names into list of items, then close the file.
        int counter = 0;
        string item;
        System.IO.StreamReader trainingListFile =
            new System.IO.StreamReader(trainingItemListFilePath);
        while ((item = trainingListFile.ReadLine()) != null)
        {
            _trainingItemList.Add(item);
            counter++;
        }

        trainingListFile.Close();

        counter = 0;
        item = "";
        System.IO.StreamReader testingListFile =
            new System.IO.StreamReader(testingItemListFilePath);
        while ((item = testingListFile.ReadLine()) != null)
        {
            _testingItemList.Add(item);
            counter++;
        }

        testingListFile.Close();
    }

    /// <summary>
    /// Prepares the container objects for the Placeables and Collectibles.
    /// </summary>
    private void PrepareContainers()
    {
        CreateNewPlaceablesContainer();
        CreateNewCollectiblesContainer();
    }

    /// <summary>
    /// Generates the container object for collectibles to be stored in.
    /// </summary>
    private void CreateNewCollectiblesContainer()
    {
        collectibleContainer = new GameObject(COLLECTIBLE_CONTAINER_NAME);
        collectibleContainer.transform.SetParent(transform);
    }

    /// <summary>
    /// Generates the container object for Placeables to be stored in.
    /// </summary>
    private void CreateNewPlaceablesContainer()
    {
        placeableContainer = new GameObject(PLACEABLE_CONTAINER_NAME);
        placeableContainer.transform.SetParent(transform);
    }

    /// <summary>
    /// Creates an ImageSelector in front of the user to pick a picture for the next Placeable item.
    /// </summary>
    /// <param name="testingItems"> Set to true if using the testing items list. </param>
    private void RunImageSelector()
    {
        // Put the next item into the Placeable.
        _currentItemIndex++;

        _placeableActive = false;

        List<string> itemList = GetCurrentItemListInUse();

        // Make sure there /is/ a next item.
        if (_currentItemIndex < itemList.Count)
        {
            GameObject selectorPrefab = null;
            if(!_testingPlaceablesInUse)
            {
                selectorPrefab = debugImageSelectorPrefab;
            }
            else
            {
                if (IS_FIRST_EXPERIMENT_WEEK)
                {
                    selectorPrefab = imageSelectorPrefab;
                }
                else
                {
                    selectorPrefab = imageSelectorPrefabForWeekTwo;
                }
            }
            // Spawn ImageSelector at Placeable location, facing user.
            GameObject imageSelector = SpawnInFrontOfUser(selectorPrefab);
            _currentImageSelector = imageSelector.GetComponent<ImageSelectorScript>();

            // Set appropriate images starting index for the image selector.
            int imageStartingIndex = -1 + (_currentItemIndex*3);
            _currentImageSelector.SetLastItemImageIndex(imageStartingIndex);

            // Set appropriate item text for selector.
            _currentImageSelector.SetItemText(itemList[_currentItemIndex]);
        }
        else
        {
            Debug.Log("Participant has placed all placeables. Phase complete. Press '0' to clean up when participant is ready.");
        }
    }

    /// <summary>
    /// Spawns something in front of the user and returns it.
    /// </summary>
    /// <param name="prefabToSpawn"> The prefab for the object to be spawned. </param>
    private GameObject SpawnInFrontOfUser(GameObject prefabToSpawn)
    {
        // Determine location in front of user currently.
        Vector3 spawnLocation = DetermineLocationInFrontOfUser();
        
        GameObject newlySpawnedObject = (Instantiate(prefabToSpawn, spawnLocation, Quaternion.Euler(0, 0, 0)));

        // Make the object face user.
        MakeObjectFaceParticipant(newlySpawnedObject);

        return newlySpawnedObject;
    }

    /// <summary>
    /// Called after an image is selected in the ImageSelector. 
    /// Destroys the ImageSelector and spawns a Placeable to replace it, with the correct image and text.
    /// </summary>
    /// <param name="imageSelected"> The image selected to be used for the placeable being generated. </param>
    /// <param name="position"> The position, from left to right, that the image selected was in, in the selector. </param>
    public void ConfirmImageSelection(Material imageSelected, ImageSelectorComponent.ImageSelectorComponentPosition position)
    {
        Destroy(_currentImageSelector.gameObject);
        _currentImageSelector = null;

        dataTracker.AddNewTrackedDataLine(IMAGE_POSITION_SELECTION_TRACKING_STRING + position + AT_TIME_STRING + (PHASE_TIME_LIMIT - _remainingSecondsInPhase));

        CreatePlaceable(imageSelected);
    }

    /// <summary>
    /// Creates a Placeable object in the world with the text for the item to be remembered.
    /// </summary>
    private void CreatePlaceable(Material imageSelected)
    {
        // Instantiates a Placeable object in front of participant.
        Placeable newPlaceable = SpawnInFrontOfUser(placeablePrefab).GetComponent<Placeable>();

        // Set Placeable image.
        newPlaceable.transform.GetChild(0).GetComponent<MeshRenderer>().material = imageSelected;

        // Save a reference to this object.
        _placeablesCreated.Add(newPlaceable.GetComponent<Placeable>());

        // Listen for placeable events.
        newPlaceable.ConfirmPlacementEvent += OnPlaceablePlacementConfirmed;
        newPlaceable.ActivatePlaceableEvent += OnActivatePlaceable;
        newPlaceable.DeactivatePlaceableEvent += OnDeactivatePlaceable;

        // Put the object in the right container.
        newPlaceable.transform.SetParent(placeableContainer.transform);

        // Set the text to be the item's name.
        List<string> itemList = GetCurrentItemListInUse();
        newPlaceable.GetComponentInChildren<TextMesh>().text = itemList[_currentItemIndex];
    }

    /// <summary>
    /// Placeable was activated by being grabbed by the participant, so this method was triggered.
    /// </summary>
    private void OnActivatePlaceable()
    {
        // If no Placeable is currently active but there is one available and the grip is pressed, activate it.
        if (!_placeableActive)
        {
            if (_currentItemIndex >= 0 && _placeablesCreated.Count > 0)
            {
                _placeableActive = true;
            }
        }
    }

    /// <summary>
    /// Placeable was deactivated by moving it to the user, so reflect that status in the ExperimentManager.
    /// </summary>
    private void OnDeactivatePlaceable()
    {
        // If Placeable is active, deactivate it.
        if (_placeableActive)
        {
            _placeableActive = false;
        }
    }

    /// <summary>
    /// Returns the currently used item list for placeables.
    /// </summary>
    /// <returns></returns>
    private List<string> GetCurrentItemListInUse()
    {
        List<string> itemList;
        if (_testingPlaceablesInUse)
        {
            itemList = _testingItemList;
        }
        else
        {
            itemList = _trainingItemList;
        }

        return itemList;
    }

    /// <summary>
    /// Creates a Collectible object in the world, at a given position.
    /// </summary>
    /// <param name="position"> Position of the collectible to be placed. </param>
    private void CreateCollectible(Vector3 position)
    {
        // Instantiates a collectible.
        GameObject newCollectible = Instantiate(collectiblePrefab, position, Quaternion.identity);

        _collectiblesCreated.Add(newCollectible);

        // Move the collectible to the correct container.
        newCollectible.transform.SetParent(collectibleContainer.transform);
    }

    /// <summary>
    /// Called to destroy a specific passed in Collectible when collected. Checks if it is time to start using Placeables.
    /// </summary>
    /// <param name="collectibleToBeDestroyed"> The Collectible that was collected (is to be destroyed). </param>
    public void DestroyCollectible(GameObject collectibleToBeDestroyed)
    {
        // Mark collectible collection time.
        dataTracker.AddNewTrackedDataLine(COLLECTIBLE_COLLECTED_AT + (PHASE_TIME_LIMIT - _remainingSecondsInPhase) + SECONDS_PAST_START + AT_POSITION + collectibleToBeDestroyed.transform.position);

        // Remove from list.
        _collectiblesCreated.Remove(collectibleToBeDestroyed);

        // Destroy the collectible.
        Destroy(collectibleToBeDestroyed);

        // Increment number collected.
        CollectiblesCollected++;
        
        // Update the progress display.
        UpdateProgressDisplay();

        // If all collectibles collected, end phase.
        if(collectibleContainer.transform.childCount <= 1)
        {
            CleanupCurrentExperimentPhase();
        }
    }
    #endregion
}
