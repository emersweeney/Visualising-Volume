using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider thisSlider;
    private Model2 model;
    void Start()
    {
        thisSlider.onValueChanged.AddListener((var) => {
            model.updateClickedObject(var);
        });
    }

    public void receiveModel2(ref Model2 model){
        this.model = model;
    }

    public void reset(){
        thisSlider.SetValueWithoutNotify(0);
    }
}
