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
            //Debug.Log(Input.mousePosition);
            //RaycastHit Hit;
            Vector3 mousepos = Input.mousePosition;
            mousepos.z += dist;
            Vector3 Pos = cam.ScreenToWorldPoint(mousepos);
            Factory.Instance.SpawnControlPoint(Pos);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Bite");
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            //Vector3 mousepos = Input.mousePosition;
            //Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //Vector3 Pos = cam.ScreenToWorldPoint(fwd);
            //bool HitPts = Physics.Raycast(transform.position, Pos, out Hit, 1000, 6);
            if (Physics.Raycast(ray, out Hit))
            {
                
                Debug.Log(Hit.collider.gameObject.name);
            }
        }
    }
}
