using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public GameObject Selectedbtn;
    public GameObject FirstJau;

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

        FirstJau = Points[0];
        SelectedBezier.GetComponent<Bez>().FirstJau = FirstJau;
        for (int i = 0; i<Points.Count-1; i++)
        {
            GameObject pts = Points[i];
            pts.GetComponent<JauPts>().nextChild = Points[i + 1];
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
        
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        
        Color color = new Color(r, g, b, 1);

        GameObject.Find("Manager").GetComponent<MouseClick>().polygoneColor = color;
    }

    public void ClickDestroyBezButton()
    {
        if (Selectedbtn && SelectedBezier)
        {
            Destroy(SelectedBezier);
            Destroy(Selectedbtn);
        }
        else
        {
            Debug.Log("Select Bezier via btn");
        }
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
        Color c1 = Color.white;
        Color c2 = new Color(1, 1, 1, 0);
        GameObject CurJau = FirstJau;
        while (CurJau.GetComponent<JauPts>().nextChild)
        {
            if (!CurJau.GetComponent<LineRenderer>())
            {
                Vector3 nextPos = CurJau.GetComponent<JauPts>().nextChild.transform.position;
                LineRenderer lnrdr = CurJau.AddComponent<LineRenderer>();
                lnrdr.material = new Material(Shader.Find("Sprites/Default"));
                lnrdr.SetColors(c1, c2);
                lnrdr.startColor = Color.blue;
                lnrdr.endColor = Color.blue;
                lnrdr.startWidth = 0.1f;
                lnrdr.endWidth = 0.1f;
                lnrdr.positionCount = 2;
                lnrdr.useWorldSpace = true;
                lnrdr.SetPosition(0, CurJau.transform.position);
                lnrdr.SetPosition(1, nextPos);
                CurJau = CurJau.GetComponent<JauPts>().nextChild;
            }
        }
        /*if (Points.Count >= 2)
        {
            for (int i = 0; i<Points.Count-1; i++)
            {
                
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
                    lnrdr.material = new Material(Shader.Find("Sprites/Default"));
                    lnrdr.SetColors(c1, c2);
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
        }*/
        Points.Clear();
    }
}
