using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer
{
    public abstract void addSubject(Subject subject);
    public abstract void notifyMe(List<Vector3> vectors);
    
    // public abstract void notifyMe(Vector3 newMainPosition, Vector3 newWaterPosition, Vector3 newMainScale, Vector3 newWaterScale);
}
