using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    public Transform target;
    private Vector3 previouspos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previouspos = Cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dir = previouspos - Cam.ScreenToViewportPoint(Input.mousePosition);
            Cam.transform.position = target.position;//new Vector3();
            Cam.transform.Rotate(new Vector3(1,0,0), dir.y*180);
            Cam.transform.Rotate(new Vector3(0,1,0),-dir.x*180, Space.World);
            Cam.transform.Translate(new Vector3(0,0,-10));

            previouspos = Cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
