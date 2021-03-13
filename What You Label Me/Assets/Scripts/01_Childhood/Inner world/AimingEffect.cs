using UnityEngine;
/*
[Using in scene '01_Kid_inner']
Introduction:
This script is responsible for showing the visual effect when aiming certain area of models
*/
public class AimingEffect : MonoBehaviour
{
    private Material originalMat;  //the original material of object
    public Material whiteMat;  //the default material when launcher isn't aiming model
    
    // Start is called before the first frame update
    void Start()
    {
        //Store the original material
        originalMat = gameObject.GetComponent<Renderer>().material;
        //Set the object to be "white"
        gameObject.GetComponent<Renderer>().material = whiteMat;
    }
    void OnTriggerEnter(Collider collider)
    {
        //when Launcher's trigger enter
        if(collider.name == "Launcher")
        {
            //Debug.Log("Enter");
            //change the material to the 'colored' version
            gameObject.GetComponent<Renderer>().material = originalMat;
        }
    }
    void OnTriggerExit(Collider collider) 
    {
        if (collider.name == "Launcher")
        {
            //Debug.Log("Exit");
            //change the material to the 'white' version
            gameObject.GetComponent<Renderer>().material = whiteMat;
        }
        
    }
}
