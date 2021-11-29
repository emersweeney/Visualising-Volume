using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite_Scale
{
    private GameObject testObject, testMainObject;
    private float oldVolume, newVolume;

    [Test]
    public void CuboidScale(){
        CuboidVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCuboid"));
        testMainObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/Cuboid"));
        testMainObject.transform.localScale = new Vector3(20,20,20);
        testScript = testObject.GetComponent<CuboidVolume>();
        testScript.calculateVolume();
        oldVolume = testScript.getVolume();
        Vector3 newScale = testScript.calculateNewScale(testMainObject.transform.localScale);
        testObject.transform.localScale = newScale;
        testScript.calculateVolume();
        newVolume = testScript.getVolume();
        Assert.AreEqual(Mathf.Abs(oldVolume), Mathf.Abs(newVolume));
    }

    [Test]
    public void CuboidNewDimension(){
        CuboidVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCuboid"));
        testMainObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/Cuboid"));
        testMainObject.transform.localScale = new Vector3(20,20,20);
        testScript = testObject.GetComponent<CuboidVolume>();
        testScript.calculateVolume();
        oldVolume = testScript.getVolume();
        Vector3 newScale = testScript.calculateNewScale(testMainObject.transform.localScale);
        testObject.transform.localScale = newScale;
        testScript.calculateVolume();
        newVolume = testScript.getVolume();
        Assert.AreEqual(Mathf.Abs(testObject.transform.localScale.y), Mathf.Abs(newVolume/testMainObject.transform.localScale.x/testMainObject.transform.localScale.z));
    }

    
    [Test]
    public void CylinderScale(){
        CylinderVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCylinder"));
        testMainObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/Cylinder"));
        testMainObject.transform.localScale = new Vector3(20,20,20);
        testScript = testObject.GetComponent<CylinderVolume>();
        testScript.calculateVolume();
        oldVolume = testScript.getVolume();
        Vector3 newScale = testScript.calculateNewScale(testMainObject.transform.localScale);
        testObject.transform.localScale = newScale;
        testScript.calculateVolume();
        newVolume = testScript.getVolume();
        Assert.AreEqual(Mathf.Abs(oldVolume), Mathf.Abs(newVolume));
    }

    [Test]
    public void CylinderNewDimension(){
        CylinderVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCylinder"));
        testMainObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/Cylinder"));
        testMainObject.transform.localScale = new Vector3(20,20,20);
        testScript = testObject.GetComponent<CylinderVolume>();
        testScript.calculateVolume();
        oldVolume = testScript.getVolume();
        Vector3 newScale = testScript.calculateNewScale(testMainObject.transform.localScale);
        testObject.transform.localScale = newScale;
        testScript.calculateVolume();
        newVolume = testScript.getVolume();
        Assert.AreEqual(Mathf.Abs(testObject.transform.localScale.y), Mathf.Abs(newVolume/Mathf.PI/Mathf.Pow(testMainObject.transform.localScale.x/2f,2f)));
    }
/*
    [Test]
    public void ConeScale(){
        ConeVolume testScript;
        testObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/WaterCone"));
        testMainObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Objects/GameObjects/1/Cone"));
        testMainObject.transform.localScale = new Vector3(20,20,20);
        testScript = testObject.GetComponent<ConeVolume>();
        testScript.calculateVolume();
        oldVolume = testScript.getVolume();
        Vector3 newScale = testScript.calculateNewScale(testMainObject.transform.localScale);
        testObject.transform.localScale = newScale;
        testScript.calculateVolume();
        newVolume = testScript.getVolume();
        Assert.AreEqual(Mathf.Abs(oldVolume), Mathf.Abs(newVolume));
    } */
}
