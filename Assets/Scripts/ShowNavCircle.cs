using UnityEngine;
using System.Collections;
using Vuforia;

public class ShowNavCircle : MonoBehaviour, ITrackableEventHandler
{

	private TrackableBehaviour mTrackableBehaviour;
     
    private bool mShowGUICircle = true;

    public GUIManager gm;


    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        gm.Hide_Navigation_Circle();
    }

  
     
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            Debug.Log("Found object");
            mShowGUICircle = false;
            OnGUI();
        }
        else
        {
            Debug.Log("No object");
            mShowGUICircle = true;
            OnGUI();
        }
    }

    void OnGUI() {
        if (gm.startracking) {
            if (mShowGUICircle) {
                gm.Show_Navigation_Circle();
            } else
            {
                gm.Hide_Navigation_Circle();
            }
        }
    }
    
}
