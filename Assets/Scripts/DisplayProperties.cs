using UnityEngine;
using System.Collections;
using System;
using Vuforia;
using System.Collections.Generic;

public class DisplayProperties : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowGUICircle = true;
    public f_GUIManager gm;

    void Start()
    {
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
            //OnTrackingFound();
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

   public void OnGUI()//OnGUI()
    {
        if (gm.startracking)
        {
            if (mShowGUICircle)
            {
                gm.Show_Navigation_Circle();
                gm.Hide_Chair_GUI();
            }
            else
            {
                gm.Hide_Navigation_Circle();
                gm.Show_Chair_GUI();
            }
        }
        
    }

    public void OnTrackingFound()
    {
        Vector2 trackedCloudImageWH = GameObject.Find("ImageTarget").GetComponent<ImageTargetAbstractBehaviour>().GetSize();
        Debug.Log("============= SIZE  " + trackedCloudImageWH.ToString());

        //float[] arr = new float[3] { trackedCloudImageWH.x, trackedCloudImageWH.y, trackedCloudImageWH.x } ; 

        //chair.Adjust_Size()
    }

   
}
