using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public ItemPhase[] items;
    public int itemsMaxed, buttonsClicked;
    public GameObject[] pops;

    public void LevelUpAll()
    {
       if(items != null)
        {
            //run this for every item possible
            foreach (ItemPhase item in items)
            {
                //if the object has been set to active
                if (item.gameObject.activeInHierarchy)
                {
                    item.LevelUp();
                }
            }
        } 
    }

    public void ShowResult()
    {
        Debug.Log("You got " + itemsMaxed + "/6!");
    }

    public void CheckForMaxed()
    {
        //itemsMaxed = 0; //system starts at 0 when checking

        foreach(ItemPhase item in items)
        {
            if(item.currentLevel == item.maxLevel) //for every item, check if their current level is their max level
            {
                itemsMaxed++;  
            }
        }
    }
}
