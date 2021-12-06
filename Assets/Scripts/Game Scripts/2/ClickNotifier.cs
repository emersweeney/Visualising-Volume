using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ClickNotifier : MonoBehaviour
{
    private GameObject thisObject;

    private Main2 main;

    private void Start() {
        main = Camera.main.GetComponent<Main2>();        
    }
    private void OnMouseDown() {
        print("clicking");
        thisObject = gameObject;
        if (thisObject.transform.position.y==0f){
            main.resetSlider();
            main.setClickedObject(ref thisObject);
        }
    }


}
