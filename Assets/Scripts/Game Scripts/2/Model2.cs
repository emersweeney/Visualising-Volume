using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model2 : MonoBehaviour, Subject
{
    private List<Observer> observers = new List<Observer>();
    private GameObject clickedObject, mainObject;
    private Vector3 clickedObjectStartPos, mainObjectPos, distance;

    public void attach(Observer o){
        observers.Add(o);
    }

    public void receiveMainObject(ref GameObject mainObject){
        this.mainObject = mainObject;
        mainObjectPos = mainObject.transform.position;
    }

    public void receiveClickedObject(ref GameObject clickedObject, Vector3 startPos){
        this.clickedObject = clickedObject;
        this.clickedObjectStartPos = startPos;
    }
    public void updateClickedObject(float v){
        if (clickedObject != null){
            float targetX = clickedObjectStartPos.x + (v/10f)*(mainObjectPos.x - clickedObjectStartPos.x);
            float targetY = (v/10f)*(4f);
            float targetZ = clickedObjectStartPos.z + (v/10f)*(mainObjectPos.z - clickedObjectStartPos.z);
            distance = new Vector3(targetX, targetY, targetZ);
            notify();
        }
    }

    public void notify(){
        foreach (Observer o in observers)
        {
            o.notifyMe(clickedObjectStartPos, distance, new Vector3(0,0,0), new Vector3(0,0,0));
        }
    }

}
