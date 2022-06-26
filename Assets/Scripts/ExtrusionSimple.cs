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
        
    }
    
    private void SelectBez(GameObject Bezier)
    {
        Factory.Instance.SelectedBezier = Bezier;
        Factory.Instance.Container = Bezier.transform.Find("PtsControle").gameObject;
        Factory.Instance.JauPointHolder = Bezier.transform.Find("PtsJau").gameObject;
        Factory.Instance.Selectedbtn = gameObject;
        Factory.Instance.FirstJau = Bezier.GetComponent<Bez>().FirstJau;
    }
}
