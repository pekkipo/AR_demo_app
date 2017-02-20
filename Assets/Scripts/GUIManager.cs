using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    // MAIN MENU
    public GameObject menu;
    private GameObject menubg; // stupid way..shaaaame
    private CanvasGroup canvasGroup;
    private Animator menuanimator;

    // Buttons
    private Button closemenu;
    private Button openmenu;

    // GUIs
    public Kitten_GUI kitten_gui;
    public Atlas_GUI atlas_gui;

    public GameObject navCircle;
    public bool startracking = false; // stupid way! but should work

    public GameObject POI;
    public GameObject Info;

    enum Top_Buttons { Back, Menu, Close };


    // Use this for initialization
    void Start()
    {

        // Place info panel at the center of a canvas 
        var rect = Info.GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);

        Hide_info();

        closemenu = GameObject.Find("CloseMenu").GetComponent<Button>();
        openmenu = GameObject.Find("OpenMenu").GetComponent<Button>();
        openmenu.gameObject.SetActive(false);
        closemenu.gameObject.SetActive(true);
        Hide_Navigation_Circle();
        Hide_POI();

        Debug.Log("Turn off the POI");

        GameObject animatedmenu = menu.transform.Find("AnimatedMenu").gameObject;
        if ( animatedmenu != null )
        {
            Debug.Log("=============== FOUND ANIMATOR =============");
            menuanimator = animatedmenu.GetComponent<Animator>();
            menuanimator.SetBool("IsOpen", true);
        }

        canvasGroup = menu.GetComponent<CanvasGroup>();

        menubg = menu.transform.Find("BG").gameObject;

        
    }

    public void Update()
    {
        // Switch off the Menu interactability because it blocks other interfaces and I can't
        // properly set it as inactive
        if (!menuanimator.GetCurrentAnimatorStateInfo(0).IsName("Main Menu Open"))
        {
            // case if the menu is open now
            canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
        } else
        {
            // if the menu is closed
            canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
        }
    }


    public void Display_Kitten()
    {
        Close_Menu();
        Show_Navigation_Circle();
        kitten_gui.Show_Kitten();
        if (atlas_gui.isActiveAndEnabled) {
            atlas_gui.Hide_Atlas();
        }

        startracking = true;
    }


    public void Display_Atlas()
    {
       Close_Menu();
       Show_Navigation_Circle();
       atlas_gui.Show_Atlas();
        if (kitten_gui.isActiveAndEnabled)
        {
            kitten_gui.Hide_Kitten();
        }

        startracking = true;
    }

    private void Switch_Top_Buttons(Top_Buttons button)
    {
        if (button == Top_Buttons.Menu)
        {
            openmenu.gameObject.SetActive(false);
            closemenu.gameObject.SetActive(true);
        }
        else if (button == Top_Buttons.Close)
        {
            openmenu.gameObject.SetActive(true);
            closemenu.gameObject.SetActive(false);
        }
    }

    public void SlideMenu()
    {
        if (menuanimator.GetCurrentAnimatorStateInfo(0).IsName("Main Menu Open"))
        {
            menuanimator.SetBool("IsOpen", false);
            menubg.SetActive(false);
        } else
        {
            menuanimator.SetBool("IsOpen", true);
            menubg.SetActive(true);
        }
    }
   
    public void Show_Menu()
    {
        // menu.SetActive(true); Instead there will be a nice animation

        SlideMenu();
        Switch_Top_Buttons(Top_Buttons.Menu);
        Hide_Navigation_Circle();
        startracking = false; // BE CAREFUL HERE
    }

    public void Close_Menu()
    {
        SlideMenu();
        //menu.SetActive(false);
        Switch_Top_Buttons(Top_Buttons.Close);
    }

    public void Show_POI()
    {
        Hide_Navigation_Circle();
        POI.SetActive(true);
    }

    public void Hide_POI()
    {
        POI.SetActive(false);
    }

    public void Show_Navigation_Circle()
    {

        navCircle.SetActive(true);
    }

    public void Hide_Navigation_Circle()
    {
        navCircle.SetActive(false);
    }

    public void Show_info()
    {
        atlas_gui.atlas.turnoff_touch(); // Turn off the ability to use touch gestures
        Hide_Navigation_Circle();
        Info.SetActive(true);
    }

    public void Hide_info()
    {
        atlas_gui.atlas.turnon_touch(); // Turn back on the ability to use touch gestures
        Info.SetActive(false);
    }

    

}
