using UnityEngine;
/*
[Using in scene '02_school_inner']
Introduction:
This script is responsible for showing each visual effect of cube in Maze
*/
public class MazeCubeEffect : MonoBehaviour
{
    public Transform playerTranform;  //the tranform of player
    public float maxDistance = 10.0f;
    public float minDistance = 5.0f;
    public bool isUp = false; // the 'up or down' position of cube
    public bool isDown = false; // the 'up or down' position of cube
    public bool isLayer0 = false; // the first floor of cubes
    public bool isLayer1 = false; // the second floor of cubes
    public bool isLayer2 = false; // the third floor of cubes
    public bool isLayer3 = false; // the fourth floor of cubes
    public bool isLayer4 = false; // the fifth floor of cubes
    public bool isLayer5 = false; // the sixth floor of cubes
    private bool[] layerList; // an array to store the boolean's value above
    private int layer;  //the layer on which the current cube is located
    private float curvature = 0.1f;
    private float originalY;
    // Start is called before the first frame update
    void Start()
    {
        //get all the boolean value
        layerList = new bool[] { isLayer0, isLayer1, isLayer2, isLayer3, isLayer4, isLayer5 };
        //get current layer
        layer = layerDetection(layerList);

        //store the original value of the y position
        originalY = this.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        cubeEffect(layer);
    }

    /*
        [FUNCTION] 
        Inputing the layer array, detect which layer the current cube is on, and return the layer's value
    */
    int layerDetection(bool[] layerList)
    {
        int layer = 0;
        for (int i = 0; i < layerList.Length;i++)
        {
            //find the only value that is 'true'
            if(layerList[i]==true)
            {
                //get this value's index, save as the layer
                layer = i;
                break;
            }
        }
        return layer;
    }
    /*
        [FUNCTION] 
        According to the input of different 'layers', display the corresponding visual effect
    */
    void cubeEffect(int layer)
    {
        //different layers will have different curvature
        if (layer == 0)
            curvature = 0.10f;
        if (layer == 1)
            curvature = 0.12f;
        if (layer == 2)
            curvature = 0.14f;
        if (layer == 3)
            curvature = 0.16f;
        if (layer == 4)
            curvature = 0.18f;
        if (layer == 5)
            curvature = 0.20f;

        //Debug.Log(distance);
        /*
            #### Demonstration ####
            The real-time movement of cubes is based on a composite function, included a quadratic function and two linear function.
            The X-axis is 'distance', and the Y-axis is 'Y position'
            The cube will have three states:
            1. [0,minDistance]  -> The player is very close to the cube -> The cube is keeping stay in the original position
            2. [minDistance,maxDistance]  -> The cube changes position with the value of the quadratic function
            3. [maxDistance,∞]  -> The player is far way from the cube -> Cube is keeping stay in the position which is the value of Y when x is maxDistance

        */
        
        //calculate current distance between player and this cube
        float distance = getHorizontalDistance(this.transform, playerTranform);
        //when the cube is above the horizontal line, it moves from top to bottom
        if (isUp && !isDown)
        {
            if (distance <= maxDistance && distance >= minDistance)
            {
                float y = curvature * ((distance - minDistance) * (distance - minDistance)) + originalY;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
            }
            if (distance < minDistance)
            {
                float y = originalY;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
            }
            if (distance > maxDistance)
            {
                float y = curvature * ((maxDistance - minDistance) * (maxDistance - minDistance)) + originalY;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
            }
        }
        //when the cube is below the horizontal line, it moves from bottom to top
        if (!isUp && isDown)
        {
            if (distance <= maxDistance && distance >= minDistance)
            {
                float y = -curvature * ((distance - minDistance) * (distance - minDistance)) + originalY;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
            }
            if (distance < 5)
            {
                float y = originalY;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
            }
            if (distance > maxDistance)
            {
                float y = -curvature * ((maxDistance - minDistance) * (maxDistance - minDistance)) + originalY;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
            }
        }
    }

    /*
        [FUNCTION] 
        Calculating the horizontal distance between two objects
    */
    float getHorizontalDistance(Transform tf1, Transform tf2)
    {
        //float distance = 0.0f;
        float x1 = tf1.position.x;
        float x2 = tf2.position.x;
        float z1 = tf1.position.z;
        float z2 = tf2.position.z;
        float distance = Mathf.Sqrt((x1 - x2) * (x1 - x2) + (z1 - z2) * (z1 - z2));

        return distance;
    }
}
