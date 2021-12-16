using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBarScript : MonoBehaviour
{
    private GameObject bar;
    private float currentSize;
    public void setBar(ref GameObject bar){
        this.bar = bar;
        currentSize = 0;
    }

    // Update is called once per frame
    public void increment()
    {
        currentSize += 1/6f;
        bar.transform.localScale = new Vector3(currentSize, 1f);
    }
}
