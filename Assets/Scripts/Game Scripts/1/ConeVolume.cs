using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeVolume : MonoBehaviour, ShapeVolume
{
    public float length, breadth, height, volume, dimension, dragDistance; //length = diameter = breadth
    public GameObject mainShape;
    public void calculateVolume(){
        this.length = this.gameObject.transform.localScale.z;
        this.breadth = this.gameObject.transform.localScale.x;
        this.height = this.gameObject.transform.localScale.y;
        this.volume = getVolume(length, height);
    }
    public Vector3 calculateStartScale(Vector3 mainScale){
        float theta = 2f*Mathf.Atan(mainScale.x/2f/mainScale.y);
        this.height = mainScale.y/2f;
        this.length = 2f*Mathf.Tan(theta/2f)*height;
        this.breadth = this.length;
        // float new_volume = getVolume(new_yPos)
        return new Vector3(length,height,length);
    }

    public Vector3 calculateNewScale(Vector3 mainScale){
        float theta = 2f*Mathf.Atan(mainScale.x/2f/mainScale.y);
        this.length += (mainShape.transform.localScale.x/50f)+dragDistance;
        Debug.Log("VOLUME="+volume);
        dimension = 3f*volume/(Mathf.PI*(length/2f)*(length/2f));
        Debug.Log("DIMENSION="+dimension);
        return new Vector3(length, dimension, length);
    }

    public float getMinHeight(){
        return volume/Camera.main.GetComponent<Main>().getMaxLength();
    }
    public float getMaxHeight(){return volume/Camera.main.GetComponent<Main>().getMinLength();}

    public float getVolume(float length, float height){
        volume = (1f/3)*Mathf.PI*(length/2f)*(length/2f)*height;
        return volume;
    }

    public float getVolume(){return volume;}
    public void receiveMainShape(ref GameObject mainShape){this.mainShape=mainShape;}
    public void receiveDragDistance(float dragDistance){this.dragDistance=dragDistance;}
}
