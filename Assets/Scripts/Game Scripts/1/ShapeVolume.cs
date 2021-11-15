using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShapeVolume
{
    public abstract void calculateVolume();
    public abstract Vector3 calculateStartScale(Vector3 mainScale);
    public abstract Vector3 calculateNewScale(Vector3 mainScale);
    public abstract float getMinHeight();
    public abstract float getMaxHeight();
    public abstract void receiveMainShape(ref GameObject mainShape);
    public abstract void receiveDragDistance(float dragDistance);
}
