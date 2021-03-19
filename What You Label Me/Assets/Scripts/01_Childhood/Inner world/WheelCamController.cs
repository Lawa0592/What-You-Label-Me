using UnityEngine;
/*
[Using in scene '01_Kid_inner']
Introduction:
This script is responsible for controlling the movement & shooting of Wheel's Launcher
*/
public class WheelCamController : MonoBehaviour
{
    public GameObject mainCamera;  //the first person camera;
    public GameObject launcher;  //the Launcher on wheel
    public float mouseSensitivity = 100f;  //the mouse sensitivity
    private float xRotation = 0.0f;  //the vertical rotation
    public GameObject bullet;  //the cube_bullet prefab
    public Transform shootingPoint;  //the place where bullet is shooted

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
            [FUNCTION] 
            Control first camera perspective (rotation) on Launcher
        */
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  //get mouseX value
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  //get mouseY value
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 5f);  //limit the rotation angle between (-30°,5°)
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  //rotate camera 
        launcher.transform.localRotation = Quaternion.Euler(-90f-xRotation, 180f, 0f);  //rotate launcher 
        this.transform.Rotate(Vector3.up * mouseX);
        /*
            [FUNCTION] 
            Shooting cube by using ray
        */
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        //Use Debug.DrawRay to see the Ray in the Scene Windows
        Debug.DrawLine(ray.origin, ray.direction * 50, Color.yellow);
        //click left mouse to shoot
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject insBullet = GameObject.Instantiate(bullet, shootingPoint.position, Quaternion.identity) as GameObject;
            insBullet.GetComponent<Rigidbody>().AddForce(ray.direction * 1000);
            Destroy(insBullet, 5.0f);
        }
    }
}
