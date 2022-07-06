using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject itemObject;
    ItemPhase itemPhase;

    // Start is called before the first frame update
    void Start()
    {
        itemObject = GameObject.FindGameObjectWithTag("BallSpawn"); //Initialise 
        itemPhase = itemObject.GetComponent<ItemPhase>(); //Initialise

        if(itemPhase.currentLevel >= 1)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
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
        if(collision.gameObject.tag == "Fish") //when the ball collides with fishtank
        {
            GameObject fishtank = GameObject.FindGameObjectWithTag("FishSpawn"); //find the fishtank spawner
            fishtank.transform.position = new Vector3(fishtank.transform.position.x, 0.5f, fishtank.transform.position.z); //change it to elevated position
            itemPhase.ShowPop(fishtank);
            Destroy(this);
        }
    }
}
