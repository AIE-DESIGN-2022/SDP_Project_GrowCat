using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// SOUND INDEX // ||||||||||||||||||||||||||||||||||||||||||||
//The sounds are randomly selected through an array of arrays that isolates categories and picks a random sound within the category.
// itemID is equal to the category of sound, the available IDs are as follows
// 0. Bell Sounds                   > "Bell_Chime_[]"
// 1. Bubble(fish) Sounds           > "Bubbles_[]"
// 2. Cat Sounds                    > "cat_footsteps_1", "cat_purr_1", "cat_scratch_1"
// 3. Laser Sounds                  > "item_laserhum_1"
// 4. Pillow Sounds                 > "item_pillow_[]"
// 5. LevelUp Sounds                > "item_levelup_1", "item_pop_1"
// 6. UI Sounds                     > "UI_Click_[]"
// 7. Box Sounds                    > "Item_Box_Drop"
// 8. Ball Sounds                   > "Item_Ball_[]"


public class AudioClipArray
{
    public AudioClip[] itemCategory; //audioclip array of category
}
public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioSource audioBGM;
    public AudioSource audioAmbient;
    public AudioClipArray[] soundLibrary; //an array of audio clip arrays containing all sound effects
    public AudioClip[] audioAmbienceSounds; //array of ambient sounds
    private int soundID; //the variable that will pick one of the variations, allows for randomisation

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioBGM.Play();
        PlayAmbience();
    }

    void PlayAmbience()
    {
        int random = Random.Range(0, audioAmbienceSounds.Length); //pick a random ambience sound
        audioAmbient.clip = audioAmbienceSounds[random]; //assign it as the clip
        audioAmbient.Play(); //play clip
        StartCoroutine(LoopAmbience(audioAmbient.clip.length)); //wait the length of the clip then loop
        IEnumerator LoopAmbience(float length) //loop
        {
            yield return new WaitForSeconds(length);
            PlayAmbience();
        }
    }

    //Call with 
    //PlaySound(itemID); //the itemID is the category of sounds listed above
    public void PlaySound(int itemID)
    {
        soundID = Random.Range(0, soundLibrary[itemID].itemCategory.Length - 1); //pick a random sound in the category
        audioSource.PlayOneShot(soundLibrary[itemID].itemCategory[soundID]); //play that sound
    }
}
