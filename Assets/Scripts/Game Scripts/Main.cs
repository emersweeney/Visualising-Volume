using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
public class Main : MonoBehaviour
{ 
    [SerializeField] public GameObject mainShape, waterShape, targetArrow, dragArrow; //Prefabs to be instantiated by View
    [SerializeField] public Transform anchor; //anchor (whose position drag distance is measured from)
    private Model model;
    private View view;
    private float cameraZDistance; //mouse drag z coordinate set to this to ensure movement is detected
    private float minLength, maxLength, minHeight, maxHeight, yPos;
    void Start()
    {
        //create model and view instances
        model = new Model();
        view = new View();

        //make view an observer of model and model a subject of view
        view.addSubject(model);

        //pass view main shap & water shape prefab references for instantiation
        view.makeShapes(mainShape, waterShape);
        
        //overwrite references to contain clones and not prefabs
        mainShape = view.getMainShape(); 
        waterShape = view.getWaterShape();
        
        //get volume of water shape
        waterShape.GetComponent<ShapeVolume>().calculateVolume();

        cameraZDistance = Camera.main.ScreenToWorldPoint(mainShape.transform.position).z;
        model.setCameraZDistance(cameraZDistance);
        model.setStartDragScale(mainShape.transform.localScale);
        model.setAnchor(anchor);

        minLength = mainShape.transform.localScale.x/2f;
        maxLength = mainShape.transform.localScale.x*2f;
        minHeight = waterShape.GetComponent<ShapeVolume>().getMinHeight()/100f;
        maxHeight = waterShape.GetComponent<ShapeVolume>().getMaxHeight()/100f;
        // Debug.Log("minHeight="+minHeight);
        // Debug.Log("maxHeight="+maxHeight);
        
        //randomise y position of target arrow
        yPos = Random.Range(minHeight+1, maxHeight)/50f;
        // Debug.Log("yPos="+yPos);
        view.makeTargetArrow(targetArrow,yPos);
        targetArrow = view.getTargetArrow();
        targetArrow.GetComponent<TargetAnimation>().setUp();

        view.makeDragArrow(dragArrow);
        dragArrow = view.getDragArrow();
    }

    public float getMinLength(){return minLength;}
    public float getMaxLength(){return maxLength;}

    //Method called when OnMouseDrag() runs in DragNotifier script, attached to mainShape    
    public void updateModel(){
        // Debug.Log("updating - Main");
        model.updateShapeModel(mainShape, waterShape);
    }

    private void Update() {

        //win condition
        if (50f*targetArrow.transform.position.y-1 < waterShape.transform.localScale.y && waterShape.transform.localScale.y < 50f*targetArrow.transform.position.y+1){
            Debug.Log("WON ! ! ! !");
        }

        //go to level menu screen if won
    }
}
