using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class FishSwim : MonoBehaviour
{
    //first location of the fish's path
    public Transform location1;
    
    //second location of the fish's path
    public Transform location2;
    
    //the fish's transform value
    public Transform currentLocation;

    //allows you to vary fish speed if you want, if not leave it at 0 or remove
    public float speedBonus;

    private Transform transferLocation;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //adds to the distance variable over time, rate influenced by speedBonus
        distance = ((distance + Time.deltaTime) + speedBonus/1000) % 1f;

        //once we get above 0.8 (pretty much end of the path)
        if (distance > 0.8)
        {
            //reset distance value
            distance = 0;

            //flip the fish
            transform.Rotate(0, 180, 0);

            //swap points (move towards other point)
            transferLocation = location1;
            location1 = location2;
            location2 = transferLocation;
        }

        //moves towards point 2 as distance increases
        currentLocation.position = Vector3.Lerp(location1.position, location2.position, distance);
    }
}
