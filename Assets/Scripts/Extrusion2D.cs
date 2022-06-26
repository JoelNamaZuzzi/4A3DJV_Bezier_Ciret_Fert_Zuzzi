using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extrusion2D : MonoBehaviour
{
    public static Extrusion2D Instance;
    public List<GameObject> SelectedForExtrusion2d = new List<GameObject>();
    [SerializeField] private Dropdown dropdown;
    
    public List<GameObject> AllExtrudePoint = new List<GameObject>();
    
    Color c1 = Color.white;
    Color c2 = new Color(1, 1, 1, 0);
    
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void DrawBezierExtrude(GameObject go)
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        
        Color color = new Color(r, g, b, 1);
        
        //Debug.LogWarningFormat(go.name);

        for (int i = 0; i < go.transform.Find("PtsJau").childCount - 1; i++)
        {
            if (go.transform.Find("PtsJau").GetChild(i).gameObject.GetComponent<LineRenderer>())
            {
                Vector3 nextPos;
                if (i == go.transform.Find("PtsJau").childCount - 1 && go.transform.Find("PtsJau").childCount > 2)
                {
                    nextPos = go.transform.Find("PtsJau").GetChild(0).gameObject.transform.position;
                }
                else if (go.transform.Find("PtsJau").childCount == 2)
                {
                    break;
                }
                else {
                    nextPos = go.transform.Find("PtsJau").GetChild(i + 1).gameObject.transform.position; 
                }
                

                LineRenderer lnrdr = go.transform.Find("PtsJau").GetChild(i).gameObject.GetComponent<LineRenderer>();
                lnrdr.startWidth = 0.1f;
                lnrdr.endWidth = 0.1f;
                lnrdr.positionCount = 2;
                lnrdr.useWorldSpace = true;
                lnrdr.SetPosition(0, go.transform.Find("PtsJau").GetChild(i).gameObject.transform.position);
                lnrdr.SetPosition(1, nextPos);

            }
        }
    }
    
    public void Extrusion2d()
    {
        if (SelectedForExtrusion2d.Count == 1)
        {
            int degree = 0;
            
            if (dropdown.value == 0)
            {
                degree = 20;
            }
            if (dropdown.value == 1)
            {
                degree = 45;
            }
            if (dropdown.value == 2)
            {
                degree = 60;
            }
            if (dropdown.value == 3)
            {
                degree = 75;
            }
            if (dropdown.value == 4)
            {
                degree = 90;
            }

            for (int l = 0; l < SelectedForExtrusion2d[0].transform.Find("PtsJau").childCount; l++)
            {
                AllExtrudePoint.Add(SelectedForExtrusion2d[0].transform.Find("PtsJau").GetChild(l).gameObject);
            }

            for (int i = degree; i < 360; i += degree )
            {
                GameObject BezierCopie = Instantiate(SelectedForExtrusion2d[0], SelectedForExtrusion2d[0].transform.position, Quaternion.identity);
                BezierCopie.name = SelectedForExtrusion2d[0].name + "Extrude" + i;

                var sin = Mathf.Sin(i * Mathf.Deg2Rad);
                var cos = Mathf.Cos(i * Mathf.Deg2Rad);

                for (int j = 0; j < BezierCopie.transform.Find("PtsJau").childCount; j++)
                {
                    Vector3 pos = new Vector3();
                    
                    pos.x = (BezierCopie.transform.Find("PtsJau").GetChild(j).position.x * cos);
                    pos.y = BezierCopie.transform.Find("PtsJau").GetChild(j).position.y;
                    pos.z = (BezierCopie.transform.Find("PtsJau").GetChild(j).position.x * sin) + SelectedForExtrusion2d[0].transform.Find("PtsJau").GetChild(0).position.z;//GameObject.Find("PtsPivot").transform.position.z)
                    
                    BezierCopie.transform.Find("PtsJau").GetChild(j).position = pos;
                    
                    AllExtrudePoint.Add(BezierCopie.transform.Find("PtsJau").gameObject);
                }
                
                foreach (Transform child in BezierCopie.transform.Find("PtsControle")) {
                    Destroy(child.gameObject);
                }

                Factory.Instance.SelectedBezier = BezierCopie;
                Factory.Instance.Container = BezierCopie.transform.Find("PtsControle").gameObject;
                Factory.Instance.JauPointHolder = BezierCopie.transform.Find("PtsJau").gameObject;
                Factory.Instance.FirstJau = BezierCopie.GetComponent<Bez>().FirstJau;
                Factory.Instance.Beziers.Add(BezierCopie);
                ContentAdd.Instance.CreateBez(BezierCopie);
                DrawBezierExtrude(BezierCopie);
            }

        }
    }
}
