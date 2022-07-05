using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPhase : MonoBehaviour
{
    //Levelling
    
    public int maxLevel;
    public int currentLevel = 1;
    public LevelUpManager levelUpManager;

    //modelling
    ModelSwap modelSwap;
    GameObject model;
    PositionAnchor positionAnchor;

    // Start is called before the first frame update
    void Start()
    {
        modelSwap = GetComponent<ModelSwap>(); //grab the model swap component on this item
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelUp() //level up the item
    {
        //check the item hasnt reached max level yet
        if(currentLevel < maxLevel)
        {
            currentLevel++;
            StartCoroutine(InstantiateModel(0.5f));
        }
    }

    
    public IEnumerator InstantiateModel(float seconds) //changes the prefab everytime it levels up and spawns it originally
    {
        yield return new WaitForSeconds(seconds);

        //check there is still a model available
        if(currentLevel < modelSwap.models.Length)
        {
            Destroy(model); //clear previous model
            model = Instantiate(modelSwap.models[currentLevel].gameObject); //create this objects model at it's current level
            positionAnchor = model.GetComponentInParent<PositionAnchor>(); //grab the model's anchor script
            positionAnchor.itemBlock = this.gameObject.transform; //assign the item's location as the models location
            ShowPop();
        }
    }

    public void ShowPop() //Show a cloud animation over the transformation
    {
        int randomPop = Random.Range(0, levelUpManager.pops.Length); //pick a random pop

        GameObject pop = Instantiate(levelUpManager.pops[randomPop].gameObject); //create the pop
        positionAnchor = pop.GetComponentInParent<PositionAnchor>(); //grap the pop's anchor script
        positionAnchor.itemBlock = model.gameObject.transform; //assing the items location as the pops location

        
    }

    public void SpawnOnMap() //spawn the item on the map
    {
        levelUpManager.buttonsClicked++; //tell system we've clicked a button
        levelUpManager.LevelUpAll(); //level up all objects on the map
        this.gameObject.SetActive(true); //bring this item onto the map
        StartCoroutine(InstantiateModel(0.5f));

        //check if all buttons are clicked
        if (levelUpManager.buttonsClicked == 6)
        {
            StartCoroutine(CalculateResult(1));
        } 
    }

    public IEnumerator CalculateResult(float seconds) //calculate final result *is often wrong*
    {
        yield return new WaitForSeconds(seconds);
        levelUpManager.CheckForMaxed(); //system counts how many are maxed out
        levelUpManager.ShowResult(); //System Shows result
    }
    //bum
}
