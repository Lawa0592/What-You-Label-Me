using UnityEngine;
/*
[Using in scene '06_work_inner']
Introduction:
This script is responsible for controlling first person perspective and movement in work_inner
*/
public class WorkInnerPlayerController : MonoBehaviour
{
    public GameObject mainCamera;  //the first person camera;
    public float mouseSensitivity = 100f;  //the mouse sensitivity
    private float xRotation = 0.0f;  //the vertical rotation
    public float moveSpeed = 10f;  //player movement speed
    private CharacterController controller;
    private float gravityValue = -9.81f;  //gravity simulation of character controller
    private Vector3 playerVelocity;  //for the use of gravity

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
            [FUNCTION] 
            Control first camera perspective (rotation)
        */
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  //get mouseX value
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  //get mouseY value
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);  //limit the rotation angle between (-60°,60°)
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  //rotate camera 
        this.transform.Rotate(Vector3.up * mouseX);

        /*
            [FUNCTION] 
            Control player movement
        */
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        /*
            [FUNCTION] 
            Add the gravity on the player
        */
        if (controller.isGrounded && playerVelocity.y < 0)  //when is touching ground, once player start to move again, reset the y value to 0
            playerVelocity.y = 0f;
        //add gravity as time go through
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
