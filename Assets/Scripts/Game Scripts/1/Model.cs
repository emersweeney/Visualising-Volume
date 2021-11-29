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
    private float distance, cameraZDistance;
    private Vector3 startDragScale;

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
            o.notifyMe(new List<Vector3>{newMainPosition, newWaterPosition, newMainScale, newWaterScale});
        }
    }

    /* Method to calculate new shape positions and scales
     * Takes GameObjects mainShape and waterShape as parameters
     * Notifies observers (prompting display to update)
     */
     public void updateShapeModel(GameObject mainShape, GameObject waterShape){
        //  Debug.Log("updating - Model");
        
        //get mouse position in world space - using z-coordinate of main camera as movement will not be detected
        //with a 0 z-coordinate
        mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        // Debug.Log(mouseWorldPos);

        //distance from anchor to mouse position in world space
        distance = Vector3.Distance(anchor.position, mouseWorldPos); 
        float xDistance = mouseWorldPos.x - anchor.position.x;
        waterShape.GetComponent<ShapeVolume>().receiveDragDistance(xDistance);
        waterShape.GetComponent<ShapeVolume>().receiveMainShape(ref mainShape);

        //main object scale moves changes in x by distance dragged in x direction divided by 50 (to offset
        //difference between imported shape scale and unity default scale 1)
        tempNewScale = new Vector3(xDistance*50f, startDragScale.y, startDragScale.z); 
        newMainScale = tempNewScale;

        newMainPosition = new Vector3(-xDistance/2, mainShape.transform.position.y, mainShape.transform.position.z);
        // Debug.Log(newMainPosition);

        newWaterPosition = newMainPosition;

        newWaterScale = waterShape.GetComponent<ShapeVolume>().calculateNewScale(newMainScale);
        // newWaterScale = new Vector3(newMainScale.x, newD, newMainScale.z);
        notify();
     }
}
