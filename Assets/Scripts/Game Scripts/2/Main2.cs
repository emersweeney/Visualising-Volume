using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* CONTROLLER SCRIPT - ADD TO MAIN CAMERA IN LEVEL 2 */
public class Main2 : MonoBehaviour
{
    private GameObject clickedObject;
    [SerializeField] GameObject mainObject;
    [SerializeField] Slider slider;
    private Model2 model;
    private View2 view;

      void Start()
    {
        //create model2 and view2 instances with model-observer relationship
        model = gameObject.AddComponent<Model2>();
        view = gameObject.AddComponent<View2>();
        view.addSubject(model);

        slider.GetComponent<SliderScript>().receiveModel2(ref model);
        model.receiveMainObject(ref mainObject);

        //make bath of random size
        view.makeMainObject(ref mainObject);
    }

    public void setClickedObject(ref GameObject clickedObject){
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

    private void Update(){
        if ((clickedObject != null) && clickedObject.transform.position.z == mainObject.transform.position.z) {
            //call rotation animation +
        }
    }

}
