using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject
{
   public abstract void attach(Observer o);

    public abstract void notify();
}
