using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{

    public static Factory Instance;
    //Container = PtsControl Holder for a single Bez
    public GameObject Container;
    public GameObject PtsControl;
    public GameObject PtsJau;
    public GameObject BezierPrefab;
    public List <GameObject> Points=new List<GameObject>();
    public List<GameObject> Beziers = new List<GameObject>();
    public List<Transform> ToJau = new List<Transform>();
    public GameObject SelectedPoint;
    public GameObject SelectedBezier;
    public GameObject JauPointHolder;
    public int CounterBez;
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Delete)||Input.GetKeyDown(KeyCode.Backspace))&&(SelectedPoint))
        {
            Destroy(SelectedPoint);
            SelectedPoint = null;
        }
    }

    public void ChangeBezier()
    {
        Container = SelectedPoint.transform.parent.gameObject;
        SelectedBezier = Container.transform.parent.gameObject;
        JauPointHolder = SelectedBezier.transform.Find("PtsJau").gameObject;

    }
    
    public void SpawnControlPoint(Vector3 pos)
    {
        Debug.Log("Spawn");
        var pts = Instantiate(PtsControl, new Vector3(pos.x,pos.y, pos.z),Quaternion.identity);
        pts.transform.parent = Container.transform;
        
        //Points.Add(pts);
        //NewLine();
    }

    public void ClickGenerate()
    {
        DestroyCurve();
        foreach (Transform child in Container.transform)
        {
            ToJau.Add(child.transform);
        }

        Castel.Instance.pointDeBase = ToJau;
        Castel.Instance.Jau();

        foreach (Vector3 pos in Castel.Instance.pointIntermediaire)
        {
            GameObject pts = Instantiate(PtsJau, pos, Quaternion.identity);
            pts.transform.parent = JauPointHolder.transform;
            Points.Add(pts);
        }
        
        NewLine();
        ToJau.Clear();
    }

    public void ClickNewBezier()
    {
        var NewBez = Instantiate(BezierPrefab, new Vector3(0f,0f,0f), Quaternion.identity);
        NewBez.name = "Bezier"+CounterBez;
        CounterBez++;
        Beziers.Add(NewBez);
        SelectedBezier = NewBez;
        JauPointHolder = SelectedBezier.transform.Find("PtsJau").gameObject;
        Container = SelectedBezier.transform.Find("PtsControle").gameObject;
        ContentAdd.Instance.CreateBez(NewBez);
    }
    
    public void DestroyCurve()
    {
        foreach (Transform JauPts in JauPointHolder.transform)
        {
            Destroy(JauPts.transform.gameObject);
        }
    }
    
    public void NewLine()
    {
        if (Points.Count >= 2)
        {
            for (int i = 0; i<Points.Count-1; i++)
            {
                //Debug.Log(Points[i]);
                //Debug.Log(i);
                if (!Points[i].GetComponent<LineRenderer>())
                {
                    Vector3 nextPos;
                    if (i == Points.Count - 1 && Points.Count > 2)
                    {
                        nextPos = Points[0].transform.position;
                    }
                    else if (Points.Count == 2)
                    {
                        break;
                    }
                    else
                    {
                        nextPos = Points[i + 1].transform.position;
                    }
                    LineRenderer lnrdr = Points[i].AddComponent<LineRenderer>();
                    lnrdr.startColor = Color.blue;
                    lnrdr.endColor = Color.blue;
                    lnrdr.startWidth = 0.1f;
                    lnrdr.endWidth = 0.1f;
                    lnrdr.positionCount = 2;
                    lnrdr.useWorldSpace = true;
                    lnrdr.SetPosition(0, Points[i].transform.position);
                    lnrdr.SetPosition(1, nextPos);

                }
            }
        }
        Points.Clear();
    }
}
