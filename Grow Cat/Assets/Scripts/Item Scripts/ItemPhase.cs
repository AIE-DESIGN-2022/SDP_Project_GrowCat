using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPhase : MonoBehaviour
{
    public float maxLevel;
    public float currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = new Vector3(currentLevel / 2, currentLevel / 2, currentLevel / 2);
        this.transform.localScale = scale;
    }

    public void LevelUp()
    {
        //check the item hasnt reached max level yet
        if(currentLevel < maxLevel)
        {
            currentLevel++;
        }
    }
}
