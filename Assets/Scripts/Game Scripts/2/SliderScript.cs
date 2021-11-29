using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider thisSlider;
    private Model2 model;
    private float previousValue=0;
    void Start()
    {
        thisSlider.onValueChanged.AddListener((var) => {
            if (var>previousValue) {model.updateClickedObject(var);previousValue=var;}
            else {thisSlider.SetValueWithoutNotify(previousValue);}
        });
    }

    public void receiveModel2(ref Model2 model){
        this.model = model;
    }

    public void reset(){
        thisSlider.SetValueWithoutNotify(0);
        previousValue=0;
    }
}
