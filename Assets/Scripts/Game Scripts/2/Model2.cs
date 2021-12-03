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
            distance = new Vector3(targetX, targetY, -7);
            notify();
        }
    }

    public bool smallIsEmpty(ref GameObject smallObject){
        if ((smallObject != null) && (Mathf.Abs(smallObject.transform.position.x - mainObject.transform.position.x) <= 0.01f)) {
            return true;
        }
        return false;
    }

    public void notify(){
        foreach (Observer o in observers)
        {
            o.notifyMe(new List<Vector3>{distance});
        }
    }

}
