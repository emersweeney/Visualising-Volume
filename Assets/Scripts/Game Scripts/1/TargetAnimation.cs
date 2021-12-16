using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TargetAnimation
{
    public abstract void setUp();
    public abstract IEnumerator aniCoroutine();
}
