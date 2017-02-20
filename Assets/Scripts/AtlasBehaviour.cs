using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AtlasBehaviour : MonoBehaviour {

    public GUIManager gm;

    private GameObject points_canvas;

    #region POI's definiton
    //public GameObject poi_gui;

    public Text caption;
    public Text content;

    private struct POI_content
    {
        public string title;
        public string content;
    };

    private string[] titles = new string[] { "Rocket engine nozzle", "Turbine Vault"};

    private string[] texts = new string[]
    { string.Format("The optimal size of a rocket engine nozzle to be used within the atmosphere is achieved when the exit pressure equals ambient (atmospheric) pressure, which decreases with altitude. For rockets travelling from the Earth to orbit, a simple nozzle design is only optimal at one altitude, losing efficiency and wasting fuel at other altitudes.{0} Slight overexpansion causes a slight reduction in efficiency, but otherwise does little harm. However, if the exit pressure is less than approximately 40% that of ambient, then flow separation occurs. This can cause jet instabilities that can cause damage to the nozzle or simply cause control difficulties of the vehicle or the engine. {1} In some cases it is desirable for reliability and safety reasons to ignite a rocket engine on the ground that will be used all the way to orbit. For optimal liftoff performance, the pressure of the gases exiting nozzle should be at sea-level pressure; however, if a rocket engine is primarily designed for use at high altitudes and is only providing additional thrust to another first - stage engine during liftoff in a multi-stage design, then designers will usually opt for an overexpanded nozzle (at sea-level) design, making it more efficient at higher altitudes, where the ambient pressure is lower. This was the technique employed on the Space shuttle's main engines, which spent most of their powered trajectory in near-vacuum, while the shuttle's two solid rocket boosters provided the majority of the liftoff thrust.{2}", Environment.NewLine, Environment.NewLine, Environment.NewLine),
       string.Format("The optimal size of a rocket engine nozzle to be used within the atmosphere is achieved when the exit pressure equals ambient (atmospheric) pressure, which decreases with altitude. For rockets travelling from the Earth to orbit, a simple nozzle design is only optimal at one altitude, losing efficiency and wasting fuel at other altitudes.{0} Slight overexpansion causes a slight reduction in efficiency, but otherwise does little harm. However, if the exit pressure is less than approximately 40% that of ambient, then flow separation occurs. This can cause jet instabilities that can cause damage to the nozzle or simply cause control difficulties of the vehicle or the engine. {1} In some cases it is desirable for reliability and safety reasons to ignite a rocket engine on the ground that will be used all the way to orbit. For optimal liftoff performance, the pressure of the gases exiting nozzle should be at sea-level pressure; however, if a rocket engine is primarily designed for use at high altitudes and is only providing additional thrust to another first - stage engine during liftoff in a multi-stage design, then designers will usually opt for an overexpanded nozzle (at sea-level) design, making it more efficient at higher altitudes, where the ambient pressure is lower. This was the technique employed on the Space shuttle's main engines, which spent most of their powered trajectory in near-vacuum, while the shuttle's two solid rocket boosters provided the majority of the liftoff thrust.{2}", Environment.NewLine, Environment.NewLine, Environment.NewLine)
    };

    POI_content poi1;
    POI_content poi2;

    #endregion

    private GameObject points;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0, 0, 0);
        // this.gameObject.SetActive(false);


        //points_canvas = transform.Find("Points").gameObject;
        

        poi1.title = titles[0];
        poi1.content = texts[0];

        poi2.title = titles[1];
        poi2.content = texts[1];

        points = transform.FindChild("Points").gameObject;
        Debug.Log(points);
        Show_Poi();

    }
	
	// Update is called once per frame
	void Update () {

  
	}

    public void Restore_Defaults()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(0.0001638961f, 0.0001638961f, 0.0001638961f);
        transform.rotation = new Quaternion(-90f, -360f, -360f, 0f);

    }

  

    public void Show_POI_Info(int poi)
    {

        gm.Show_POI();

        if (poi == 1) { // POI.P1 - wont work in Unity
            caption.text = poi1.title;
            content.text = poi1.content;
        }
        else if (poi == 2)
        {
            caption.text = poi2.title;
            content.text = poi2.content;
        }

        turnoff_touch();
    }

    public void Hide_POI_Info()
    {
        gm.Hide_POI();
        turnon_touch();
    }

    private bool poi_on = false;

    public void Show_Poi()
    {
        if (poi_on)
        {
            CanvasGroup cg = points.GetComponent<CanvasGroup>();
            cg.alpha = 1;
            cg.blocksRaycasts = true;
            poi_on = false;
        }
        else
        {
            CanvasGroup cg = points.GetComponent<CanvasGroup>();
            cg.alpha = 0;
            cg.blocksRaycasts = false;
            poi_on = true;
        }
    }


    public void turnon_touch()
    {
        SimpleSelectTransform sst = transform.GetComponent<SimpleSelectTransform>();
        sst.enabled = true;
    }

    public void turnoff_touch()
    {
        SimpleSelectTransform sst = transform.GetComponent<SimpleSelectTransform>();
        sst.enabled = false;
    }
   
}
