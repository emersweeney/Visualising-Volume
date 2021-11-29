using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* the only dimension of cuboid water shape that diverges from main shape is height
 * water shape length and breadth are fixed to main shape length and breadth
 */
public class CuboidVolume : MonoBehaviour, ShapeVolume
{
    private float length, breadth, height, volume, dimension;
    public void calculateVolume(){
        this.length = this.gameObject.transform.localScale.z;
        this.breadth = this.gameObject.transform.localScale.x;
        this.height = this.gameObject.transform.localScale.y;
        this.volume = length*breadth*height;
    }
    public Vector3 calculateStartScale(Vector3 mainScale){
        return new Vector3(mainScale.x, mainScale.y/2f, mainScale.z);
    }

    public Vector3 calculateNewScale(Vector3 mainScale){
        this.length = mainScale.x;
        this.breadth = mainScale.z;
        dimension = -volume/length/breadth;
        return new Vector3(length, dimension, breadth);
    }

    public float getMinHeight(){return volume/Camera.main.GetComponent<Main>().getMaxLength();}
    public float getMaxHeight(){return volume/Camera.main.GetComponent<Main>().getMinLength();}
    public float getVolume(){return volume;}
    public void receiveMainShape(ref GameObject mainShape){}
    public void receiveDragDistance(float dragDistance){}
}
