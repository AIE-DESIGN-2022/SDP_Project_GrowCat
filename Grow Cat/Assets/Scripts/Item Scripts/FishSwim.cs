using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class FishSwim : MonoBehaviour
{
    public Transform location1;
    public Transform location2;
    private Transform transferLocation;
    public Transform currentLocation;
    public float speedBonus;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        distance = ((distance + Time.deltaTime) + speedBonus/1000) % 1f;

        if (distance > 0.8)
        {
            distance = 0;
            transform.Rotate(0, 180, 0);
            transferLocation = location1;
            location1 = location2;
            location2 = transferLocation;
        }

        currentLocation.position = Vector3.Lerp(location1.position, location2.position, distance);
    }
}
