using UnityEngine;
using TMPro;
/*
Introduction:
This script is responsible for listening to what happens when the player approaches the door four
1. Switch scene to scene '07_family_reality'
2.
3.

*/
public class DoorFourTrigger : MonoBehaviour
{
    private GameObject enterTxt;

    // Start is called before the first frame update
    void Start()
    {
        enterTxt = GameObject.Find("Canvas/Panel/enterText");
        enterTxt.SetActive(false);
    }

    //Trigger event: when player is closing this door, show the Interaction hint and press space to go inside the door
    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")  //checking if the collider is player
        {
            enterTxt.SetActive(true);//show the hint of opening door
            if (Input.GetKey(KeyCode.Space))
            {
                if (!GameManager.isDoor4Locked) //only can open if the door isn't locked
                {
                    //sending message to SceneManager to change the scene
                    GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "07_family_reality");
                }
                else  //otherwise tell the player the door is locked
                {
                    enterTxt.GetComponent<TMP_Text>().text = "*Locked!!!*";
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //reset the text content
        enterTxt.GetComponent<TMP_Text>().text = "*ENTER*";
        //when player not in the range of the trigger, don't show the text
        enterTxt.SetActive(false);
    }
}
