using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    PositionAnchor positionAnchor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TurnOffAnchor());
        IEnumerator TurnOffAnchor()
        {
            yield return new WaitForSeconds(0.2f);
            positionAnchor = GetComponent<PositionAnchor>();
            positionAnchor.enabled = false;
            
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
