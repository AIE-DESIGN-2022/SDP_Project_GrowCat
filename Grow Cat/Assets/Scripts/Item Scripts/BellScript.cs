using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellScript : MonoBehaviour
{
    GameObject catTower;
    GameObject bellSpawn;
    public GameObject deadState;


    // Start is called before the first frame update
    void Start()
    {
        catTower = GameObject.Find("Box_Level5(Clone)"); //if the cat tower is level 5, assign
        bellSpawn = GameObject.Find("Object_Bell"); //assign bell spawn

    }

    // Update is called once per frame
    void Update()
    {
        if (catTower == null) //if the cat tower isnt level 5, but IS level 6.
        {
            catTower = GameObject.Find("Box_Level6(Clone)");
        }

        if (catTower != null) //if the cat tower is levelled enough, the bell will stay at the spawn point
        {
            this.transform.position = bellSpawn.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") //if the bell touches the ground 
        {
            GameObject dead = Instantiate(deadState); //create a bell w/out any scripts
            dead.transform.position = transform.position; //the bell is put where the previous bell was
            bellSpawn.SetActive(false); //kill the spawner
            Destroy(this.gameObject); //destroy the old bell

        }
    }
}
