using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite_Volume
{
    private GameObject testObject;
    private float expectedVolume;

    [Test]
    public void CuboidVolume(){
        CuboidVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCuboid"));
        testScript = testObject.GetComponent<CuboidVolume>();
        expectedVolume = Mathf.Abs(testObject.transform.localScale.x*testObject.transform.localScale.y*testObject.transform.localScale.z);
        testScript.calculateVolume();
        Assert.AreEqual(expectedVolume, testScript.getVolume());
    }

    [Test]
    public void CylinderVolume(){
        CylinderVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCylinder"));
        testScript = testObject.GetComponent<CylinderVolume>();
        expectedVolume = Mathf.Abs(Mathf.PI*Mathf.Pow(testObject.transform.localScale.x/2, 2f)*testObject.transform.localScale.z);
        testScript.calculateVolume();
        Assert.AreEqual(expectedVolume, testScript.getVolume());
    }
/*
    [Test]
    public void ConeVolume(){
        ConeVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/WaterCone"));
        testScript = testObject.GetComponent<ConeVolume>();
        expectedVolume = Mathf.Abs((1f/3)*Mathf.PI*Mathf.Pow(testObject.transform.localScale.x/2, 2f)*testObject.transform.localScale.z);
        testScript.calculateVolume();
        Assert.AreEqual(expectedVolume, testScript.getVolume());
    } */
}
