using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioClipArray
{
    //audio clip array class to act as the inside array for the array of arrays because Unity is stupid and can't just do it in an easy way
    public AudioClip[] allTheSounds;
}
public class AudioManager : MonoBehaviour
{
    AudioSource audioController;

    //each of the arrays (these are not directly used but helped me keep track of which clip was where since we don't have all the required clips yet
    //feel free to delete
    public AudioClip[] audioCat;
    public AudioClip[] audioBall;
    public AudioClip[] audioBell;
    public AudioClip[] audioPillow;
    public AudioClip[] audioFish;
    public AudioClip[] audioLaser;
    public AudioClip[] audioBox;
    
    //the thing that is actually used, an array of audio clip arrays
    public AudioClipArray[] arrayOfArrays;

    //the variable that will pick one of the variations
    private int soundIndex;

    //the variable that will choose which item to play a sound from
    private int itemNumber;

    // Start is called before the first frame update
    void Start()
    {
        //basic enough
        audioController = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //this'll be called by whatever it requires, pressing the button or on level up or whatever, just using E for testing
        if (Input.GetKeyDown(KeyCode.E))
        {
            //this won't be random, will instead be set based on whichever item is picked
            itemNumber = Random.Range(0, arrayOfArrays.Length);

            //this will either be random or specific based on if we decide whether we're doing sound variations
            //based on level or not
            //.allTheSounds is used to call back into the array class above, Unity still doesn't work if you use
            //arrayOfArrays[][] formatting even though that's basically what it is
            soundIndex = Random.Range(0, arrayOfArrays[itemNumber].allTheSounds.Length);

            //calls the sound function passing in
            PlaySound(soundIndex, itemNumber);
        }
    }

    void PlaySound(int soundIndex, int itemNumber)
    {
        //plays the corresponding sound, same rules as soundIndex above
        audioController.PlayOneShot(arrayOfArrays[itemNumber].allTheSounds[soundIndex]);
    }
}
