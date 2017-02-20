using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tabs : MonoBehaviour {

    public Button[] tabs;
    public GameObject[] infoPanels;
    public ScrollRect scroll;
    

    public string sender;


    private int activeTab;

    Color32 blue_color = new Color32(45, 140, 231, 255);
    Color32 white_color = new Color32(255,255,255,255);
    Color32 lgrey_color = new Color32(204, 204, 204, 255);
    Color32 dgrey_color = new Color32(71, 71, 71, 255);


    public void Switch_Tabs(string name)
    {
        // Deal with the color of a tab
            foreach (Button button in tabs)

            //for( int idx = 0;idx<tabs.Length; ++idx)
            {
            
            int index = System.Array.IndexOf(tabs, button);
            Text text = button.GetComponentInChildren<Text>();
            
            Debug.Log("INDEX IS " + index.ToString());

                if (button.CompareTag(name)) // not the best idea to use tags here
                {
                    Debug.Log("Chosen index is " + index.ToString());
                    //button.image.color = white_color;
                    text.color = blue_color;
                     GameObject line = button.transform.Find("Line").gameObject;
                     line.GetComponent<Image>().color = blue_color;
                    

                // Show-Hide required Info
                for (int i = 0; i < infoPanels.Length; i++)
                {

                    if (i == index)
                    {
                        infoPanels[i].SetActive(true);

                        // Switch the panel assigned to a Scrollbar
                        RectTransform recttransform = infoPanels[i].GetComponent<RectTransform>();
                        Debug.Log("Got the rect transform for panel: " + infoPanels[i]);
                        scroll.content = recttransform;
                    }
                    else
                    {
                        infoPanels[i].SetActive(false);
                    }
                }

                

            } else
                {
                
                //button.image.color = blue_color;
                text.color = dgrey_color;
                GameObject line = button.transform.Find("Line").gameObject;
                line.GetComponent<Image>().color = lgrey_color;
                //infoPanels[index].SetActive(true);

            }

          
        }

    }


	// Use this for initialization
	void Start () {

        if (sender == "Info")
        {
            Switch_Tabs("InfoTab");
        }
        else if (sender == "Contacts")
        {
            Switch_Tabs("ContactsTab");
        }
        else if (sender == "Help")
        {
            Switch_Tabs("MenuhelpTab");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
