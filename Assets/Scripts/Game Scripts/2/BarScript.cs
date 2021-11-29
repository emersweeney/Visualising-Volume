using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private GameObject bar;
    private float currentSize;
    private int counter;
    public void setBar(ref GameObject bar){
        this.bar = bar;
        currentSize = 0;
        bar.transform.localScale = new Vector3(bar.transform.localScale.x, 0, bar.transform.localScale.z);
        counter = 0;
    }

    public void increment()
    {
        if (counter == 5) currentSize = 1;
        else currentSize += 1/6f;
        bar.transform.localScale = new Vector3(bar.transform.localScale.x, currentSize, bar.transform.localScale.z);
        counter += 1;
    }
}
