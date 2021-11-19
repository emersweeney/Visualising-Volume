using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View2 : MonoBehaviour, Observer
{
    private Subject subject;
    private GameObject mainObject, clickedObject;
    private Vector3 distance, clickedObjectStartPos;
    private float smoothing = 2f;
    private  Quaternion start_rotation;
    private Quaternion end_rotation = Quaternion.Euler(0,0,-130);
    public void addSubject(Subject subject){ this.subject = subject; subject.attach(this);}
    public void notifyMe(){
    }
    public void notifyMe(Vector3 clickedObjectStartPos, Vector3 distance, Vector3 _null, Vector3 _null_){
        this.clickedObjectStartPos = clickedObjectStartPos;
        this.distance = distance;
        this.start_rotation = this.clickedObject.transform.rotation;
        StartCoroutine(this.moveCoroutine()); 
        if (Vector3.Distance(clickedObject.transform.position,distance)<=0.01f) StartCoroutine(rotateCoroutine());
    }

    private IEnumerator moveCoroutine()
    {   
        while (Vector3.Distance(clickedObject.transform.position,distance)>0.01f){
            clickedObject.transform.position = Vector3.Lerp(clickedObject.transform.position, distance, smoothing*Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator rotateCoroutine()
    {  
        while (clickedObject.transform.rotation != end_rotation){
            clickedObject.transform.rotation=Quaternion.Lerp(start_rotation,end_rotation,smoothing*Time.deltaTime);
            yield return null;
        }
    }

    public void makeMainObject(ref GameObject mainObject){}
    public ref GameObject getMainObject(){return ref mainObject;}
    public void receiveClickedObject(ref GameObject clickedObject){
        this.clickedObject = clickedObject;
    }
}
