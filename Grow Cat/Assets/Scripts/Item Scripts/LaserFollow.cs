using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollow : MonoBehaviour
{
    public float speed;
    public float walk;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laser != null)
        {
            walk = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, laser.transform.position, speed);
        }
    }
}
