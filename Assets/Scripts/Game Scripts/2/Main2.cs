using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* CONTROLLER SCRIPT - ADD TO MAIN CAMERA IN LEVEL 2 */
public class Main2 : MonoBehaviour
{
    [SerializeField] private GameObject mainObject, mainWater, bar;
    [SerializeField] private Slider slider;
    [SerializeField] private Material cartoonWater;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button homeButton, instructionsButton;
    // [SerializeField] private Text instructionsButtonText;
    private GameObject clickedObject;
    private Model2 model;
    private View2 view;
    private List<float> mainSizes;
    private float size;
    private int index, numToFill, correctAnswer;
    private string displayMessage;
    private bool instructionsVisible;

    private void Start()
    {
        //create model2 and view2 instances with model-observer relationship
        model = gameObject.AddComponent<Model2>();
        view = gameObject.AddComponent<View2>();
        view.addSubject(model);

        //pass model to slider script, pass main object to model; both by reference
        slider.GetComponent<SliderScript>().receiveModel2(ref model);
        model.receiveMainObject(ref mainObject);

        //set up mainObject with random size
        setUpMain();

        //pass water level bar to WaterBar script, by reference, and number of small objects to fill main object
        bar.GetComponent<BarScript>().setBar(ref bar);
        bar.GetComponent<BarScript>().setNumSmallObjects(numToFill);

        //add listeners to Home and Instructions buttons
        homeButton.onClick.AddListener(goToHome);
        instructionsButton.onClick.AddListener(instructionsMethod);

        instructionsVisible = true;
        StartCoroutine(fadeInstructions());
    }

    //be notified of what object has been clicked
    public void setClickedObject(ref GameObject clickedObject){
        if (this.clickedObject != null && (clickedObject = this.clickedObject)) return;
        this.clickedObject = clickedObject;
        model.receiveClickedObject(ref clickedObject, clickedObject.transform.position);
        view.receiveClickedObject(ref clickedObject);
    }

    public void resetSlider(){
        slider.GetComponent<SliderScript>().reset();
    }

    private void Update(){
        if (model.smallIsEmpty(ref clickedObject)) {
            bar.GetComponent<BarScript>().increment();
            view.returnSmallToOriginal();
            clickedObject = null;
        }
        if (bar.GetComponent<BarScript>().isBarFull()) {
            view.makeMainFull(cartoonWater, ref mainWater);
            if (bar.GetComponent<BarScript>().getCount() == 6){
                correctAnswer = 1;
                displayMessage = "Tilly poured all of the buckets into Chase's bath and now it's full. What can hold more water?";
            }
            else {
                correctAnswer = 0;
                displayMessage = "Tilly poured all of the buckets into Chase's bath but it still isn't full. What can hold more water?";
            }
            endGame(correctAnswer, displayMessage);
        }
        else if(bar.GetComponent<BarScript>().getCount() == 6){
            correctAnswer = 2;
            displayMessage = "Chase's bath is full and Tilly didn't have to pour all of the buckets in. What can hold more water?";
            endGame(correctAnswer, displayMessage);
        }    
    }

    //make mainObject of random size, from list of possible sizes
    private void setUpMain(){
        mainSizes = new List<float>{0.8f, 0.9f, 1.0f, 1.1f, 1.4f, 1.5f, 1.6f};
        index = Random.Range(0, mainSizes.Count);
        size = (float)mainSizes[index];
        view.sizeMainObject(ref mainObject, size);
        numToFill = index+1;
    }


    private IEnumerator fadeInstructions(){
        yield return new WaitForSeconds(10f);
        this.GetComponent<UIFader>().fadeOut(canvasGroup);
        instructionsVisible = false;
        instructionsButton.GetComponentInChildren<Text>().text = "Show Instructions";
        // instructionsButtonText.text = "Show Instructions";
    }
    private void instructionsMethod(){
        if (instructionsVisible) fadeInstructionsOut();
        else fadeInstructionsIn();
        instructionsVisible = !instructionsVisible;
    }
    private void fadeInstructionsIn(){
        this.GetComponent<UIFader>().fadeIn(canvasGroup);
        instructionsButton.GetComponentInChildren<Text>().text = "Hide Instructions";
    }
    private void fadeInstructionsOut(){
        this.GetComponent<UIFader>().fadeOut(canvasGroup);
        instructionsButton.GetComponentInChildren<Text>().text = "Show Instructions";
    }
    private void goToHome(){
        SceneManager.LoadScene(0);
    }

    // private void endGame(int answer, string text){
    private void endGame(int answer, string text){
        GameState.correctAnswer = answer;
        GameState.displayMessage = text;
        this.gameObject.GetComponent<CharacterScript>().changeCharactersMaterial();
        StartCoroutine(callDecisionScene());
    }

    private IEnumerator callDecisionScene(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


}
