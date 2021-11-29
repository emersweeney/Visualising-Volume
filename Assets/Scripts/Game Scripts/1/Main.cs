using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* CONTROLLER SCRIPT - ADD TO MAIN CAMERA IN LEVEL 1 */
public class Main : MonoBehaviour
{ 
    [SerializeField] private GameObject mainShape, waterShape, character, smilingCharacter; //Prefabs to be instantiated by View
    [SerializeField] private Transform anchor; //anchor (whose position drag distance is measured from)
    [SerializeField] private Color winColour;
    [SerializeField] private float characterPositionFactor;
    private Model model;
    private View view;
    private float cameraZDistance; //mouse drag z coordinate set to this to ensure movement is detected
    private float minLength, maxLength, minHeight, maxHeight, yPos, previous_yPos;

    private int gameState; //0 = game not won, 1 = game won

    public int getGameState(){
        return gameState;
    }
    void Start()
    {
        gameState = 0;
        //create model and view instances with model-observer relationship
        model = new Model();
        view = new View();
        view.addSubject(model);

        //make shapes & overwrite references to point to newly created clones
        view.makeShapes(mainShape, waterShape);
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
        
        //randomise y position of target arrow, ensuring it is not the same as previous yPos OR current height of water shape
        while (yPos == previous_yPos || (yPos <= waterShape.transform.localScale.y+1/50f && yPos >= waterShape.transform.localScale.y-1/50f)){yPos = Random.Range(minHeight+1, maxHeight)/50f;}
        previous_yPos = yPos;

        view.makeCharacter(character, yPos, characterPositionFactor);
        character = view.getCharacter();
       /* view.makeTargetArrow(targetArrow,yPos);
        targetArrow = view.getTargetArrow();
        targetArrow.GetComponent<TargetAnimation>().setUp();

        view.makeDragArrow(dragArrow);
        dragArrow = view.getDragArrow(); */
    }

    public float getMinLength(){return minLength;}
    public float getMaxLength(){return maxLength;}

    //Method called when OnMouseDrag() runs in DragNotifier script, attached to mainShape    
    public void updateModel(){
        model.updateShapeModel(mainShape, waterShape);
    }

    private void Update() {
        if (gameState==0){
            //win condition
            // if (50f*targetArrow.transform.position.y-1 < waterShape.transform.localScale.y && waterShape.transform.localScale.y < 50f*targetArrow.transform.position.y+1){
            if (50f*yPos-1<waterShape.transform.localScale.y && waterShape.transform.localScale.y < 50f*yPos+1){
               gameComplete();
            }
        }
    }
    private void NextScene(){
        SceneManager.LoadScene(1);
    }

    private void gameComplete(){
                gameState = 1;
                Destroy(mainShape);
                Destroy(waterShape);
                view.makeSmilingCharacter(smilingCharacter);
                smilingCharacter = view.getSmilingCharacter();
                Destroy(character);
                StartCoroutine(endGameCoroutine());
                // Invoke("NextScene", 3f);
    }

    private IEnumerator endGameCoroutine()
    {   
        while (Vector3.Distance(Camera.main.transform.position,smilingCharacter.transform.position)>1.5f){
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, smilingCharacter.transform.position, 1f*Time.deltaTime);
            yield return null;
        }
    }
}
