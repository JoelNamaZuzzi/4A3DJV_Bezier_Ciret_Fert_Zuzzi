using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{

    public static Factory Instance;
    public GameObject Container;
    public GameObject PtsControl;
    public GameObject PtsJau;
    public List <GameObject> Points=new List<GameObject>();
    public List<Transform> ToJau = new List<Transform>();
    public GameObject Selected;

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
        if ((Input.GetKeyDown(KeyCode.Delete)||Input.GetKeyDown(KeyCode.Backspace))&&(Selected))
        {
            Destroy(Selected);
            Selected = null;
        }
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
        foreach (Transform child in Container.transform)
        {
            ToJau.Add(child.transform);
        }

        Castel.Instance.pointDeBase = ToJau;
        Castel.Instance.Jau();

        foreach (Vector3 pos in Castel.Instance.pointIntermediaire)
        {
            var pts = Instantiate(PtsJau, pos, Quaternion.identity);
            Points.Add(pts);
        }
        NewLine();
        ToJau.Clear();
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
