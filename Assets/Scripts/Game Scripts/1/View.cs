using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : Observer
{
    private GameObject mainShape, waterShape, character, smilingCharacter;
    private Subject subject;
    private Vector3 mainPos, waterPos;
    private Vector3 mainScale, waterScale;

    //Get methods for shapes - return by REFERENCE
    public ref GameObject getMainShape(){ return ref mainShape;}
    public ref GameObject getWaterShape(){ return ref waterShape;}
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

    public void makeCharacter(GameObject character, float yPos, float characterPositionFactor){
        Vector3 originalScale = character.transform.localScale;
        this.character = MonoBehaviour.Instantiate(character, new Vector3(-1f,yPos/3.33f*characterPositionFactor, 0), Quaternion.identity);
        this.character.transform.localScale = new Vector3(yPos/3.33f, yPos/3.33f, yPos/3.33f);
    }

    public ref GameObject getCharacter(){
        return ref character;
    }

    public void notifyMe(List<Vector3> vectors){
        if (vectors[2].x<-Camera.main.GetComponent<Main>().getMinLength() && vectors[2].x>-Camera.main.GetComponent<Main>().getMaxLength()){
            this.mainPos = vectors[0];
            mainShape.transform.position = this.mainPos;

            this.mainScale = vectors[2];
            mainShape.transform.localScale = this.mainScale;
            waterShape.GetComponent<ShapeVolume>().receiveMainShape(ref mainShape);

            this.waterPos = new Vector3(vectors[1].x, vectors[3].y/50/2, vectors[1].z);
            waterShape.transform.position = this.waterPos;

            this.waterScale = vectors[3];
            waterShape.transform.localScale = this.waterScale;
        }
    }

    public void makeSmilingCharacter(GameObject smile){
        this.smilingCharacter = MonoBehaviour.Instantiate(smile, this.character.transform.localPosition, Quaternion.identity);
        this.smilingCharacter.transform.localScale = character.transform.localScale;
    }

    public ref GameObject getSmilingCharacter(){
        return ref smilingCharacter;
    }
}
