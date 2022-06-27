using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public void ChangeMaterial(Material mat)
    {
        if (Factory.Instance.SelectedBezier.GetComponent<MeshRenderer>().material)
        {
            Factory.Instance.SelectedBezier.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
