using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Script to be attached to *** Draggable object ***
 * GameObject variable to be set to parent shape that will be manipulated by user
 * Draggable object acts as a point on the parent shape that can be used to drag a face/edge of shape
 * Any transformation performed on draggable object is performed on the parent shape
 */
public class ScaleShape : MonoBehaviour
{
    public GameObject shape;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {

            shape.transform.localScale = new Vector3(1, 50, 100);
        }
    }
}
