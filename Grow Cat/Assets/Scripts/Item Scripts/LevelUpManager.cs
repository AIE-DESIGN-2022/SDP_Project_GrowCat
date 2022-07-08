using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public ItemPhase[] items;
    public int itemsMaxed, buttonsClicked;
    public GameObject[] pops;
    public GameObject[] extras;
    BallScript ballScript;

    public void FindBall() //find the Ball object when it appears
    {
        ballScript = FindObjectOfType<BallScript>();
    }

    public void LevelUpAll()
    {
        if (items != null)
        {
            //run this for every item possible
            foreach (ItemPhase item in items)
            {
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
                 if (!ballScript.BallHitFish) //if the fish was not raised, it cannot be maxed
                 {
                        item.currentLevel--;
                 }

                 if(item.currentLevel <= 0) //dont let the score drop into negatives.
                 {
                        item.currentLevel = 0;
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

        if(itemsMaxed == 6)
            {
                foreach(GameObject extra in extras)
                {
                    float x = Random.Range(-4, 2);
                    float z = Random.Range(0, -5);
                    Vector3 pos = new Vector3(x, 1, z);
                    Instantiate(extra, pos, extra.transform.rotation);
                }
            }
    }

    public void CheckForMaxed()
    {
        foreach(ItemPhase item in items)
        {
            if(item.currentLevel == item.maxLevel) //for every item, check if their current level is their max level
            {
                itemsMaxed++;  
            }
        }
    }
}
