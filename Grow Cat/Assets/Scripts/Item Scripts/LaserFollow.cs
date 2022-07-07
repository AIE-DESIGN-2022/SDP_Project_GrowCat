using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollow : MonoBehaviour
{
    public float speed;
    public float walk;
    public GameObject laser;
    Animator catAnimator;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        catAnimator = FindObjectOfType<Animator>(); //select animator
        audioManager = FindObjectOfType<AudioManager>();

        StartCoroutine(CatSounds());
        IEnumerator CatSounds()
        {
            yield return new WaitForSeconds(5);
            audioManager.PlaySound(2);
            StartCoroutine(CatSounds());
        }
    }

    void FixedUpdate()
    {
        //ensure the cat stays on the same Y level instead of sinking into ground
        Vector3 position = new Vector3 (transform.position.x, 1.05f, transform.position.z);
        transform.position = position;

        //if a laser has been assigned
        if (laser != null)
        {
            walk = speed * Time.deltaTime; //walk speed

            transform.position = Vector3.MoveTowards(transform.position, laser.transform.position, speed); //move towards the laser

            catAnimator.SetTrigger("Walk"); //animator switches to walking animation
        }
        else
        {
            catAnimator.SetTrigger("Idle"); //if there is no laser, set animator to idle animation
        }
    }
}
