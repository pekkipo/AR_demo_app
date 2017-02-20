using UnityEngine;
using System.Collections;

public class Kitten_GUI : MonoBehaviour {

    public KittenBehaviour kitten;

    void Start()
    {

        this.gameObject.SetActive(false);
        kitten.gameObject.SetActive(false);
    }

    public void Show_Kitten()
    {
        Debug.Log("Show Kitten and its GUI");
        kitten.gameObject.SetActive(true);
        this.gameObject.SetActive(true);

    }

    public void Hide_Kitten()
    {
        Debug.Log("Hide Kitten and its GUI");
        kitten.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
