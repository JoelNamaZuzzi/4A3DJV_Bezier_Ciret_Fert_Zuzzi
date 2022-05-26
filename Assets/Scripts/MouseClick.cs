using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseClick : MonoBehaviour
{
    public Camera cam;
    public float dist=2;
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit Hit;
            //Debug.Log(Input.mousePosition);
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!Physics.Raycast(transform.position, fwd, out Hit, 1000, 5))
            {
                Vector3 mousepos = Input.mousePosition;
                mousepos.z += dist;
                Vector3 Pos = cam.ScreenToWorldPoint(mousepos);
                Factory.Instance.SpawnControlPoint(Pos);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Vector3 mousepos = Input.mousePosition;
            mousepos.z += dist;
            Vector3 Pos = cam.ScreenToWorldPoint(mousepos);
            if (Physics.Raycast(transform.position,Pos, out Hit, 1000))
            {
                Factory.Instance.Selected = Hit.transform.gameObject;
                //Debug.Log(Hit.transform);
            }
            else
            {
                Factory.Instance.Selected = null;
            }
        }
    }
    
}
