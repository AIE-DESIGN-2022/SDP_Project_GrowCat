using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.forward = cameraObject.transform.forward;
    }
}
