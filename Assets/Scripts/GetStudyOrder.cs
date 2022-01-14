using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GetStudyOrder : MonoBehaviour
{
    // Set condition in cs file "Assets/StudyCondition.cs"
    // Set order in csv file "Assets/StudyOrder.csv"
    // -----------------------SET CONDITION HERE--------------------------
    [Header("[File]")]
    [ShowOnly] [SerializeField] private string file_name = "StudyOrder";


    [Header("[Participant]")]
    [Tooltip("Write Participant Number, e.g. 'P1'")]
    public string participant = "P1"; 
    //public List<string> orderList = new List<string>();
    [ShowOnly] public string[] orderArr;


    void Awake()
    {
        ReadCSVFile(file_name);
    }

    public void ReadCSVFile(string fileName)
    {
        string filePath = Application.dataPath;
        //string fileName = "LocationOrder";
        StreamReader strReader = new StreamReader(filePath + "/" + fileName + ".csv");
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }

            var dataLines = data_String.Split('\n');
            //Debug.Log(dataLines.ToString());
             for(int i=0; i<dataLines.Length; i++)
             {
                 var dataLine = dataLines[i].Split(',');

                 //if participant number matches, get order
                 //print(dataLine[0].ToString());
                 if(dataLine[0].ToString() == participant)
                 {
                    List<string> loadedOrderList = new List<string>();
                    for(int d=0; d <dataLine.Length; d++)
                    {
                        string data = dataLine[d];
                        loadedOrderList.Add(data);
                    }
                    string[] loadedOrderArr = loadedOrderList.ToArray();
                    //orderList = loadedOrderList; //list
                    orderArr = loadedOrderArr; //array
                 }
             }
        }
    }
}
