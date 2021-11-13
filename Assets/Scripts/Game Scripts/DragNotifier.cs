using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class DragNotifier : MonoBehaviour
{   
    private void OnMouseDrag() {
        // Debug.Log("dragging");
        Camera.main.GetComponent<Main>().updateModel();
    }
}
