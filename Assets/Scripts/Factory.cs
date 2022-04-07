using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Jobs;

public class Factory : MonoBehaviour
{

    public static Factory Instance;
    public GameObject Container;
    public GameObject PtsControl;
    public List <GameObject> Points=new List<GameObject>();

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

    public void SpawnControlPoint(Vector3 pos)
    {
        Debug.Log("Spawn");
        var pts = Instantiate(PtsControl, new Vector3(pos.x,pos.y, pos.z),Quaternion.identity);
        pts.transform.parent = Container.transform;
        Points.Add(pts);
        NewLine();
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
    }
    
}
