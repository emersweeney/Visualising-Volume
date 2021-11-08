using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Model is a SUBJECT (of View)
 * Model is prompted by Main (Controller) to update shape positions and scales in response
 * to user input
 * Model then notifies OBSERVERS (View) so display can be updated with new positions and scales
 */
public class Model : Subject
{
    private Vector3 newMainPosition, newWaterPosition;
    private Vector3 newMainScale, newWaterScale, tempNewScale;
    private Vector3 mouseScreenPos, mouseWorldPos;
    private Transform anchor;
    private List<Observer> observers = new List<Observer>();
    private float distance, cameraZDistance, xOffset;
    private Vector3 startDragScale, originalScale, originalPosition, midPoint;

    // Getter methods for shape positions and scales
    public Vector3 getMainPos(){
        return newMainPosition;
    }

    public Vector3 getWaterPos(){
        return newWaterPosition;
    }

    public Vector3 getMainScale(){
        return newMainScale;
    }

    public Vector3 getWaterScale(){
        return newWaterScale;
    }

    //Set methods for startDragScale, originalScale, cameraZDistance and anchor
    public void setStartDragScale(Vector3 scale){
        this.startDragScale = scale;
    }

    public void setOriginalScale(Vector3 originalScale){
        this.originalScale = originalScale;
    }

    public void setOriginalPosition(Vector3 originalPosition){
        this.originalPosition = originalPosition;
    }

    public void setCameraZDistance(float zDistance){
        this.cameraZDistance = zDistance;
    }

    public void setAnchor(Transform anchor){
        this.anchor = anchor;
    }

    // Methods for adding and notifying observers
    public void attach(Observer o){
        observers.Add(o);
    }

    public void notify(){
        foreach (Observer o in observers)
        {
            o.notifyMe(newMainPosition, newWaterPosition, newMainScale, newWaterScale);
        }
    }

    /* Method to calculate new shape positions and scales
     * Takes GameObjects mainShape and waterShape as parameters
     * Notifies observers (prompting display to update)
     */
     public void updateShapeModel(GameObject mainShape, GameObject waterShape){
        //  Debug.Log("updating - Model");
        
        mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Debug.Log(mouseWorldPos);
        distance = Vector3.Distance(anchor.position, mouseWorldPos); //distance anchor to mouse pos
        // distance = mouseWorldPos.x - anchor.x;
        tempNewScale = new Vector3(startDragScale.x/50f + 5f*distance, startDragScale.y, startDragScale.z); 
        // if (tempNewScale.y >= originalScale.y){
            newMainScale = tempNewScale;
        // }
        Debug.Log(tempNewScale);
    
        midPoint = (anchor.position + mouseWorldPos)/2f;
        // xOffset = mainShape.transform.localScale.y - startDragScale.y;
        // newMainPosition = new Vector3(xOffset/150, mainShape.transform.position.y, mainShape.transform.position.z);
        newMainPosition = new Vector3((startDragScale.x/50f + 5f*distance)/100f, mainShape.transform.position.y, mainShape.transform.position.z);
        // Debug.Log(newMainPosition);
        notify();
     }
}
