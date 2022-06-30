using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    ItemPhase[] items;
    

    // Start is called before the first frame update
    void Start()
    {
        items = FindObjectsOfType<ItemPhase>();
        Debug.Log(items.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            LevelUpAll();
        }
    }

    public void LevelUpAll()
    {
        Debug.Log("Level up all on scene");

        //run this for every item possible
       foreach(ItemPhase item in items)
       {
            //if the object has been set to active
            if(item.gameObject.activeInHierarchy)
            {
               // Debug.Log(item.gameObject.name);
                item.LevelUp();
            }
            
       }
    }
}
