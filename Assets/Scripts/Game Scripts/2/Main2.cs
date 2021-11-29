using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;
// using System.Collections.Generic.Dictionary;

/* CONTROLLER SCRIPT - ADD TO MAIN CAMERA IN LEVEL 2 */
public class Main2 : MonoBehaviour
{
    [SerializeField] private GameObject mainObject, bar;
    [SerializeField] private Slider slider;
    private GameObject clickedObject;
    private Model2 model;
    private View2 view;
    private List<float> mainSizes;
    private float size;
    private int index;
    private List<GameObject> smallObjectsList;
    private Dictionary<GameObject, int> smallObjectsMap;

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

        smallObjectsList = new List<GameObject>();
        foreach (GameObject item in smallObjectsList)
        {
            Debug.Log(item.name);
        }
        //set up small Objects: choose random amount
        //
        // smallObjectsList = new List<GameObject>{small1, small2, small3, small4, small5, small6};
        // index = Random.Range(1,smallObjectsList.Count);
        // for (int i = 0; i < index; i++)
        // {
        //     smallObjectsMap.Add(smallObjectsList[i],1);            
        // }
        // for (int i = index; index < smallObjectsList.Count; i++){
        //     Destroy(smallObjectsList[i]);
        // }
        //pass water level bar to WaterBar script, by reference
        bar.GetComponent<BarScript>().setBar(ref bar);
    }
    //be notified of what object has been clicked
    public void setClickedObject(ref GameObject clickedObject){
        if (this.clickedObject != null && (clickedObject = this.clickedObject)) return;
        this.clickedObject = clickedObject;
        model.receiveClickedObject(ref clickedObject, clickedObject.transform.position);
        view.receiveClickedObject(ref clickedObject);
    }

    public ref Model2 GetModel2(){
        return ref model;
    }

    public void resetSlider(){
        slider.GetComponent<SliderScript>().reset();
    }

    public void pour(ref GameObject clickedObject){

        //call model method for bucket
        //view observes model & makes changes

    }
    
        //call model method for bath
        //view observes model & makes changes

    //called every frame, check for end condition
    private void Update(){
        if (model.smallIsEmpty(ref clickedObject)) {
            print("empty");
            bar.GetComponent<BarScript>().increment();
            print(bar.transform.localScale.y);
            view.returnSmallToOriginal();
            clickedObject = null;
        }
    }

    //make mainObject of random size, from list of possible sizes
    private void setUpMain(){
        mainSizes = new List<float>{0.8f,1.0f,1.2f,1.4f,1.6f,1.8f};
        index = Random.Range(0, mainSizes.Count);
        size = (float)mainSizes[index];
        view.sizeMainObject(ref mainObject, size);
    }

    public void receiveSmallObject(ref GameObject item){
        smallObjectsList.Add(item);
    }

}
