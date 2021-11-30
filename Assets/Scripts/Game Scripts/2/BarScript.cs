using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private GameObject bar;
    private float currentSize;
    private int counter, num;
    private bool barFull;
    public void setBar(ref GameObject bar){
        this.bar = bar;
        currentSize = 0;
        bar.transform.localScale = new Vector3(bar.transform.localScale.x, 0, bar.transform.localScale.z);
        counter = 0;
        barFull = false;
    }

    public void setNumSmallObjects(int num){
        this.num = num;
    }

    public void increment()
    {
        if (counter == num-1) currentSize = 1;
        else currentSize += 1f/num;
        bar.transform.localScale = new Vector3(bar.transform.localScale.x, currentSize, bar.transform.localScale.z);
        counter += 1;
        if (counter == num){barFull = true;}
    }

    public bool isBarFull(){
        return barFull;
    }

    public int getCount(){
        return counter;
    }
}
