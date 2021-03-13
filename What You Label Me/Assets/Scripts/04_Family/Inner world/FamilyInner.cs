using UnityEngine;
/*
Introduction:
This script is responsible for managing the process of family period's inner world
*/
public class FamilyInner : MonoBehaviour
{
    public void Onclick()
    {
        //sending message to SceneManager to change the scene
        GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "00_corridor");
        GameManager.isDoor4Locked = true;
    }
}
