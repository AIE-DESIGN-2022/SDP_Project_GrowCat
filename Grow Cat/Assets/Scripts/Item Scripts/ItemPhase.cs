using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPhase : MonoBehaviour
{
    //Levelling
    public int maxLevel;
    public int currentLevel = 1;
    public LevelUpManager levelUpManager;
    public Text buttonText;

    //modelling
    ModelSwap modelSwap; //our script for swapping models
    GameObject model; //is used to represent the current prefab model
    PositionAnchor positionAnchor; //controls the location of the prefab models

    //Sound
    AudioManager audioManager;
    public int soundCategory; // tell the system what category of sounds to play for this item

    // Start is called before the first frame update
    void Start()
    {
        modelSwap = GetComponent<ModelSwap>(); //grab the model swap component on this item
        audioManager = FindObjectOfType<AudioManager>(); //grab the audio manager
    }

    public void LevelUp() //level up the item
    {
        //check the item hasnt reached max level yet
        if(currentLevel < maxLevel)
        {
            currentLevel++; //increase items level

            //Make sure the level up sound isn't stacking here.
            GameObject audioManager = GameObject.Find("AudioManager");
            AudioSource audioSource = audioManager.GetComponent<AudioSource>();
            if(!audioSource.isPlaying)
            {
                PlaySoundEffect(5); //play a level up sound
            }

            StartCoroutine(InstantiateModel(0.5f)); //change the prefab with level ups
        }
    }
    
    public IEnumerator InstantiateModel(float seconds) //changes the prefab everytime it levels up and spawns it originally
    {
        yield return new WaitForSeconds(seconds);

        //check there is still a model available
        if(currentLevel < modelSwap.models.Length)
        {
            Destroy(model); //clear previous model
            model = Instantiate(modelSwap.models[currentLevel].gameObject); //create this objects model at it's current level
            AnchorPosition(model, this.gameObject); //the models transform is equal to this items
            PlaySoundEffect(soundCategory); //play one of this item's sound effects
            ShowPop(model);
        }
    }

    
    void AnchorPosition(GameObject spawn, GameObject parent) //stick one object to anothers position permanently
    {
        positionAnchor = spawn.GetComponentInParent<PositionAnchor>(); //grab the model's anchor script
        if(positionAnchor != null)
        {
            positionAnchor.itemBlock = parent.gameObject.transform; //assign the item's location as the models location
        }
        
    }

    public void ShowPop(GameObject position) //Show a cloud animation over the transformation
    {
        int randomPop = Random.Range(0, levelUpManager.pops.Length); //pick a random pop

        GameObject pop = Instantiate(levelUpManager.pops[randomPop].gameObject); //create the pop
        AnchorPosition(pop, position); //the pop appears in the same position as the model
    }

    public void SpawnOnMap() //spawn the item on the map
    {
        levelUpManager.buttonsClicked++; //tell system we've clicked a button
        levelUpManager.LevelUpAll(); //level up all objects on the map
        this.gameObject.SetActive(true); //bring this item onto the map
        StartCoroutine(InstantiateModel(0.5f));

        //check if all buttons are clicked
        if (levelUpManager.buttonsClicked == 6)
        {
            StartCoroutine(CalculateResult(1));
        } 
    }

    void PlaySoundEffect(int sound)
    {
        audioManager.PlaySound(sound); //play selected sound
    }

    public IEnumerator CalculateResult(float seconds) //calculate final result *is often wrong*
    {
        yield return new WaitForSeconds(seconds);
        levelUpManager.CheckForMaxed(); //system counts how many are maxed out
        levelUpManager.ShowResult(); //System Shows result
    }
    //bum
}
