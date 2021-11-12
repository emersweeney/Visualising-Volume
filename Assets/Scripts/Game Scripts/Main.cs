using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Main : MonoBehaviour
{ 
    [SerializeField] public GameObject mainShape, waterShape; //Prefabs to be cloned by View
    [SerializeField] public Transform anchor;
    private Vector3 originalScale;
    private Model model;
    private View view;
    private float cameraZDistance;

    void Start()
    {
        model = new Model();
        view = new View();

        view.addSubject(model);
        view.makeShapes(mainShape, waterShape);
        mainShape = view.getMainShape(); //overwrite shape references to contain clones and not prefabs
        waterShape = view.getWaterShape();
        originalScale = mainShape.transform.localScale;
        cameraZDistance = Camera.main.ScreenToWorldPoint(mainShape.transform.position).z;

        model.setStartDragScale(mainShape.transform.localScale);
        model.setOriginalScale(originalScale);
        model.setCameraZDistance(cameraZDistance);
        model.setOriginalPosition(new Vector3(0,1,0));
        model.setAnchor(anchor);
    }


    //Method called when OnMouseDrag() runs in DragNotifier script, attached to mainShape    
    public void updateModel(){
        Debug.Log("updating - Main");
        model.updateShapeModel(mainShape, waterShape);
    }
}
