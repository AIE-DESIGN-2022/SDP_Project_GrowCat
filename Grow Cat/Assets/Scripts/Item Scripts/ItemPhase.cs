using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPhase : MonoBehaviour
{
    public float maxLevel;
    public float currentLevel = 1;

    public LevelUpManager levelUpManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //remove this later
        Vector3 scale = new Vector3(currentLevel / 2, currentLevel / 2, currentLevel / 2);
        this.transform.localScale = scale;
        //remove this later end.
    }

    public void LevelUp()
    {
        //check the item hasnt reached max level yet
        if(currentLevel < maxLevel)
        {
            currentLevel++;
        }
    }

    public void SpawnOnMap()
    {
        levelUpManager.buttonsClicked++;
        levelUpManager.LevelUpAll(); //level up all objects on the map
        this.gameObject.SetActive(true); //bring this item onto the map
     
    }


}
