using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ACTIVATE TARGET TO INDICATE LEVEL WON
 *  SETS BOOLEAN 'targetHit' in Target SCRIPT AS true; */
public class TargetTrigger : MonoBehaviour
{
    public Target target;

    private void OnTriggerEnter(Collider other)
    {
        target.hitTheTarget = true;
    }

    private void OnTriggerExit(Collider other)
    {}
}
