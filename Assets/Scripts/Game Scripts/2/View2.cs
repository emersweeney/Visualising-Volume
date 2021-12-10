using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View2 : MonoBehaviour, Observer
{
    private Subject subject;
    private GameObject mainObject, clickedObject;
    private Transform waterObject, containerObject;
    private Vector3 distance, originalScale, originalPosition;
    public void addSubject(Subject subject){ this.subject = subject; subject.attach(this);}
    public void notifyMe(List<Vector3> vectors){
        this.distance = vectors[0];
        StartCoroutine(this.moveCoroutine(distance, 1f)); 
    }

    public void sizeMainObject(ref GameObject mainObject, float size){ mainObject.transform.localScale = new Vector3(size,size,size);}
    public ref GameObject getMainObject(){return ref mainObject;}
    public void receiveClickedObject(ref GameObject clickedObject){
        this.clickedObject = clickedObject;
        originalScale = clickedObject.transform.localScale;
        originalPosition = clickedObject.transform.position;
        clickedObject.transform.localScale = 1.1f*originalScale;
    }

    public void returnSmallToOriginal(){
        clickedObject.transform.localScale = originalScale;
        StartCoroutine(moveCoroutine(originalPosition, 1f));
        waterObject = clickedObject.transform.GetChild(1);
        containerObject = clickedObject.transform.GetChild(0);
        waterObject.GetComponentInChildren<Renderer>().material = containerObject.GetComponentInChildren<Renderer>().material;
        clickedObject.GetComponent<ClickNotifier>().setEmpty(true);
    }

    private IEnumerator moveCoroutine(Vector3 target, float lerpTime)
    {  
        float lerpStartTime = Time.time;
        float passedTime = Time.time - lerpStartTime;
        float percentComplete = passedTime/lerpTime;

        while (true){
            passedTime = Time.time - lerpStartTime;
            percentComplete = passedTime/lerpTime;
            Vector3 newPos = Vector3.Lerp(clickedObject.transform.position, target, percentComplete);
            clickedObject.transform.position = newPos;
            if (percentComplete >= 1) break;
            yield return new WaitForEndOfFrame();
        }
    }

    public void makeMainFull(Material cartoonWater, ref GameObject mainWater){
        mainWater.GetComponent<Renderer>().material = cartoonWater;
    }

}
