# UnityUserStudyConditions
default scene switching study conditions for each participants.

## Environment
* Unity 2019.4.20f1

## Packages
* [TextMeshPro v.2.1.1](https://docs.unity3d.com/Packages/com.unity.textmeshpro@2.1/manual/index.html)
  * upgrade to 2.1.6
 
## How to Use
* Scene/MainStudy
 1. Write study condition in Assets/StudyCondition.cs
 2. Write order of study in Assets/StudynOrder.csv
 3. Make method for each condition in ChangeStudynCondition.cs
 4. Hit space bar to change condition automatically
 5. Tick ForceChange in Manager to do it mannually
