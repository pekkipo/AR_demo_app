using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chair_GUI : MonoBehaviour {

    public FurnitureBehaviour[] furnitureitems;

    private Animator menuanimator;

    // Use this for initialization
    void Start () {
	
        foreach (FurnitureBehaviour item in furnitureitems)
        {
            item.gameObject.SetActive(false);
        }

        GameObject animatedmenu = this.transform.Find("ChooseMenu").gameObject;
        if (animatedmenu != null)
        {
            Debug.Log("=============== FOUND ANIMATOR =============");
            menuanimator = animatedmenu.GetComponent<Animator>();
            menuanimator.SetBool("IsOpen", false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    

    public void Show_Item(int itemnumber)
    {

        Debug.Log("Show item " + itemnumber.ToString());
        furnitureitems[itemnumber].gameObject.SetActive(true);
        /*
        if (!furnitureitems[itemnumber].isActiveAndEnabled)
        {
            Debug.Log("PlaceItem");
            furnitureitems[itemnumber].gameObject.SetActive(true);
        } else
        {
            Debug.Log("RemoveItem");
            furnitureitems[itemnumber].Restore_Defaults();
            Hide_Item(itemnumber);
        }
        */
        foreach (FurnitureBehaviour item in furnitureitems)
        {
          

                int index = System.Array.IndexOf(furnitureitems, item);
             if (index != itemnumber && item.isActiveAndEnabled)
             {
                SimpleDrag SD = item.GetComponent<SimpleDrag>();
                SimpleSelectTransform SST = item.GetComponent<SimpleSelectTransform>();

                SD.enabled = false;
                SST.enabled = false;
                } else
             {
                SimpleDrag SD = item.GetComponent<SimpleDrag>();
                SimpleSelectTransform SST = item.GetComponent<SimpleSelectTransform>();

                SD.enabled = true;
                SST.enabled = true;


                }
           
        }

        
    }

    public void Hide_Item(int itemnumber)
    {
       // Debug.Log("Hide item " + itemnumber.ToString());
        furnitureitems[itemnumber].gameObject.SetActive(false);

        foreach (FurnitureBehaviour item in furnitureitems)
        {
            int index = System.Array.IndexOf(furnitureitems, item);
            if (index == itemnumber && item.isActiveAndEnabled)
            {
                SimpleDrag SD = item.GetComponent<SimpleDrag>();
                SimpleSelectTransform SST = item.GetComponent<SimpleSelectTransform>();

                SD.enabled = false;
                SST.enabled = false;
            }
        }
    }

    public void Forbid_Scaling()
    {
        foreach (FurnitureBehaviour item in furnitureitems)
        {
            SimpleSelectTransform SST = item.GetComponent<SimpleSelectTransform>();
            SST.AllowScale = false;
        }
    }

    public void Allow_Scaling()
    {
        foreach (FurnitureBehaviour item in furnitureitems)
        {
            SimpleSelectTransform SST = item.GetComponent<SimpleSelectTransform>();
            SST.AllowScale = true;
        }
    }
}
