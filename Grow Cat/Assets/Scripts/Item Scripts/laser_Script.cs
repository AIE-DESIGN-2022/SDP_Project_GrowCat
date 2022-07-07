using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_Script : MonoBehaviour
{
    public GameObject laserBase;
    public GameObject catTower;
    public GameObject laserSpawn;

    // Start is called before the first frame update
    void Start()
    {
        laserSpawn = GameObject.Find("Object_Laser"); //find the spawnpoint of laser
        catTower = GameObject.Find("Box_Level6(Clone)"); //check if the tower is the right level
        
        Instantiate(laserBase); //create laser base
        laserBase = GameObject.Find("Laser(Clone)"); //assign the laser as variable

        if (catTower == null) //if cat tower isnt high enough
        { 
            //kill the laser
            Rigidbody rb = laserBase.GetComponent<Rigidbody>();
            rb.useGravity = true; //make the base fall

            ItemPhase itemSpawn = laserSpawn.GetComponent<ItemPhase>(); //laser will not count as maxed
            itemSpawn.currentLevel++;

            Destroy(gameObject); //destroy the dot
        }

    }

    // Update is called once per frame
    void Update()
    {
        laserBase.transform.position = laserSpawn.transform.position; //laser base is in position
        laserBase.transform.LookAt(transform.position);
        laserBase.transform.Rotate(new Vector3(0, -90, 0));
    }
}
