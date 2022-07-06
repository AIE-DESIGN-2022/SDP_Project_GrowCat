using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    GameObject itemObject;
    ItemPhase itemPhase;
    Rigidbody rb;
    public GameObject deadState;

    // Start is called before the first frame update
    void Start()
    {
        itemObject = GameObject.FindGameObjectWithTag("BallSpawn"); //Initialise 
        itemPhase = itemObject.GetComponent<ItemPhase>(); //Initialise
        rb = GetComponent<Rigidbody>();

        if (itemPhase.currentLevel >= 1) //throw the ball towards the fishtank
        {
            rb.AddForce(0, 400, -50 * itemPhase.currentLevel);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        itemObject.transform.position = transform.position; //keep the spawning gameobject on the ball
    }
    
    private void OnCollisionEnter(Collision collision)
    {
      

        if (collision.gameObject.tag == "Fish") //when the ball collides with fishtank and hasnt touched the ground yet
        {
            GameObject fishtank = GameObject.FindGameObjectWithTag("FishSpawn"); //find the fishtank spawner
            fishtank.transform.position = new Vector3(fishtank.transform.position.x, 0.5f, fishtank.transform.position.z); //change it to elevated position
            itemPhase.ShowPop(fishtank); //show a pop over the fishtank
            Destroy(this.gameObject); //destroy the ball

            GameObject deadBall = GameObject.Find("Ball_4(Clone)");
            Destroy(deadBall);
        }       

        if(collision.gameObject.tag == "Ground") //if the ball touches the ground it cannot bring up the fishtank
        {
            GameObject dead = Instantiate(deadState); //create a ball w/out any scripts
            dead.transform.position = transform.position; //the ball is put where the previous ball was
            itemObject.SetActive(false); //kill the spawner
            Destroy(this.gameObject); //destroy the old ball
            
        }
    }
}
