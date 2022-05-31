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


        if (Input.GetKeyDown(KeyCode.Keypad8))
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
                child.position = TranformMatrice.RotateX(child.position, 1);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad2))
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
                child.position = TranformMatrice.RotateXInvercer(child.position, 1);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4))
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
                child.position = TranformMatrice.RotateY(child.position, 1);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad6))
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
                child.position = TranformMatrice.RotateYInvercer(child.position, 1);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad9))
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
                child.position = TranformMatrice.RotateZ(child.position, 1);
                child.position = new Vector3(child.position.x+bariX,child.position.y+bariY,child.position.z+bariZ);
            }
            
            GetComponent<MouseClick>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad3))
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
                child.position = TranformMatrice.RotateZInvercer(child.position, 1);
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

    public void GenerateMesh()
    {
        if (SelectedBezier && FirstJau)
        {

            float max_h = -100000;
            float min_h = 100000;
            float max_w = -100000;
            float min_w = 100000;
            float z = FirstJau.transform.position.z;
            GameObject MeshHolder = SelectedBezier.transform.Find("Mesh").gameObject;
            GameObject CurJau = FirstJau;

            while (CurJau)
            {
                if (CurJau.transform.position.x > max_w)
                {
                    max_w = CurJau.transform.position.x;
                }

                if (CurJau.transform.position.x < min_w)
                {
                    min_w = CurJau.transform.position.x;
                }

                if (CurJau.transform.position.y > max_h)
                {
                    max_h = CurJau.transform.position.y;
                }

                if (CurJau.transform.position.y < min_h)
                {
                    min_h = CurJau.transform.position.y;
                }

                CurJau = CurJau.GetComponent<JauPts>().nextChild;
            }

            Debug.Log("max w: " + max_w + " min w: " + min_w + " max h: " + max_h + " min h: " + min_h);
            MeshFilter meshFilter;
            if (!MeshHolder.GetComponent<MeshRenderer>())
            {
                MeshRenderer meshrdr = MeshHolder.AddComponent<MeshRenderer>();
                meshrdr.sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilter = MeshHolder.AddComponent<MeshFilter>();
            }
            else
            {
                meshFilter = MeshHolder.GetComponent<MeshFilter>();
            }

            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[4]
            {
                new Vector3(min_w, min_h, z),
                new Vector3(max_w, min_h, z),
                new Vector3(min_w, max_h, z),
                new Vector3(max_w, max_h, z)
            };

            mesh.vertices = vertices;

            int[] tris = new int[6]
            {
                // lower left triangle
                0, 2, 1,
                // upper right triangle
                2, 3, 1
            };
            mesh.triangles = tris;

            Vector3[] normals = new Vector3[4]
            {
                -Vector3.forward,
                -Vector3.forward,
                -Vector3.forward,
                -Vector3.forward
            };
            mesh.normals = normals;

            Vector2[] uv = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };
            mesh.uv = uv;

            meshFilter.mesh = mesh;
        }
        else
        {
            Debug.Log("Select Bezier with Generated curve");
        }
    }

    
}
