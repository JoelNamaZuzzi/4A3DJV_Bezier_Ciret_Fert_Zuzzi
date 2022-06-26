using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extrusion2D : MonoBehaviour
{
    public static Extrusion2D Instance;
    public List<GameObject> SelectedForExtrusion2d = new List<GameObject>();
    [SerializeField] private Dropdown dropdown;
    
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public void Extrusion2d()
    {
        if (SelectedForExtrusion2d.Count == 1)
        {
            Debug.LogWarningFormat("Extrusion");

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
            
            for (int i = 45; i < 360; i += degree )
            {
                GameObject BezierCopie = Instantiate(SelectedForExtrusion2d[0], SelectedForExtrusion2d[0].transform.position, Quaternion.identity);
                BezierCopie.name = SelectedForExtrusion2d[0].name + "Extrude"+i;
                Factory.Instance.Beziers.Add(BezierCopie);
                ContentAdd.Instance.CreateBez(BezierCopie);
                
                float r = Random.Range(0f, 1f);
                float g = Random.Range(0f, 1f);
                float b = Random.Range(0f, 1f);
        
                Color color = new Color(r, g, b, 1);

                GameObject.Find("Manager").GetComponent<MouseClick>().polygoneColor = color;

                //BezierCopie.transform.RotateAround(GameObject.Find("PtsPivot").transform.position, Vector3.up, i);

                /*foreach (Transform child in BezierCopie.transform.Find("PtsControle").gameObject.transform)
                {
                    float x = child.position.x * Mathf.Cos(i * Mathf.Deg2Rad) + child.position.z * Mathf.Sin(i * Mathf.Deg2Rad);
                    float y = child.position.y;
                    float z = child.position.z * Mathf.Cos(i * Mathf.Deg2Rad) - child.position.x * Mathf.Sin(i * Mathf.Deg2Rad);

                    Vector3 vec = new Vector3(x, y, z);
                    child.position = vec;

                }*/

                Factory.Instance.SelectedBezier = BezierCopie;
                Factory.Instance.Container = BezierCopie.transform.Find("PtsControle").gameObject;
                Factory.Instance.JauPointHolder = BezierCopie.transform.Find("PtsJau").gameObject;
                Factory.Instance.FirstJau = BezierCopie.GetComponent<Bez>().FirstJau;
                Factory.Instance.ClickGenerate();
                GetComponent<MouseClick>().CreatePolygone();

            }

        }
    }
}
