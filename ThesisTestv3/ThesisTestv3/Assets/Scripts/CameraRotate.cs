using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

	public bool mouseClickJudgeLeft = false;
	public bool mouseClickJudgeRight = false;

	public Transform pivot;
	public float cameraRotateSpeed = 5.0f;

	public Vector3 minusX = new Vector3 (-90f, 0f, 0f);
	public Vector3 plusX = new Vector3 (90f, 0f, 0f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		if ( Input.GetMouseButtonDown( 0 ) ) {
			mouseClickJudgeLeft = true; 
		} 
		if ( Input.GetMouseButtonUp( 0 ) ) {
			mouseClickJudgeLeft = false; 
		} 
		if ( Input.GetMouseButtonDown( 1 ) ) {
			mouseClickJudgeRight = true; 
		} 
		if ( Input.GetMouseButtonUp( 1 ) ) {
			mouseClickJudgeRight = false; 
		} 
		if ( mouseClickJudgeLeft ) {
			transform.RotateAround( pivot.position, pivot.up, Input.GetAxis( "Mouse X" ) * cameraRotateSpeed ); 
		}
		if ( mouseClickJudgeRight ) {
			transform.RotateAround( pivot.position, pivot.right, Input.GetAxis( "Mouse Y" ) * cameraRotateSpeed );
		}
	}
}
