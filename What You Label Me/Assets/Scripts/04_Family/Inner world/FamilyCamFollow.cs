using UnityEngine;
/*
[Using in scene '08_family_inner']
Introduction:
This script is responsible for controlling Main Camera keep following player in family_inner
*/
public class FamilyCamFollow : MonoBehaviour
{
    public Transform player; //follow target is the palyer
    private Vector3 offset; //the distance between player and camera

    // Start is called before the first frame update
    void Start()
    {
        //calculate the distance between player and camera
        offset = transform.position - player.position;
    }
    void LateUpdate() //using LateUpdate to make sure the camera move after player's action
    {
        //Camera will keep moving by follow the player
        //basically the camera's x,y don't change, just change the z axis value, which = player.z - offset
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        //update position
        transform.position = newPosition;
    }
}
