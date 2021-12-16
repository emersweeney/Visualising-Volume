using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour, TargetAnimation
{
    float min, max, yPos, zPos;

    private float smoothing = 2f;
    private Vector3 target, start;
    private Scene currentScene;

    public void setUp() {
        max = -transform.localScale.x/2f;
        min = -transform.localScale.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        target = new Vector3(max, yPos, zPos);
        start = transform.position;
        currentScene = SceneManager.GetActiveScene();
        StartCoroutine(aniCoroutine()); 
  
    }
    public IEnumerator aniCoroutine()
    {   
        while (SceneManager.GetActiveScene() == currentScene){
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
}
