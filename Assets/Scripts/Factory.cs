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
    public GameObject HullPrefab;
    public List <GameObject> Points=new List<GameObject>();
    public List<GameObject> Beziers = new List<GameObject>();
    public List<Transform> ToJau = new List<Transform>();
    public GameObject SelectedPoint;
    public GameObject SelectedBezier;
    public List<GameObject> SelectedForRaccordC0 = new List<GameObject>();
    public GameObject JauPointHolder;
    public int CounterBez;
    public GameObject Selectedbtn;
    public GameObject FirstJau;

    Color c1 = Color.white;
    Color c2 = new Color(1, 1, 1, 0);

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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(0,0.1f,0));
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(-0.1f,0,0));
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(0,-0.1f,0));
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(0.1f,0,0));
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }


        if (Input.GetKey(KeyCode.Keypad8))
        {

            float bariX = 0;
            float bariY = 0;
            float bariZ = 0;
            float count = 0;

            foreach (Transform child in Container.transform)
            {
                bariX += child.position.x;
                bariY += child.position.y;
                bariZ += child.position.z;
                count += 1;
            }

            if (count != 0)
            {
                bariX = 1/count * bariX; 
                bariY = 1/count * bariY;
                bariZ = 1/count * bariZ; 
            }
            
            
            foreach (Transform child in Container.transform)
            {
                child.position = new Vector3(child.position.x-bariX,child.position.y-bariY,child.position.z-bariZ); 
                child.position = TranformMatrice.RotateX(child.position, 10*Mathf.Deg2Rad);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.Keypad2))
        {
            float bariX = 0;
            float bariY = 0;
            float bariZ = 0;
            float count = 0;

            foreach (Transform child in Container.transform)
            {
                bariX += child.position.x;
                bariY += child.position.y;
                bariZ += child.position.z;
                count += 1;
            }

            if (count != 0)
            {
                bariX = 1/count * bariX; 
                bariY = 1/count * bariY;
                bariZ = 1/count * bariZ; 
            }

            foreach (Transform child in Container.transform)
            {
                child.position = new Vector3(child.position.x-bariX,child.position.y-bariY,child.position.z-bariZ); 
                child.position = TranformMatrice.RotateXInvercer(child.position, 10*Mathf.Deg2Rad);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.Keypad4))
        {
            float bariX = 0;
            float bariY = 0;
            float bariZ = 0;
            float count = 0;

            foreach (Transform child in Container.transform)
            {
                bariX += child.position.x;
                bariY += child.position.y;
                bariZ += child.position.z;
                count += 1;
            }

            if (count != 0)
            {
                bariX = 1/count * bariX; 
                bariY = 1/count * bariY;
                bariZ = 1/count * bariZ; 
            }

            foreach (Transform child in Container.transform)
            {
                child.position = new Vector3(child.position.x-bariX,child.position.y-bariY,child.position.z-bariZ); 
                child.position = TranformMatrice.RotateY(child.position, 10*Mathf.Deg2Rad);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.Keypad6))
        {
            float bariX = 0;
            float bariY = 0;
            float bariZ = 0;
            float count = 0;

            foreach (Transform child in Container.transform)
            {
                bariX += child.position.x;
                bariY += child.position.y;
                bariZ += child.position.z;
                count += 1;
            }

            if (count != 0)
            {
                bariX = 1/count * bariX; 
                bariY = 1/count * bariY;
                bariZ = 1/count * bariZ; 
            }

            foreach (Transform child in Container.transform)
            {
                child.position = new Vector3(child.position.x-bariX,child.position.y-bariY,child.position.z-bariZ); 
                child.position = TranformMatrice.RotateYInvercer(child.position, 10*Mathf.Deg2Rad);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.Keypad9))
        {

            float bariX = 0;
            float bariY = 0;
            float bariZ = 0;
            float count = 0;

            foreach (Transform child in Container.transform)
            {
                bariX += child.position.x;
                bariY += child.position.y;
                bariZ += child.position.z;
                count += 1;
            }

            if (count != 0)
            {
                bariX = 1/count * bariX; 
                bariY = 1/count * bariY;
                bariZ = 1/count * bariZ; 
            }
            
            foreach (Transform child in Container.transform)
            {
                child.position = new Vector3(child.position.x-bariX,child.position.y-bariY,child.position.z-bariZ); 
                child.position = TranformMatrice.RotateZ(child.position, 10*Mathf.Deg2Rad);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.Keypad3))
        {
            
            float bariX = 0;
            float bariY = 0;
            float bariZ = 0;
            float count = 0;

            foreach (Transform child in Container.transform)
            {
                bariX += child.position.x;
                bariY += child.position.y;
                bariZ += child.position.z;
                count += 1;
            }

            if (count != 0)
            {
                bariX = 1/count * bariX; 
                bariY = 1/count * bariY;
                bariZ = 1/count * bariZ; 
            }

            foreach (Transform child in Container.transform)
            {
                child.position = new Vector3(child.position.x-bariX,child.position.y-bariY,child.position.z-bariZ); 
                child.position = TranformMatrice.RotateZInvercer(child.position, 10*Mathf.Deg2Rad);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Scale(child.position, 0.2f);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.ScaleInverser(child.position, 0.2f);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }


    }

    public void ChangeBezier()
    {
        Container = SelectedPoint.transform.parent.gameObject;
        SelectedBezier = Container.transform.parent.gameObject;
        JauPointHolder = SelectedBezier.transform.Find("PtsJau").gameObject;

    }
    
    public void SpawnControlPoint(Vector3 pos, int importance)
    {
        Debug.Log("Spawn");
        var pts = Instantiate(PtsControl, new Vector3(pos.x,pos.y, pos.z),Quaternion.identity);
        pts.transform.parent = Container.transform;
        pts.GetComponent<UselessScript>().importance = importance;
        //Points.Add(pts);
        //NewLine();
    }

    public void ClickGenerate()
    {
        DestroyCurve();
        foreach (Transform child in Container.transform)
        {
            for (int i =0; i< child.transform.GetComponent<UselessScript>().importance; i++ )
            {
                ToJau.Add(child.transform);
            }
            
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

    public void GenerateMesh()
    {

        if (SelectedBezier && FirstJau)
        {
            List<GameObject> PtsToHull = new List<GameObject>();
            foreach (Transform PtsCont in Container.transform)
            {
                PtsToHull.Add(PtsCont.gameObject);
                if (PtsCont.Find("Hull"))
                {
                    Destroy(PtsCont.Find("Hull"));
                }
            }
            
            GameObject StartPTS = lowestX(PtsToHull);
            List<GameObject> PtsReturn = new List<GameObject>();
            PtsReturn.Add(StartPTS);
            GameObject CurPTS = StartPTS;
            int C = 0;
            while (true)
            {
                //Debug.Log("while");
                //PtsReturn.Add(CurPTS);
                GameObject NextTarget = PtsToHull[0];
                
                //Debug.Log(PtsToHull.Count);
                for (int i =1; i<PtsToHull.Count; i++)
                {
                    
                    if (CounterClock(CurPTS.transform.position, NextTarget.transform.position,
                            PtsToHull[i].transform.position) > 0f)
                    {
                        NextTarget = PtsToHull[i];
                    }
                }
                PtsReturn.Add(CurPTS);
                if (NextTarget == PtsReturn[0])
                {
                    Debug.Log("Debug");
                    break;
                }
            }
            PtsReturn.Add(PtsReturn[0]);
            List<GameObject> ToHull = new List<GameObject>();
            int j = 0;
            foreach (GameObject point in PtsReturn)
            {
                GameObject hull = Instantiate(HullPrefab, point.transform.position, point.transform.localRotation);
                hull.transform.parent = point.transform;
                hull.name = "hull" + j;
                ToHull.Add(hull);
                Debug.Log(hull.name);
                j++;
            }

            /*foreach (GameObject point in ToHull)
            {
                
            }*/
            
        }
    }

    public void RaccordC0()
    {
        if(SelectedForRaccordC0.Count>=2)
        {
            Debug.LogWarningFormat(SelectedForRaccordC0[0] + " " + SelectedForRaccordC0[1]);

            int nbPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsControle").childCount;
            GameObject lastPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsControle").GetChild(nbPointinBezier1 - 1).gameObject;

            GameObject firstPointinBezier2 = SelectedForRaccordC0[1].transform.Find("PtsControle").GetChild(0).gameObject; ;

            //firstPointinBezier2.transform.position = lastPointinBezier1.transform.position;
            SpawnControlPoint(lastPointinBezier1.transform.position, lastPointinBezier1.GetComponent<UselessScript>().importance);

            int nbPointinBezier2 = SelectedForRaccordC0[1].transform.Find("PtsControle").childCount;
            GameObject lastPointinBezier2 = SelectedForRaccordC0[1].transform.Find("PtsControle").GetChild(nbPointinBezier2 - 1).gameObject;

            lastPointinBezier2.transform.SetSiblingIndex(0);

            LineRenderer lnrdr = lastPointinBezier1.AddComponent<LineRenderer>();
            lnrdr.material = new Material(Shader.Find("Sprites/Default"));
            lnrdr.SetColors(c1, c2);
            lnrdr.startColor = Color.blue;
            lnrdr.endColor = Color.blue;
            lnrdr.startWidth = 0.1f;
            lnrdr.endWidth = 0.1f;
            lnrdr.positionCount = 2;
            lnrdr.useWorldSpace = true;
            lnrdr.SetPosition(0, lastPointinBezier1.transform.position);
            lnrdr.SetPosition(1, firstPointinBezier2.transform.position);


            Debug.LogWarningFormat(lastPointinBezier1 + " " + firstPointinBezier2);
        }
        else
        {
            Debug.LogError("Pas assez de bezier");
        }
    }

    public void RaccordC1()
    {
        if (SelectedForRaccordC0.Count >= 2)
        {
            Debug.LogWarningFormat(SelectedForRaccordC0[0] + " " + SelectedForRaccordC0[1]);

            int nbPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsJau").childCount;
            GameObject lastPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsJau").GetChild(nbPointinBezier1 - 1).gameObject;

            GameObject firstPointinBezier2 = SelectedForRaccordC0[1].GetComponent<Bez>().FirstJau;

            lastPointinBezier1.GetComponent<JauPts>().nextChild = firstPointinBezier2;

            LineRenderer lnrdr = lastPointinBezier1.AddComponent<LineRenderer>();
            lnrdr.material = new Material(Shader.Find("Sprites/Default"));
            lnrdr.SetColors(c1, c2);
            lnrdr.startColor = Color.blue;
            lnrdr.endColor = Color.blue;
            lnrdr.startWidth = 0.1f;
            lnrdr.endWidth = 0.1f;
            lnrdr.positionCount = 2;
            lnrdr.useWorldSpace = true;
            lnrdr.SetPosition(0, lastPointinBezier1.transform.position);
            lnrdr.SetPosition(1, firstPointinBezier2.transform.position);


            Debug.LogWarningFormat(lastPointinBezier1 + " " + firstPointinBezier2);
        }
        else
        {
            Debug.LogError("Pas assez de bezier");
        }
    }

    public static float CounterClock(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float x1 = p1.x - p2.x;
        float x2 = p1.x - p3.x;
        float y1 = p1.y - p2.y;
        float y2 = p1.x - p3.y;
        return (y2*x1)-(y1*x2);
    }
    
    public GameObject lowestX(List<GameObject> points)
    {
        GameObject pts= points[0];
        foreach (GameObject point in points)
        {
            if (point.transform.position.x < pts.transform.position.x)
            {
                pts = point;
            }
        }

        foreach (GameObject point in points) 
        {
            Transform trf = point.transform;
            if (point != pts && trf.position.x == pts.transform.position.x && trf.position.y < pts.transform.position.y)
            {
                pts = point;
            }
        }
        
        return pts;
    }
}
