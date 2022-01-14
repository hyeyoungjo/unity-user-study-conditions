using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCondition : MonoBehaviour
{
    private StudyCondition target_condition;

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
    }

    void FirstFunc()
    {
        //Debug.Log("FirstFunc");
    }
    void SecondFunc()
    {
        //Debug.Log("SecondFunc");
    }
    void ThirdFunc()
    {
        //Debug.Log("ThirdFunc");
    }
    void FourthFunc()
    {
        //Debug.Log("FourthFunc");

    }
}
