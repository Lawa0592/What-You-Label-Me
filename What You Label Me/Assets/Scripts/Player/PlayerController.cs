using UnityEngine;

/*
[Using in scene '00_corridor']
Introduction:
*/

public class PlayerController : MonoBehaviour
{  
    public GameObject mainCam;  //main camera in hierachy
    public GameObject followCam;   //3rd person camera which follow player
    public GameObject focusCam;    //3rd person camera which focus player
    public float movingSpeed = 6f;  //player moving speed
    private CharacterController controller;  //character controller
    private Vector3 moveDir;
    private float turnSmoothTime = 0.1f;  //Approximately the time it will take to reach the target
    private float turnSmoothVelocity;   //The current velocity
    private bool isCamFocused;     //a status of current using camera
    private float gravityValue = -9.81f;  //gravity simulation of character controller
    private Vector3 playerVelocity;  //for the use of gravity
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        isCamFocused = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
            [FUNCTION] 
            Add the gravity on the player
        */
        if (controller.isGrounded && playerVelocity.y < 0)  //when is touching ground, once player start to move again, reset the y value to 0
            playerVelocity.y = 0f;
        //add gravity as time go through
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        /*
            [FUNCTION] 
            Controlling player's movement by using Horizontal & Vertical
        */
        float horizontal = Input.GetAxisRaw("Horizontal");  //Get the status of Horizontal
        float vertical = Input.GetAxisRaw("Vertical");     //Get the status of Vertical
        Vector3 inputDir = new Vector3(horizontal, 0.0f, vertical).normalized;  //Get the direction vectors entered by Horizontal and Vertical
                                                                                //when input direction vector has length, that means player can only be moved when there is a continuous parameter input
        if (inputDir.magnitude >= 0.1f)
        {
            //calculate the angle between current orientation and next moving orientation
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + mainCam.transform.eulerAngles.y;  //<-- always go forward in the direction where the main camera is pointing
                                                                                                                        //the direction vector that moves horizontally in the world
            moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            //moving according to the direction
            controller.Move(moveDir * movingSpeed * Time.deltaTime);

            //smooth rotation angle, to make the player rotate more smooth in each frame. [The 'SmoothDampAngle' Refer from: https://docs.unity3d.com/ScriptReference/Mathf.SmoothDampAngle.html]
            float rotationAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //Rotate player orientation
            transform.rotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);

            //active walk animation
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            //disable walk animation, and switch back to idle animation
            playerAnimator.SetBool("isWalking", false);
        }
        
        /*
            [FUNCTION] 
            Switch camera between view when moving and view when having conversation
         
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(isCamFocused)
            {
                followCam.SetActive(false);
                focusCam.SetActive(true);
                isCamFocused = !isCamFocused;
            }
            else
            {
                followCam.SetActive(true);
                focusCam.SetActive(false);
                isCamFocused = !isCamFocused;
            }
        }*/
        
    }
}
