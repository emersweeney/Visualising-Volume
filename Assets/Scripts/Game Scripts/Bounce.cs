using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour, TargetAnimation
{
    float min, max, yPos, zPos;
    int indicator;

    private float smoothing = 1f;
    private Vector3 target, start;

    public void setUp() {
        max = -transform.localScale.x/2f;
        min = -transform.localScale.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        indicator = 0;
        target = new Vector3(max, yPos, zPos);
        start = transform.position;
        StartCoroutine(aniCoroutine());
  
    }
    public IEnumerator aniCoroutine()
    {   
        while (Vector3.Distance(transform.position,target)>0.05f){
            transform.position = Vector3.Lerp(transform.position, target, smoothing*Time.deltaTime);
            yield return null;
        }
        while (Vector3.Distance(start,transform.position)>0.05f){
            transform.position = Vector3.Lerp(transform.position, start, smoothing*Time.deltaTime);
            yield return null;
        }
    }
}
