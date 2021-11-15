using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View2 : MonoBehaviour, Observer
{
    private Subject subject;
    private GameObject mainObject, clickedObject;
    private Vector3 distance, clickedObjectStartPos;
    private float smoothing = 2f;
    public void addSubject(Subject subject){ this.subject = subject; subject.attach(this);}
    public void notifyMe(){
    }
    public void notifyMe(Vector3 clickedObjectStartPos, Vector3 distance, Vector3 _null, Vector3 _null_){
        this.clickedObjectStartPos = clickedObjectStartPos;
        this.distance = distance;
        StartCoroutine(this.moveCoroutine()); 
    }

    private IEnumerator moveCoroutine()
    {   
        while (Vector3.Distance(clickedObject.transform.position,distance)>0.01f){
            clickedObject.transform.position = Vector3.Lerp(clickedObject.transform.position, distance, smoothing*Time.deltaTime);
            yield return null;
        }
    }

    public void makeMainObject(ref GameObject mainObject){}
    public ref GameObject getMainObject(){return ref mainObject;}
    public void receiveClickedObject(ref GameObject clickedObject){
        this.clickedObject = clickedObject;
    }
}
