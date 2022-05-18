using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Serialization;


[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{

    private Transform _xFrom_Camera;
    private Transform _XFrom_Parent;
    private Vector3 _Local_Rotation;

    [SerializeField, Range(1f, 100f)] private float distance = 5f;
    public float mouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitSpeed = 10f;

    private Vector3 focusPoint;

    private bool CameraDisabled = false;
    
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CameraDisabled = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            CameraDisabled = true;
        }

        //Zoom in and out
        if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

            ScrollAmount *= (distance * 0.3f);

            distance += ScrollAmount * -1f;

            //Constrain the minimum and maximum distance
            distance = Mathf.Clamp(distance, 1.5f, 100f);
        }
        
        Quaternion QT = Quaternion.Euler(_Local_Rotation.y, _Local_Rotation.x, 0);

        _XFrom_Parent.rotation = Quaternion.Lerp(_XFrom_Parent.rotation, QT, Time.deltaTime * OrbitSpeed);

        if (_xFrom_Camera.localPosition.z != distance * -1f)
        {
            _xFrom_Camera.localPosition = new Vector3(0, 0,
                Mathf.Lerp(_xFrom_Camera.localPosition.z, distance * -1f, Time.deltaTime * ScrollSensitivity));
        }

        //check if the orbit cam is on
        if (CameraDisabled) return;

        //Check if the mouse is moving
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            _Local_Rotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            _Local_Rotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            //Locks the rotation at 90 and 0 deg
            _Local_Rotation.y = Mathf.Clamp(_Local_Rotation.y, -50f, 90f);
        }
    }

    private void Start()
    {
        var transform1 = transform;
        _xFrom_Camera = transform1;
        _XFrom_Parent = transform1.parent;
    }
}
