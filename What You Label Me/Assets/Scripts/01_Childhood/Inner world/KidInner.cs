using UnityEngine;
/*
Introduction:
This script is responsible for managing the process of kid's inner world
*/
public class KidInner : MonoBehaviour
{
    public void Onclick()
    {
        //sending message to SceneManager to change the scene
        GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "00_corridor");
        GameManager.isDoor1Locked = true;
        GameManager.isDoor2Locked = false;   
    }
}
