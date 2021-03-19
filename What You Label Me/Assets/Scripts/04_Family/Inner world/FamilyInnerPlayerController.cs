using UnityEngine;
using TMPro;
/*
[Using in scene '08_family_inner']
Introduction:
This script is responsible for:
1. controlling player movement and special gravity
2. game mechanics
*/
public class FamilyInnerPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isAddForce = false;
    private bool isInLeftSide = false;
    private bool isInRightSide = false;
    private float leftTime;  //the time spend in 'work' zone
    public TMP_Text leftTimeTXT;  //the text of spending time in 'work' zone
    private float rightTime; //the time/value spend in 'family' zone
    public TMP_Text rightTimeTXT;  //the text of spending time in 'family' zone
    public TMP_Text balanceTXT;  //the text of proportion of left & right time
    public ParticleSystem particlesystem;
    public Material redMat;  //
    public Material blueMat;  //
    [SerializeField] float moveSpeed = 400.0f; //moving speed
    [SerializeField] float force = 10f;  //force 
    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody
        rb = GetComponent<Rigidbody>();

        //when game started, the default gravity direction is to the right
        Physics.gravity = new Vector3(9.18f, 0f, 0f);
        isInRightSide = true;

        //the time start with 0
        leftTime = 0.0f;
        rightTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isAddForce = true;
        }
        leftTimeTXT.text = "Left: " + leftTime;
        rightTimeTXT.text = "Right: " + rightTime;
        balanceTXT.text = "Balance: " + (leftTime/rightTime);

    }
    void FixedUpdate()
    {
        //keep moving forward alone the z-axis
        //rb.AddForce(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        //adding the anti-gravity force 
        if(isAddForce)
        {
            if(isInLeftSide)
            {
                rb.AddForce(Vector3.right * force * 1000 * Time.fixedDeltaTime);
            }
            if(isInRightSide)
            {
                rb.AddForce(Vector3.left * force * 1000 * Time.fixedDeltaTime);
            }
            isAddForce = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        //when in the left zone
        if(collider.transform.tag == "FamilyInner_Work_Zone")
        {
            Debug.Log("work zone");
            //switch material
            particlesystem.GetComponent<Renderer>().material = redMat;

            //switch the gravity direction ( -> to right)
            Physics.gravity = new Vector3(-9.18f, 0f, 0f);
            //switch the force drection state
            isInLeftSide = true;
            isInRightSide = false;
            //counting the time spended in left zone
            leftTime += Time.deltaTime;
        }
        //when in the right zone
        if (collider.transform.tag == "FamilyInner_Family_Zone")
        {
            Debug.Log("family zone");
            //switch material
            particlesystem.GetComponent<Renderer>().material = blueMat;
            //switch the gravity direction ( <- to left)
            Physics.gravity = new Vector3(9.18f, 0f, 0f);
            //switch the force drection state
            isInLeftSide = false;
            isInRightSide = true;
            //count the time spended in right zone
            rightTime += Time.deltaTime;
        }
    }
}
