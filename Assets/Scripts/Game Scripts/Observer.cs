using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer
{
    public abstract void addSubject(Subject subject);
    public abstract void notifyMe(Vector3 mainPos, Vector3 waterPos, Vector3 mainScale, Vector3 waterScale);
}
