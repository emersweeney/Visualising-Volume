using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  HANDLING TRIGGER ON TARGET ACTIVATED */
public class Target : MonoBehaviour
{
    private bool targetHit = false;
    public bool hitTheTarget { 
        get => targetHit; 
        set => targetHit = value; 
    }
    void Update()
    {
        /*IF TARGET HIT, MOVE TO NEXT SCENE*/
        if(targetHit){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
           // if(currentSceneIndex<SceneManager.sceneCount-1){}
            SceneManager.LoadScene(currentSceneIndex + 1);
            //}
        }
    }
}
