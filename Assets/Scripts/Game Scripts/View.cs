using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : Observer
{
    private GameObject mainShape, waterShape;
    private Subject subject;

    private Vector3 mainPos, waterPos;
    private Vector3 mainScale, waterScale;

    //Get methods for shapes - return by REFERENCE
    public ref GameObject getMainShape(){
        return ref mainShape;
    }

    public ref GameObject getWaterShape(){
        return ref waterShape;
    }

    //Set methods for subject, shape positions & scales
    public void addSubject(Subject subject){
        this.subject = subject;
        subject.attach(this);
    }

    public void setMainPos(Vector3 mainPos){
        this.mainPos = mainPos;
    }

    public void setWaterPos(Vector3 waterPos){
        this.waterPos = waterPos;
    }

    public void setMainScale(Vector3 mainScale){
        this.mainScale = mainScale;
    }

    public void setWaterScale(Vector3 waterScale){
        this.waterScale = waterScale;
    }
    public void makeShapes(GameObject mainPrefab, GameObject waterPrefab){
        this.mainShape = MonoBehaviour.Instantiate(mainPrefab, new Vector3(0,1,0), Quaternion.identity);
        mainShape.transform.localScale = new Vector3(100,100,100);
        this.waterShape = MonoBehaviour.Instantiate(waterPrefab, new Vector3(0,1,0), Quaternion.identity);
    }

      public void notifyMe(Vector3 mainPos, Vector3 waterPos, Vector3 mainScale, Vector3 waterScale){
        // Debug.Log("notified - View");

        this.mainPos = mainPos;
        mainShape.transform.position = mainPos;

        this.mainScale = mainScale;
        Debug.Log(mainScale);
        mainShape.transform.localScale = mainScale;
    }
}
