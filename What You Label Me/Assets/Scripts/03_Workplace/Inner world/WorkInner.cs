using UnityEngine;
/*
[Using in scene '06_work_inner']
Introduction:
This script is responsible for managing the process of working period's inner world
*/
public class WorkInner : MonoBehaviour
{
    public void Onclick()
    {
        //sending message to SceneManager to change the scene
        GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "00_corridor");
        GameManager.isDoor3Locked = true;
        GameManager.isDoor4Locked = false;
    }
}
