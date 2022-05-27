using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    public Camera cam;
    public float dist=2;
    public GameObject Container;
    
    [SerializeField] private InputField inputField;
    void Update()
    {
        Debug.LogWarningFormat(inputField.text);
        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 1; i <= int.Parse(inputField.text); i++)
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
                CreatePolygone();
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

    public void CreatePolygone()
    {
        if (Container.transform.childCount > 1)
        {

            for (int i = 0; i < Container.transform.childCount-1; i++)
            {

                if (!Container.transform.GetChild(i).gameObject.GetComponent<LineRenderer>())
                {
                    Vector3 nextPos; 
                    nextPos = Container.transform.GetChild(i + 1).gameObject.transform.position;


                    LineRenderer lnrdr = Container.transform.GetChild(i).gameObject.AddComponent<LineRenderer>();
                    lnrdr.startColor = Color.green;
                    lnrdr.endColor = Color.green;
                    lnrdr.startWidth = 0.1f;
                    lnrdr.endWidth = 0.1f;
                    lnrdr.positionCount = 2;
                    lnrdr.useWorldSpace = true;
                    lnrdr.SetPosition(0, Container.transform.GetChild(i).gameObject.transform.position);
                    lnrdr.SetPosition(1, nextPos);

                }
            }
        }
    }
    
}
