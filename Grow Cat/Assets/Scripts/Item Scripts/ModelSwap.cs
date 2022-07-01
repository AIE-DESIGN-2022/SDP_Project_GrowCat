using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwap : MonoBehaviour
{
    public GameObject[] models;
    ItemPhase itemPhase;

    // Start is called before the first frame update
    void Start()
    {
        itemPhase = GetComponent<ItemPhase>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateModel(int level)
    {

    }
}
