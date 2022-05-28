using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    public GameObject Bezier;
    public Text txt;

    public void SetText()
    {
        txt.text = Bezier.name;
    }
    public void SelectBez()
    {
        Factory.Instance.SelectedBezier = Bezier;
        Factory.Instance.Container = Bezier.transform.Find("PtsControle").gameObject;
        Factory.Instance.JauPointHolder = Bezier.transform.Find("PtsJau").gameObject;
    }
}
