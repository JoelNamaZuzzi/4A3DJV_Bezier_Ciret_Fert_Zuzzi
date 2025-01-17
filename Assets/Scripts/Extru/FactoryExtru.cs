using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryExtru : MonoBehaviour
{
    public static FactoryExtru Instance;
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
            
            GetComponent<MouseClickExtru>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(-0.1f,0,0));
            }
            
            GetComponent<MouseClickExtru>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(0,-0.1f,0));
            }
            
            GetComponent<MouseClickExtru>().ReUpdatePolygone();
            ClickGenerate();
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            foreach (Transform child in Container.transform)
            {
                child.position = TranformMatrice.Translate(child.position, new Vector3(0.1f,0,0));
            }
            
            GetComponent<MouseClickExtru>().ReUpdatePolygone();
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
            
            GetComponent<MouseClickExtru>().ReUpdatePolygone();
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

        CastelExtru.Instance.pointDeBase = ToJau;
        CastelExtru.Instance.Jau();

        foreach (Vector3 pos in CastelExtru.Instance.pointIntermediaire)
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
        Points.Clear();
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

            GetComponent<MouseClick>().ReUpdatePolygone();

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

            int nbPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsControle").childCount;
            GameObject lastPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsControle").GetChild(nbPointinBezier1 - 1).gameObject;

            GameObject firstPointinBezier2 = SelectedForRaccordC0[1].transform.Find("PtsControle").GetChild(0).gameObject; ;

            //firstPointinBezier2.transform.position = lastPointinBezier1.transform.position;
            SpawnControlPoint(lastPointinBezier1.transform.position, lastPointinBezier1.GetComponent<UselessScript>().importance);

            int nbPointinBezier2 = SelectedForRaccordC0[1].transform.Find("PtsControle").childCount;
            GameObject lastPointinBezier2 = SelectedForRaccordC0[1].transform.Find("PtsControle").GetChild(nbPointinBezier2 - 1).gameObject;

            lastPointinBezier2.transform.SetSiblingIndex(0);

            GameObject avantdernierPointinBezier1 = SelectedForRaccordC0[0].transform.Find("PtsControle").GetChild(nbPointinBezier1 - 2).gameObject;

            Vector3 newPoint = 2 * lastPointinBezier2.transform.position - avantdernierPointinBezier1.transform.position;

            SpawnControlPoint(newPoint, 1);

            int nbPointinBezier2v2 = SelectedForRaccordC0[1].transform.Find("PtsControle").childCount;
            GameObject lastPointinBezier2v2 = SelectedForRaccordC0[1].transform.Find("PtsControle").GetChild(nbPointinBezier2v2 - 1).gameObject;
            lastPointinBezier2v2.transform.SetSiblingIndex(1);


            Debug.LogWarningFormat(lastPointinBezier1 + " " + firstPointinBezier2);
        }
        else
        {
            Debug.LogError("Pas assez de bezier");
        }
    }
}
