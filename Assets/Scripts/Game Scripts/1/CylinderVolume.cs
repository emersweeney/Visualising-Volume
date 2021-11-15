using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderVolume : MonoBehaviour, ShapeVolume
{
        float length, breadth, height, volume, dimension; //length = diameter = breadth
    public void calculateVolume(){
        this.length = this.gameObject.transform.localScale.z;
        this.breadth = this.gameObject.transform.localScale.x;
        this.height = this.gameObject.transform.localScale.y;
        this.volume = Mathf.PI*(length/2)*(breadth/2)*height;
    }
    public Vector3 calculateStartScale(Vector3 mainScale){
        return new Vector3(mainScale.x, mainScale.y/2f, mainScale.z);
    }

    public Vector3 calculateNewScale(Vector3 mainScale){
        this.length = mainScale.x;
        this.breadth = mainScale.z;
        dimension = -volume/Mathf.PI/(length/2)/(breadth/2);
        return new Vector3(length, dimension, breadth);
    }

    public float getMinHeight(){
        return volume/Camera.main.GetComponent<Main>().getMaxLength();
    }
    public float getMaxHeight(){return volume/Camera.main.GetComponent<Main>().getMinLength();}
    public void receiveMainShape(ref GameObject mainShape){}
    public void receiveDragDistance(float dragDistance){}
}
