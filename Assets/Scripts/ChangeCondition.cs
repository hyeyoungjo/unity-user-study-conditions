using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCondition : MonoBehaviour
{
    private StudyCondition target_condition;

    // -----------------------SAMPLE--------------------------
    [Header("[Automatic]")]
    public List<GameObject> myObjs;

    void OnEnable()
    {
        SetStudyOrder.OnChangeCondition += SwitchCondition;
    }
    void OnDisable()
    {
        SetStudyOrder.OnChangeCondition -= SwitchCondition;
    }
    void Start()
    {
        SwitchCondition();
    }

    void SwitchCondition()
    {
        target_condition = transform.GetComponent<SetStudyOrder>().Condition;
        Debug.Log("Condition : "+ target_condition);    

        switch(target_condition)
        {
            case StudyCondition.Default:
                DefaultFunc();
                break;
            case StudyCondition.FirstCondition:
                DefaultFunc();
                FirstFunc();
                break;
            case StudyCondition.SecondCondition:
                DefaultFunc();
                SecondFunc();
                break;
            case StudyCondition.ThirdCondition:
                DefaultFunc();
                ThirdFunc();
                break;
            case StudyCondition.FourthCondition:
                DefaultFunc();
                FourthFunc();
                break;
            default:
                Debug.Log("Incorrect Condition");
                break;    
        }
    }

    void DefaultFunc()
    {
        //Debug.Log("DefaultFunc");
        if(myObjs.Count != 0)
        {
            foreach(GameObject obj in myObjs)
            {
                obj.SetActive(false);
            }
        }
    }


    void FirstFunc()
    {
        //Debug.Log("FirstFunc");
        try{myObjs[0].SetActive(true);}
        catch(System.Exception e){Debug.Log("Error. Missing GameObject in First Condition");}
    }

    void SecondFunc()
    {
        //Debug.Log("SecondFunc");
        try{myObjs[1].SetActive(true);}
        catch(System.Exception e){Debug.Log("Error. Missing GameObject in Second Condition");}
    }
    
    void ThirdFunc()
    {
        //Debug.Log("ThirdFunc");
        try{myObjs[2].SetActive(true);}
        catch(System.Exception e){Debug.Log("Error. Missing GameObject in Third Condition");}
    }
    void FourthFunc()
    {
        //Debug.Log("FourthFunc");
        try{myObjs[3].SetActive(true);}
        catch(System.Exception e){Debug.Log("Error. Missing GameObject in Fourth Condition");}

    }
}
