using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ClickNotifier : MonoBehaviour
{
    private GameObject thisObject;
    [SerializeField] private string waterComponent, containerComponent; 
    private Main2 main;
    // [SerializeField] private Material glow;

    private void Start() {
        main = Camera.main.GetComponent<Main2>();        
    }
    private void OnMouseDown() {
        thisObject = gameObject;
        if (thisObject.transform.position.y==0f){
            main.resetSlider();
            main.setClickedObject(ref thisObject);
        }
    }


}
