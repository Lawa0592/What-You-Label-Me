using UnityEngine;
/*
[Using in scene '04_school_inner']
Introduction:
This script is responsible for managing the process of high school's inner world
*/
public class SchoolInner : MonoBehaviour
{
    public void Onclick()
    {
        //sending message to SceneManager to change the scene
        GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "00_corridor");
        GameManager.isDoor2Locked = true;
        GameManager.isDoor3Locked = false;
    }
}
