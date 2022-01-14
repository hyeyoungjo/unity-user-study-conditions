using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetStudyOrder : MonoBehaviour
{
    // -----------------------LOAD CONDITION FROM CSV--------------------------
    [Header("[Automatic]")]
    [Tooltip("This Load Condition From The 'Assets/StudyOrder.csv' Script")]
    [ShowOnly] public string participant;
    private string[] loaded;
    [ShowOnly] public List<string> loadedList;
    [ShowOnly] public StudyCondition Condition;
    //total condition count including default condition
    private int condition_count = System.Enum.GetValues(typeof(StudyCondition)).Length - 1;
    [ShowOnly] public int session;
    [ShowOnly] public int current_condition;

    
    // -----------------------SET CONDITION HERE--------------------------
    [Header("[Manual]")]
    [Tooltip("To Change Condition Mannually, Tick 'Force Change' and Choose Condition in 'Force Condition'")]
    [SerializeField]
    private StudyCondition ForceCondition;
    private StudyCondition Prev_ForceCondition;

     // -----------------------PROPERTY--------------------------
    public bool forceChange = false;
    private bool prev_forceChange;

    // -----------------------EVENT--------------------------
    public delegate void ChangeCondition();
    public static event ChangeCondition OnChangeCondition;


    

    void Start()
    {
        loaded = transform.GetComponent<GetStudyOrder>().orderArr; //load orderArr in awake
        ChangeLoadedDataToString();
        
        Condition = StudyCondition.Default;
        ForceCondition = StudyCondition.Default;
    }


    void Update()
    {
        
        //automatic mode
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(session < condition_count)
            {
                session++;
                SetLoadedConditionToCondition(int.Parse(loaded[session]));
                TriggerChangeConditionEvent();
            }
        }

        //mannual mode
        // when bool state is changed
        if(forceChange != prev_forceChange)
        {
            //if the bool is true, and condition is different from previous condition, update condition and trigger event
            if(forceChange && ForceCondition != Prev_ForceCondition)
            {
                SetForceConditionToCondition();
                //when turn on the 'forceChange' boolean, trigger event to move screen
                TriggerChangeConditionEvent();
                Prev_ForceCondition = ForceCondition; //once
            }

            //if the bool is false, reset
            if(!forceChange)
            {
                session = 0;
                SetLoadedConditionToCondition(0);
                TriggerChangeConditionEvent();
            }
            
            prev_forceChange=forceChange; //once
        }
        // when bool state is not changed
        else
        {
            //but if the bool is true, and when you toggled enum, update condition and trigger event
            if(forceChange) 
            {
                if(ForceCondition != Prev_ForceCondition)
                {
                    SetForceConditionToCondition();
                    TriggerChangeConditionEvent(); 
                    Prev_ForceCondition = ForceCondition; //once
                }
                prev_forceChange=forceChange; //once
            }
        }

    }



    void TriggerChangeConditionEvent()
    {
        //trigger event to move screen
        if(OnChangeCondition != null)
            OnChangeCondition();
    }


    void SetForceConditionToCondition()
    {
        session = 1000;
        Condition = ForceCondition;
        current_condition = (int)ForceCondition;
    }


    void SetLoadedConditionToCondition(int idx)
    {   
        //idx is the current condition(in number) from the loaded data
        current_condition = idx;
        Condition = (StudyCondition)current_condition;
        ForceCondition = Condition;
        Prev_ForceCondition = ForceCondition;
    }


    void ChangeLoadedDataToString()
    {
        for(int i=0; i<loaded.Length; i++)
        {
             //if it is string, that is participant number
             string data = loaded[i];
             bool isNumber = int.TryParse(loaded[i], out int number);
             if(!isNumber)
             {
                 //print("participant number :"+ data);
                 participant = data;
                 loadedList.Add(participant);
             }
             //if it is number, change it to string and save as list
             else
             {  
                 int condition_numeric = int.Parse(data);
                 StudyCondition condition_enum = (StudyCondition)condition_numeric;
                 string condition_string = condition_enum.ToString();
                 //print(loaded[i] + " means " + condition_string);
                loadedList.Add(condition_string);
             }
        }
    }
   
}
