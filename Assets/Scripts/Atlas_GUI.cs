using UnityEngine;
using System.Collections;

public class Atlas_GUI : MonoBehaviour {

    public AtlasBehaviour atlas;

    void Start()
    {

        this.gameObject.SetActive(false);
        atlas.gameObject.SetActive(false);
    }

    public void Show_Atlas()
    {

        Debug.Log("Show Atlas and its GUI");
        atlas.gameObject.SetActive(true);
        this.gameObject.SetActive(true);

    }

    public void Hide_Atlas()
    {
        Debug.Log("Hide Atlas and its GUI");
        atlas.Restore_Defaults();
        atlas.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
