using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWorld : MonoBehaviour{
	[Header("Tweaks")]
	[SerializeField] public Transform lookAt;
	// [SerializeField] public Vector3 offset;

	private Vector3 offset;

	[Header("Logic")]
	private Camera cam;

	private void Start(){
		cam = Camera.main;
	}

	private void Update(){
		//Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);
		//Debug.Log(lookAt.position.x);
		offset = lookAt.transform.localScale/2;
		Debug.Log(offset);
		offset.y = 2.5f; offset.z = transform.position.z;
		Vector3 pos = lookAt.position + offset;
		if (transform.position!=pos)
			transform.position = pos;
	}
}
