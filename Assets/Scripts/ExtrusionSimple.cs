using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtrusionSimple : MonoBehaviour
{
    private Factory facto;
    public Slider hauteur;
    public Text valHauteur;
    
    public Slider CoefA;
    public Text valCoefA;

    public int baseValue = 1;
    
    public int counterx=1;
    public int countery = 0;

    public Vector3[] To2D;
    public List<GameObject> AllExtrudePointSimple = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        hauteur.value = baseValue;
        valHauteur.text = "Hauteur " + hauteur.value;

        CoefA.value = baseValue;
        valCoefA.text = "Scale :" + CoefA.value;
        
        facto = Factory.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        valHauteur.text = "Hauteur : " + hauteur.value;
        valCoefA.text = "Scale : " + CoefA.value;
    }

    public void Extrude()
    {
        GameObject selectedbezier = facto.SelectedBezier;
        int counter = 0;
        foreach (Transform Child in facto.JauPointHolder.transform)
        {
            if(counter>=countery){
                countery++;
            }

            if (!AllExtrudePointSimple.Contains(Child.gameObject))
            {
                AllExtrudePointSimple.Add(Child.gameObject);
            }

            counter++;
        }

        counterx ++;
        GameObject Extrude = Instantiate(selectedbezier, selectedbezier.transform.position, Quaternion.identity);
        
        Extrude.name = "ExtrudeSimple" + selectedbezier.name;
        
        SelectBez(Extrude);
        
        foreach (Transform child in facto.Container.transform)
        {
            child.position = TranformMatrice.Scale(child.position, CoefA.value);
        }
        
        foreach (Transform child in facto.Container.transform)
        {
            child.position = TranformMatrice.Translate(child.position, new Vector3(0,hauteur.value,0));
        }
        
        facto.gameObject.GetComponent<MouseClick>().ReUpdatePolygone();
        facto.ClickGenerate();
        
        SelectBez(selectedbezier);
        
        /*for (int l = 0; l < selectedbezier.transform.Find("PtsJau").childCount; l++)
        {
            AllExtrudePointSimple.Add(selectedbezier.transform.Find("PtsJau").GetChild(l).gameObject);
        }*/
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
 
            for (int k = 0; k < Extrude.transform.Find("PtsJau").childCount; k++)
            {
                Debug.LogWarningFormat(Extrude.transform.Find("PtsJau").GetChild(k).gameObject.name);
                if (Extrude.transform.Find("PtsJau").GetChild(k) != null)
                {
                    AllExtrudePointSimple.Add(Extrude.transform.Find("PtsJau").GetChild(k).gameObject);
                }
            }
        }

        StartCoroutine(ExecuteAfterTime(10));


    }
    
    private void SelectBez(GameObject Bezier)
    {
        Factory.Instance.SelectedBezier = Bezier;
        Factory.Instance.Container = Bezier.transform.Find("PtsControle").gameObject;
        Factory.Instance.JauPointHolder = Bezier.transform.Find("PtsJau").gameObject;
        Factory.Instance.Selectedbtn = gameObject;
        Factory.Instance.FirstJau = Bezier.GetComponent<Bez>().FirstJau;
    }

    public void To2DList()
    {
        To2D = new Vector3[((counterx+1) * (countery+1))];
        for (int i = 0; i < AllExtrudePointSimple.Count; i++)
        {
            To2D[i] = AllExtrudePointSimple[i].transform.position;
        }

        facto.SelectedBezier.GetComponent<Grid>().vertices = To2D;
        facto.SelectedBezier.GetComponent<Grid>().Xsize = counterx;
        facto.SelectedBezier.GetComponent<Grid>().Ysize = countery;
        facto.SelectedBezier.GetComponent<Grid>().Generate();
    }
}
