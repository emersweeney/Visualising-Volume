using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShapeVolume
{
    public abstract void calculateVolume();
    public abstract float calculateDimension();

    public abstract float getMinHeight();
    public abstract float getMaxHeight();
}
