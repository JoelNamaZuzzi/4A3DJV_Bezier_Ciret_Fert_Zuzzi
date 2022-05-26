using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castel : MonoBehaviour
{
    public static Castel Instance;
    public List<Transform> pointDeBase;
    public List<Vector3> pointIntermediaire;
    public int pas = 3;
    
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
    
    public void Jau()
    {
        List<Vector3> lastPos = new List<Vector3>();
        List<Vector3> tempPos = new List<Vector3>();
        pointIntermediaire.Clear();
        float k = 1f / pas;

        for (int x = 0; x <= pas; x ++)
        {
            float t = k * x;

            for (int i = 0; i < pointDeBase.Count; i++)
            {
                lastPos.Add(pointDeBase[i].position);
            }

            while (lastPos.Count != 1)
            {
                Debug.Log("boucle j");
                for (int i = 0; i < lastPos.Count - 1; i++)
                {
                    Vector3 y = (1 - t) * lastPos[i];
                    Vector3 z = t * lastPos[i + 1];
                    Vector3 newV = y + z;
                    Debug.Log(newV);
                    tempPos.Add( newV );
                }
                
                lastPos.Clear();
                lastPos.AddRange(tempPos);
                tempPos.Clear();
            }
                
            

            pointIntermediaire.AddRange(lastPos);

        }

    }
}
