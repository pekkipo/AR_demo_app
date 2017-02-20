using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    AsyncOperation ao;
    //
   // public Slider progBar;

    public Slider[] progBars;


    public void LoadLevel(string name)
    {
        Debug.Log(name);

        if (name == "2DTracking")
        {
            progBars[0].gameObject.SetActive(true);
        }
        else if (name == "FurnitureScene")
        {
            progBars[1].gameObject.SetActive(true);
        }
        else if (name == "InformationScene")
        {
            progBars[2].gameObject.SetActive(true);
        }
        else if (name == "ContactsScene")
        {
            progBars[3].gameObject.SetActive(true);
        }
        //progBar.gameObject.SetActive(true);

        StartCoroutine(LoadLevelWithRealProgress(name));

    }


    IEnumerator LoadLevelWithRealProgress(string levelname)
    {
        yield return new WaitForSeconds(1);


        // ao = SceneManager.LoadSceneAsync(1); //LoadSceneAsync(1);
        ao = SceneManager.LoadSceneAsync(levelname);
        ao.allowSceneActivation = false; // not necessary - only if you want to show some info before showing the next scene

        while(!ao.isDone)
        {
            if (levelname == "2DTracking")
            {
                progBars[0].value = ao.progress;

            } else if (levelname == "FurnitureScene")
            {
                progBars[1].value = ao.progress;

            } else if (levelname == "InformationScene")
            {
            progBars[2].value = ao.progress;
            }
            else if (levelname == "ContactsScene")
            {
                progBars[3].value = ao.progress;
            }

            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;

            }

            Debug.Log("PROGRESS IS" + ao.progress);
            yield return null;
        }

       
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}