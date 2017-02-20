using UnityEngine;
using System.Collections;

public class InfoManager : MonoBehaviour {

    public Info CurrentInfo;
    // make it public in order to set the default info in inspector

    public void Start()
    {
       // ShowInfo(CurrentInfo);
    }




    public void ShowInfo(Info info)
    {

        CurrentInfo = info;
        CurrentInfo.isShown = true;

        CurrentInfo.ChangeAlpha(1);

        Debug.Log("SHOW PRESSED");

    }

    public void HideInfo (Info info)
    {
        
        CurrentInfo.isShown = false;

        CurrentInfo.ChangeAlpha(0);

        Debug.Log("HIDE PRESSED");
    }
}
