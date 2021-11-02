using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class UI_Drag : MonoBehaviour
{
    /*/****************ATTEMPT 1****************
    public GameObject shape; //shape to be dragged & changed by user
    [SerializeField] public Vector3 minScale;
    bool startDrag; //indicator of whether drag in process or not
    private Vector3 offset, newSize;
    private Camera cam;
    private Vector3 lastMousePos;
    void Start(){cam = Camera.main;}
    void Update()
    {   if (startDrag)
        {   Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5;
            offset = cam.ScreenToWorldPoint(mousePos - shape.transform.localScale)/10;
            // offset = cam.ScreenToWorldPoint(Input.mousePosition - lastMousePos);
            newSize = new Vector3(shape.transform.localScale.x, shape.transform.localScale.y - offset.x,shape.transform.localScale.z); 
            
            if (newSize.y - minScale.y > 0){
                Debug.Log(newSize.y - minScale.y);
                shape.transform.localScale = newSize;
                transform.position = new Vector3(cam.WorldToScreenPoint(shape.transform.localScale).y/1000-0.15f, transform.position.y, transform.position.z); 
            }     
        }   
    }

    public void StartDragUI(){
        lastMousePos = Input.mousePosition;
        startDrag = true;
    }

    public void StopDragUI(){startDrag = false;}
} 
/*
Vector2 prevMousePosition;
[SerializeField] private GameObject scalableShape;
public float sizingFactor = 0.03f;
Vector3 minimumScale;

private void Start()
{
    minimumScale = new Vector3(1.0f, 1.0f, 1.0f);
}

void OnMouseDrag()
{
    Vector2 mousePosition = Input.mousePosition;

    transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

    Vector3 scale = scalableShape.transform.localScale;
    scale.x = scale.x + (mousePosition.x - prevMousePosition.x) * sizingFactor;
    scale.y = scale.x;
    scale.z = scale.x;
    scalableShape.transform.localScale = scale;

    if (scale.x < minimumScale.x)
    {
        scalableShape.transform.localScale = minimumScale;
    }

    prevMousePosition = mousePosition;
} 
}*/

    public Transform worldAnchor; 
    private Camera mainCamera;
    private float cameraZDistance;
    private Vector3 startDragScale;
    [SerializeField] public Vector3 originalScale;

    private void Start(){
        startDragScale = transform.localScale; //=cuboid scale
        mainCamera = Camera.main;
        cameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z; //=screen pos of z pos of transform
    }

    private void OnMouseDrag() {
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        float distance = Vector3.Distance(worldAnchor.position, mouseWorldPos); //distance anchor to mouse pos
        Debug.Log("D="+ distance);  
        Vector3 newScale = new Vector3(startDragScale.x, 150f*distance/4f, startDragScale.z); 
        if (distance>2){
            transform.localScale = newScale;
        }
        //cuboid change scale -> x=x,y=distance/2,z 

        Vector3 midPoint = (worldAnchor.position + mouseWorldPos)/2f;
        Debug.Log("M="+midPoint);
        float xOffset = transform.localScale.y - startDragScale.y;
        transform.position = new Vector3(xOffset/150, transform.position.y, transform.position.z);
        // transform.position = new Vector3(worldAnchor.position.x + transform.localScale.y/4f/15f, transform.position.y, transform.position.z);
      
        // Vector3 rotationDir = mouseWorldPos-worldAnchor.position;
        // transform.up = rotationDir;
    }
}