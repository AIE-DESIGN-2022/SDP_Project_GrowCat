using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float speed;
    public float moveSpeed;
    private GameObject cat;

    public Transform point;
    public float x;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-6f, 6f);
        z = Random.Range(-6f, 6f);

        cat = GameObject.FindGameObjectWithTag("Cat");

        cat.GetComponent<LaserFollow>().laser = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        point.position = new Vector3(x, 0.5f, z);

        moveSpeed = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);

        if(transform.position.x > 4.3 || transform.position.x < -4.1 || transform.position.z > 4.2 || transform.position.z < -4.2 || transform.position == point.position)
        {
            x = Random.Range(-6f, 6f);
            z = Random.Range(-6f, 6f);
        }
    }
}
