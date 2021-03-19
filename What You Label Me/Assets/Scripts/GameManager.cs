using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*
[Using in scene '00_corridor']
Introduction:
This script is responsible for
*/
public class GameManager : MonoBehaviour
{
    public static bool isDoor1Locked;  //the lock state of door one(kid)
    public static bool isDoor2Locked;  //the lock state of door two(school)
    public static bool isDoor3Locked;  //the lock state of door three(work)
    public static bool isDoor4Locked;  //the lock state of door four(family)
    private static int kidStoryNum = 0;  //the number of interactions that have been experienced in Kid reality scene
    private static int schoolStoryNum = 0;  //the number of interactions that have been experienced in high school reality scene
    private static int workStoryNum = 0;  //the number of interactions that have been experienced in work reality scene
    private static int familyStoryNum = 0;  //the number of interactions that have been experienced in family reality scene

    void Awake() 
    {
        LoadGameManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set the default value of the door lock state when game starting
        isDoor1Locked = false;
        isDoor2Locked = true;
        isDoor3Locked = true;
        isDoor4Locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
        [FUNCTION] 
        1.Keep Game Manager(GM) stay when loading another scene
        2.Delete the new GM if there exsit an new GM in hierarchy. 
            Because only the first scene have the originally GM, 
            so when restart the whole game without quit the application, there will be two GM at the same time. 
    */
    void LoadGameManager()
    {

        int num = 0;  //the numer of GM in the hierarchy
        List<GameObject> objList = new List<GameObject>();  //a list to store GameManager

        //seek all object in hierarchy, find if there are multiple Game Manager
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.name == "_Game Manager")
            {
                num++;
                objList.Add(obj);
            }

        }
        //if only one Game Manager, make this GM don't destory on load
        if (num < 2)
            DontDestroyOnLoad(this.gameObject);
        //if there are multiple Game Manager in scene
        else
        {
            DontDestroyOnLoad(objList[0]);  //keep the old one.
            Destroy(objList[1]);  //delete the new one
        }
    }
    /*
        [FUNCTION] 
        Listen the number of stories completed in the kid_reality scene
    */
    public static void kidListener()
    {
        kidStoryNum++;
        if(kidStoryNum == 4)
        {
            //sending message to SceneManager to change the scene
            GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "02_kid_inner");
        }
    }
    /*
        [FUNCTION] 
        Listen the number of stories completed in the kid_reality scene
    */
    public static void HighSchoolListener()
    {
        schoolStoryNum++;
        if (schoolStoryNum == 3)
        {
            //sending message to SceneManager to change the scene
            GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "04_school_inner");
        }
    }
    /*
        [FUNCTION] 
        Listen the number of stories completed in the work_reality scene
    */
    public static void WorkplaceListener()
    {
        workStoryNum++;
        if (workStoryNum == 3)
        {
            //sending message to SceneManager to change the scene
            GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "06_work_inner");
        }
    }
    /*
        [FUNCTION] 
        Listen the number of stories completed in the family_reality scene
    */
    public static void FamilyListener()
    {
        familyStoryNum++;
        if (familyStoryNum == 3)
        {
            //sending message to SceneManager to change the scene
            GameObject.Find("_Scene Manager").SendMessage("SceneReceiver", "08_family_inner");
        }
    }
}
