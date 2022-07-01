using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPhase : MonoBehaviour
{
    public int maxLevel;
    public int currentLevel = 1;

    public LevelUpManager levelUpManager;
    ModelSwap modelSwap;
    GameObject model;
    PositionAnchor positionAnchor;

    // Start is called before the first frame update
    void Start()
    {
        modelSwap = GetComponent<ModelSwap>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelUp()
    {
        //check the item hasnt reached max level yet
        if(currentLevel < maxLevel)
        {
            currentLevel++;
            StartCoroutine(InstantiateModel(0.5f));
        }
    }

    public IEnumerator InstantiateModel(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        //check there is still a model available
        if(currentLevel < modelSwap.models.Length)
        {
            Destroy(model); //clear previous model
            model = Instantiate(modelSwap.models[currentLevel].gameObject); //create this objects model at it's current level
            positionAnchor = model.GetComponentInParent<PositionAnchor>(); //grab the model's anchor script
            positionAnchor.itemBlock = this.gameObject.transform; //assign the item's location as the models location
        }
    }

    public void SpawnOnMap()
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

    public IEnumerator CalculateResult(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        levelUpManager.CheckForMaxed(); //system counts how many are maxed out
        levelUpManager.ShowResult(); //System Shows result
    }
}
