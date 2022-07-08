using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public ItemPhase[] items;
    public int itemsMaxed, buttonsClicked;
    public GameObject[] pops;
    BallScript ballScript;

    public void FindBall() //find the Ball object when it appears
    {
        ballScript = FindObjectOfType<BallScript>();
    }

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
        foreach(ItemPhase item in items)
        {
            if (item.gameObject.name == "Object_Fish") //check fish has been raised
            {
                 if (!ballScript.BallHitFish)
                    {
                        item.currentLevel--;
                    }
            }

            if(item.currentLevel == item.maxLevel) //display on the buttonText that the object is at max level
            {
                item.buttonText.text = "Max Level";
            }

            else //otherwise display its current level
            {
                item.buttonText.text = "Level " + item.currentLevel.ToString();
            }
        }
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
