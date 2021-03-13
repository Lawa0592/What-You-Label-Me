using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/*
Introduction:
This script is responsible for receiving the request for the changing scenario and executing it
*/
public class sceneManager : MonoBehaviour
{
    void Awake() 
    {
        LoadSceneManager();
    }
    
    /*
        [FUNCTION] 
        1.Keep sceneManager(SM) stay when loading another scene
        2.Delete the old GM if there exsit an old SM in hierarchy. 
            Because only the first scene have the originally SM, 
            so when restart the whole game without quit the application, there will be two SM at the same time. 
    */
    void LoadSceneManager()
    {
        int num = 0;  //the numer of SM in the hierarchy
        List<GameObject> objList = new List<GameObject>();  //a list to store _Scene Manager

        //seek all object in hierarchy, find if there are multiple _Scene Manager
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.name == "_Scene Manager")
            {
                num++;
                objList.Add(obj);
            }

        }
        //if only one Game Manager, make this GM don't destory on load
        if (num < 2)
            DontDestroyOnLoad(this.gameObject);
        //if there are multiple Game Manager in scene
        else
        {
            Destroy(objList[0]);  //delete the old one,
            DontDestroyOnLoad(objList[1]);  //keep the newest one.
        }
    }

    /*
        [FUNCTION] 
        This is a message receiver to receiver changing scene request
    */
    void SceneReceiver(string sceneName)
    {
        changeScene(sceneName);
    }

    /*
        [FUNCTION] 
        Load scene according the transfer parameters(a scene name)
    */
    void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
