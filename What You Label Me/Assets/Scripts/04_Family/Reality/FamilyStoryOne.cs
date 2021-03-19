﻿using UnityEngine;
using TMPro;
/*
[Using in scene '07_family_reality']
Introduction:
This script is responsible for managing the process of family's story 1
*/
public class FamilyStoryOne : MonoBehaviour
{
    private GameObject hintDialog;

    // Start is called before the first frame update
    void Start()
    {
        hintDialog = GameObject.Find("Canvas/Panel_hint/hintDialog");
        hintDialog.SetActive(false);
    }

    //Trigger event: when player is entering trigger area, show the Interaction hint and press space to interact
    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")  //checking if the collider is player's one
        {
            hintDialog.SetActive(true);//show the hint of interaction
            hintDialog.GetComponent<TMP_Text>().text = "Press space to start family's story1";
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(this.gameObject);
                hintDialog.SetActive(false);
                GameManager.FamilyListener();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //when player not in the range of the trigger, don't show the text
        hintDialog.SetActive(false);
    }
}
