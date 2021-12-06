using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBar : MonoBehaviour
{
    private Transform bar;
    private float currentSize;
    public void setBar(ref Transform bar){
        this.bar = bar;
        currentSize = 0;
    }

    // Update is called once per frame
    public void increment()
    {
        currentSize += 1/6f;
        bar.localScale = new Vector3(currentSize, 1f);
    }
}
