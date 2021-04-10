using UnityEngine;
/*
[Using in scene '01_Kid_reality, 03_school_kid_reality, 05_work_reality, 07_family_reality']
Introduction: Listen for commands from the Fungus flowchart to call methods in GameManager

*/
public class FlowchartListener : MonoBehaviour
{

    /*
        [FUNCTION] 
        Passed to GameManager to set player moving state based on the input Boolean value
    */
    public void switchPlayerMovingStateToGM(bool booleanValue)
    {
        GameManager.setPlayerMovingState(booleanValue);
    }

}
