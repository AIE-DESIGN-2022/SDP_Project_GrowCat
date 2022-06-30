using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public ItemPhase[] items;
    public int itemsMaxed, buttonsClicked;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(items.Length);
    }

    // Update is called once per frame
    void Update()
    {

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
                    // Debug.Log(item.gameObject.name);
                    item.LevelUp();
                }
            }
        } 
    }
}
