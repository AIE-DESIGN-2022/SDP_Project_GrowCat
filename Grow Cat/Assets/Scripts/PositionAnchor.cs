using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAnchor : MonoBehaviour
{
    public Transform itemBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = itemBlock.position; //anchor this item to selected object
    }
}
