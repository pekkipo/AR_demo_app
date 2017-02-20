using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class f_GUIManager : MonoBehaviour {

    // Access to the Furniture menu systems
    public Chair_GUI chair_gui;
    
    // Buttons
    public Button choose_items_button;
    public Button scale_button;
    [Header("Sprites")]
    [Tooltip("1 - Off/2 - On")]
    public Sprite[] ScalingSprites;

    // Auxilary elements
    public GameObject navCircle;
    public GameObject info;

    public bool startracking = false;

    //Animators
    private Animator chooseitemanimator;
    private Animator choosesettingsanimator;
    private Animator removeitemsanimator;



    // Initialize this in start
    private struct SubAnimationStates
    {
        public int[] IdleStates;
        public int[] ShowStates;
        public int[] HideStates;
        public string[] BaseBools; // Booleans to get into a certain Sub-State
        public string[] ShowBools; // Booleans to change states within a Sub-State

        public SubAnimationStates(int[] Idles, int[] Shows, int[] Hides, string[] Show_Bools, string[] Base_Bools)
        {
            IdleStates = Idles;
            ShowStates = Shows;
            HideStates = Hides;
            ShowBools = Show_Bools;
            BaseBools = Base_Bools;
        }
    };

    private SubAnimationStates States;



    void Start() {

        // Place info panel at the center of a canvas 
        var rect = info.GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);

        Hide_Navigation_Circle();
        Hide_info();

        GameObject chooseitemmenu = chair_gui.transform.Find("ChooseMenu").gameObject;
        if (chooseitemmenu != null)
        {
            Debug.Log("=============== FOUND NEW ANIMATOR =============");
            chooseitemanimator = chooseitemmenu.GetComponent<Animator>();
            chooseitemanimator.SetBool("IsOpen", false);
        }

        GameObject choosesettingsmenu = chair_gui.transform.Find("Settings").gameObject;
        if (choosesettingsmenu != null)
        {
            Debug.Log("=============== FOUND NEW ANIMATOR =============");
            choosesettingsanimator = choosesettingsmenu.GetComponent<Animator>();
            choosesettingsanimator.SetBool("IsOpen", false);
        }

        // Find animator for the remove buttons
        GameObject removeitemsmenu = chair_gui.transform.Find("RemoveItems").gameObject;
        if (removeitemsmenu != null)
        {
            Debug.Log("=============== FOUND NEW ANIMATOR =============");
            removeitemsanimator = removeitemsmenu.GetComponent<Animator>();

        }

        int[] IdleStates = {
        Animator.StringToHash("Base Layer.Chair.c_Idle"),
        Animator.StringToHash("Base Layer.Desk.d_Idle"),
        Animator.StringToHash("Base Layer.Lamp.l_Idle")
        };
        int[] ShowStates = {
        Animator.StringToHash("Base Layer.Chair.c_Show"),
        Animator.StringToHash("Base Layer.Desk.d_Show"),
        Animator.StringToHash("Base Layer.Lamp.l_Show")
        };
        int[] HideStates = {
        Animator.StringToHash("Base Layer.Chair.c_Hide"),
        Animator.StringToHash("Base Layer.Desk.d_Hide"),
        Animator.StringToHash("Base Layer.Lamp.l_Hide")
        };
        string[] ShowBools =
        {
        "chair_isShown",
        "desk_isShown",
        "lamp_isShown",
        };
        string[] BaseBools =
       {
        "ChairOpened",
        "DeskOpened",
        "LampOpened",
        };

        States = new SubAnimationStates(IdleStates, Shows: ShowStates, Hides: HideStates, Show_Bools: ShowBools, Base_Bools: BaseBools);

    }

    // Update is called once per frame
    public void Update()
    {


    }


    private void Hide_Settings_Menu()
    {
        if (choosesettingsanimator.GetCurrentAnimatorStateInfo(0).IsName("ShowSettings"))
        {
            choosesettingsanimator.SetBool("IsOpen", false);
        }

        Hide_Remove_Buttons();
    }

    private void Hide_Items_Menu()
    {
        if (chooseitemanimator.GetCurrentAnimatorStateInfo(0).IsName("ShowItems"))
        {
            chooseitemanimator.SetBool("IsOpen", false);
        }

        // Hide all remove buttons also
        Hide_Remove_Buttons();
    }

    private void Hide_Remove_Buttons()
    {
        for (int i = 0; i < 3; i++)
        {
                removeitemsanimator.SetBool(States.ShowBools[i], false);
                removeitemsanimator.SetBool(States.BaseBools[i], false);
        }
    }

    public void ChooseFurniture()
    {
        // Close Settings Menu in case it is open 
        Hide_Settings_Menu();
        // Deal with furniture choosing menu
        if (chooseitemanimator.GetCurrentAnimatorStateInfo(0).IsName("HideItems"))
        {
            chooseitemanimator.SetBool("IsOpen", true);
        }
        else if (chooseitemanimator.GetCurrentAnimatorStateInfo(0).IsName("ShowItems"))
        {
            chooseitemanimator.SetBool("IsOpen", false);

        } else if  (chooseitemanimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        { 
            chooseitemanimator.SetBool("IsOpen", true);

        }
    }

    public void ChooseSettings()
    {
        // Close Settings Menu in case it is open 
        Hide_Items_Menu();
        // Deal with furniture choosing menu
        if (choosesettingsanimator.GetCurrentAnimatorStateInfo(0).IsName("HideSettings"))
        {
            choosesettingsanimator.SetBool("IsOpen", true);
        }
        else if (choosesettingsanimator.GetCurrentAnimatorStateInfo(0).IsName("ShowSettings"))
        {
            choosesettingsanimator.SetBool("IsOpen", false);

        }
        else if (choosesettingsanimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            choosesettingsanimator.SetBool("IsOpen", true);

        }
    }

    public void Show_Remove_Buttons(int itemnumber)
    {

            AnimatorStateInfo currentState = removeitemsanimator.GetCurrentAnimatorStateInfo(0);

        for (int i = 0; i < 3; i++)
        {
            if (i == itemnumber)
            {
                removeitemsanimator.SetBool(States.BaseBools[i], true);
            } else
            {
                removeitemsanimator.SetBool(States.BaseBools[i], false);

               
            }
        }
            Debug.Log(currentState.shortNameHash);
            
            removeitemsanimator.SetBool(States.ShowBools[itemnumber], true);
            Debug.Log("First Idle -> Show" + States.ShowBools[itemnumber]);

            if (currentState.fullPathHash == States.IdleStates[itemnumber])
            {
                Debug.Log("Idle -> Show" + States.ShowBools[itemnumber]);
                removeitemsanimator.SetBool(States.ShowBools[itemnumber], true);

            }
            else if (currentState.fullPathHash == States.ShowStates[itemnumber])
            {
                Debug.Log("Show -> Hide" + States.ShowBools[itemnumber]);
                removeitemsanimator.SetBool(States.ShowBools[itemnumber], false);
            }
            else if (currentState.fullPathHash == States.HideStates[itemnumber])
            {
                Debug.Log("Hide -> Show" + States.ShowBools[itemnumber]);
                removeitemsanimator.SetBool(States.ShowBools[itemnumber], true);
            }

  

    }


    public void Hide_Furniture_Item(int itemnumber)
    {
        chair_gui.Hide_Item(itemnumber);
        Show_Remove_Buttons(itemnumber);
    }

    public void Show_Furniture_Item(int itemnumber)
    {

        // Show remove button
        // Small and lame workaround in order to avoid hiding remove button when tapping the 
        // furniture button again
        AnimatorStateInfo currentState = removeitemsanimator.GetCurrentAnimatorStateInfo(0);

        if (currentState.fullPathHash != States.ShowStates[itemnumber])
        {
            Show_Remove_Buttons(itemnumber);
        }

        Show_Navigation_Circle();
        chair_gui.Show_Item(itemnumber);
        startracking = true;

        // get the button that was clicked and change choose_items button image to it
        GameObject go_button = EventSystem.current.currentSelectedGameObject;
        Image currentimage = go_button.GetComponent<Image>(); // get button's image component
        Sprite sprite = currentimage.sprite; // get this image's sprite
        Debug.Log("Image is " + currentimage);
        Debug.Log("Button is " + choose_items_button);

        choose_items_button.image.sprite = sprite; // assign the aforementioned sprite to the button

        
    }

    public void Show_Chair_GUI()
    {
        chair_gui.gameObject.SetActive(true);
    }

    public void Hide_Chair_GUI()
    {
        chair_gui.gameObject.SetActive(false);

    }

    public void Show_Navigation_Circle()
    {
        if (navCircle != null) {
            navCircle.SetActive(true);
        }
    }

    public void Hide_Navigation_Circle()
    {
        navCircle.SetActive(false);
    }

    public void Show_info()
    {
        Hide_Navigation_Circle();
        info.SetActive(true);
        Hide_Settings_Menu();
    }

    public void Hide_info()
    {
        info.SetActive(false);
    }

    public void RestoreAllDefaults()
    {

        foreach (FurnitureBehaviour furniture in FindObjectsOfType<FurnitureBehaviour>())
        {
            print("OBJECTS ARE: " + furniture);
            furniture.Restore_Defaults();
        }
    }

    //enum Scale { Yes, No };
    private bool scale = true;
    public void Switch_Scaling()
    {
        if (scale) {
            // forbid scaling
            Debug.Log("Forbid Scaling");
            chair_gui.Forbid_Scaling();

            // change picture
            scale_button.image.sprite = ScalingSprites[0];

            scale = false;
        } else {
            // allow scaling
            Debug.Log("Allow Scaling");
            chair_gui.Allow_Scaling();

            // change picture 
            scale_button.image.sprite = ScalingSprites[1];

            scale = true;
        }
    }





}

        