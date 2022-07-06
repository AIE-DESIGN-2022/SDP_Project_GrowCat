using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAnchor : MonoBehaviour
{
    public Transform itemBlock;

    // Update is called once per frame
    void Update()
    {
        if (itemBlock != null)
        {
            this.transform.position = itemBlock.position; //anchor this item to selected object 
        }
                 
    }
}
