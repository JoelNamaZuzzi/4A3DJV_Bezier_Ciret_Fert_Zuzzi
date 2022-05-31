using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    public GameObject Bezier;
    public Text txt;
    public bool Check = false;

    public void SetText()
    {
        txt.text = Bezier.name;
    }
    public void SelectBez()
    {
        Factory.Instance.SelectedBezier = Bezier;
        Factory.Instance.Container = Bezier.transform.Find("PtsControle").gameObject;
        Factory.Instance.JauPointHolder = Bezier.transform.Find("PtsJau").gameObject;
        Factory.Instance.Selectedbtn = gameObject;
        Factory.Instance.FirstJau = Bezier.GetComponent<Bez>().FirstJau;
    }

    public void OnCheckBox()
    {
        Check = !Check;
        if(Check == true)
        {
            Factory.Instance.SelectedForRaccordC0.Add(Bezier);
        }
        if (Check == false)
        {
            Factory.Instance.SelectedForRaccordC0.Remove(Bezier);
        }
    }
}
