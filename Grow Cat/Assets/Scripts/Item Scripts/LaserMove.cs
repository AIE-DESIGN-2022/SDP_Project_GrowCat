using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    //Movement
    [Header("Movement")]
    public float speed;
    public float moveSpeed;
    public Transform point;
    public float x;
    public float z;

    private GameObject cat;

    

    // Start is called before the first frame update
    void Start()
    {
        //Assign random positions for the laser
        x = Random.Range(-6f, 6f);
        z = Random.Range(-6f, 6f);

        //starts the laser at the cats position
        cat = GameObject.FindGameObjectWithTag("Cat"); //assign cat
        Vector3 startPos = new Vector3(cat.transform.position.x, 0.5f, cat.transform.position.z); //start pos is == to cat pos
        transform.position = startPos; // start

        cat.GetComponent<LaserFollow>().laser = this.gameObject; //tell the cat object this object is the laser variable (VERY COOL)
    }

    // Update is called once per frame
    void Update()
    {
        point.position = new Vector3(x, 0.5f, z); //find next random point

        moveSpeed = speed * Time.deltaTime; //assign a movespeed

        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed); //move towards random point


        //if they reach the point, select a new one
        if(transform.position.x > 4.3 || transform.position.x < -4.1 || transform.position.z > 4.2 || transform.position.z < -4.2 || transform.position == point.position)
        {
            x = Random.Range(-6f, 6f);
            z = Random.Range(-6f, 6f);
        }
    }
}
