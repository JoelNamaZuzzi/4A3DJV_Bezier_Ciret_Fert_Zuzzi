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
    public bool Move;

    public Color polygoneColor;

    [SerializeField] private InputField inputField;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Move = false;
        }
        //Debug.LogWarningFormat(inputField.text);
        if (Input.GetMouseButtonDown(1))
        {
            if (Factory.Instance.SelectedBezier)
            {
                
                RaycastHit Hit;
                //Debug.Log(Input.mousePosition);
                Vector3 fwd = transform.TransformDirection(Vector3.forward);
                if (!Physics.Raycast(transform.position, fwd, out Hit, 1000, 5))
                {
                    Vector3 mousepos = Input.mousePosition;
                    mousepos.z += dist;
                    Vector3 Pos = cam.ScreenToWorldPoint(mousepos);
                    Factory.Instance.SpawnControlPoint(Pos, int.Parse(inputField.text) );
                }

                CreatePolygone();
                
            }
            else
            {
                Debug.Log("Select or create a Bezier !");
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
                Factory.Instance.SelectedPoint = Hit.transform.gameObject;
                Factory.Instance.ChangeBezier();
                //Debug.Log(Hit.transform);
            }
            else if (!Physics.Raycast(transform.position,Pos, out Hit, 1000) && Move && Factory.Instance.SelectedPoint)
            {
                Factory.Instance.SelectedPoint.transform.position = Pos;
                ReUpdatePolygone();
                Factory.Instance.ClickGenerate();
            }
            else
            {
                Factory.Instance.SelectedPoint = null;
            }
        }
    }

    public void ClickMove()
    {
        Move = !Move;
    }

    public void ReUpdatePolygone()
    {
        Container = Factory.Instance.Container;
        
        foreach (Transform pts in Container.transform)
        {
            if (pts.transform.gameObject.GetComponent<LineRenderer>())
            {
                Destroy(pts.transform.gameObject.GetComponent<LineRenderer>());
            }
        }
        CreatePolygone();
    }
    
    public void CreatePolygone()
    {
        Color c1 = Color.white;
        Color c2 = new Color(1, 1, 1, 0);

        Container = Factory.Instance.Container;
        
        if (Container.transform.childCount > 1)
        {

            for (int i = 0; i < Container.transform.childCount - 1; i++)
            {

                if (!Container.transform.GetChild(i).gameObject.GetComponent<LineRenderer>())
                {
                    Vector3 nextPos;
                    nextPos = Container.transform.GetChild(i + 1).gameObject.transform.position;

                    LineRenderer lnrdr = Container.transform.GetChild(i).gameObject.AddComponent<LineRenderer>();
                    lnrdr.material = new Material(Shader.Find("Sprites/Default"));
                    lnrdr.SetColors(c1, c2);
                    lnrdr.startColor = polygoneColor;
                    lnrdr.endColor = polygoneColor;
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
