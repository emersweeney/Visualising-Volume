using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : Observer
{
    private GameObject mainShape, waterShape, targetArrow, dragArrow;
    private Subject subject;
    private Vector3 mainPos, waterPos;
    private Vector3 mainScale, waterScale;

    //Get methods for shapes - return by REFERENCE
    public ref GameObject getMainShape(){ return ref mainShape;}
    public ref GameObject getWaterShape(){ return ref waterShape;}
    public ref GameObject getTargetArrow(){ return ref targetArrow;}
    public ref GameObject getDragArrow(){ return ref dragArrow;}
    //Set method for subject
    public void addSubject(Subject subject){ this.subject = subject; subject.attach(this);}
    public void makeShapes(GameObject mainPrefab, GameObject waterPrefab){
        this.mainShape = MonoBehaviour.Instantiate(mainPrefab, new Vector3(1,1,0), Quaternion.identity);
        this.mainPos = mainShape.transform.position;
        mainShape.transform.localScale = new Vector3(100,100,100);
        this.mainScale = mainShape.transform.localScale;

        this.waterShape = MonoBehaviour.Instantiate(waterPrefab, new Vector3(mainPos.x, mainPos.y/2f, mainPos.z), Quaternion.identity);
        this.waterPos = waterShape.transform.position;
        waterShape.transform.localScale = waterShape.GetComponent<ShapeVolume>().calculateStartScale(mainScale);
        this.waterScale = waterShape.transform.localScale;
    }

    public void makeTargetArrow(GameObject target, float yPos){
        this.targetArrow = MonoBehaviour.Instantiate(target, new Vector3(-1f,yPos,0), Quaternion.identity);
    }
    public void makeDragArrow(GameObject arrow){
        this.dragArrow = MonoBehaviour.Instantiate(arrow, new Vector3(mainShape.transform.localScale.x/50f, (mainShape.transform.localScale.y-10)/50f, -mainShape.transform.localScale.z/100f), Quaternion.identity);
    }

    public void notifyMe(Vector3 mainPos, Vector3 waterPos, Vector3 mainScale, Vector3 waterScale){
    // Debug.Log("notified - View");

        if (Camera.main.GetComponent<Main>().getGameState() == 1){return;}

        if (mainScale.x<-Camera.main.GetComponent<Main>().getMinLength() && mainScale.x>-Camera.main.GetComponent<Main>().getMaxLength()){
            this.mainPos = mainPos;
            mainShape.transform.position = this.mainPos;

            this.mainScale = mainScale;
            mainShape.transform.localScale = this.mainScale;
            waterShape.GetComponent<ShapeVolume>().receiveMainShape(ref mainShape);

            this.waterPos = new Vector3(waterPos.x, waterScale.y/50/2, waterPos.z);
            waterShape.transform.position = this.waterPos;

            this.waterScale = waterScale;
            Debug.Log("WATER SCALE IN VIEW:"+this.waterScale);
            waterShape.transform.localScale = this.waterScale;

            this.dragArrow.transform.position = new Vector3(-mainShape.transform.localScale.x/50f, (mainShape.transform.localScale.y-10)/50f, -mainShape.transform.localScale.z/100f);

        }
    
    }
}
