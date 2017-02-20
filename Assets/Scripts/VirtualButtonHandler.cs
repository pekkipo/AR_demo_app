using UnityEngine;
using System.Collections;
using Vuforia;


public class VirtualButtonHandler : MonoBehaviour, IVirtualButtonEventHandler
{


    public InfoManager infomanager;
    public Info info;

    // Use this for initialization
    void Start()
    {
        // register buttons for event handling

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }

    }



    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)

    {

        Debug.Log("PRESSED", this.gameObject);

        if (vb.VirtualButtonName == "Show")
        {
            infomanager.ShowInfo(info);
        }

  
    }


    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {


        Debug.Log("RELEASE", this.gameObject);

        if (vb.VirtualButtonName == "Show")
        {

        }



    }


}


