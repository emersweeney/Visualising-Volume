using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* the only dimension of cuboid water shape that diverges from main shape is height
 * water shape length and breadth are fixed to main shape length and breadth
 */
public class CuboidVolume : MonoBehaviour, ShapeVolume
{
    float length, breadth, height, volume, dimension;
    public void calculateVolume(){ 
        this.volume = length*breadth*height;
    }

    public float calculateDimension(){
        this.volume = 
        this.length = this.gameObject.transform.localScale.z;
        this.breadth = this.gameObject.transform.localScale.x;
        dimension = (float)volume/length/breadth;
        Debug.Log("volume ="+volume);
        Debug.Log("dimension="+dimension);
        return dimension;
    }
}
