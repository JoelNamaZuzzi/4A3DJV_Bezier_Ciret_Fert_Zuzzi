using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentAdd : MonoBehaviour
{
    public static ContentAdd Instance;
    public GameObject BtnBezPrefab;
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
    
    public void CreateBez(GameObject bez)
    {
        GameObject btn = Instantiate(BtnBezPrefab, Vector3.zero, Quaternion.identity);
        btn.transform.parent = gameObject.transform;
        btn.GetComponent<itemController>().Bezier = bez;
        btn.GetComponent<itemController>().SetText();
    }
}
