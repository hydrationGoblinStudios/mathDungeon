using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridMaracutaia : MonoBehaviour
{
    public string bazinga2;
    public string tileMapValue = "";
    public int[,] mapValues = new int[17, 11];
    TextMeshPro textMeshPro;
    public GameObject textobj;
    public void Start()
    {
        textobj = this.gameObject.transform.GetChild(0).gameObject;
        Debug.Log(textobj.name);
        textMeshPro = textobj.GetComponent<TextMeshPro>();
        for (int i = 0; i < 17; ++i)
        {
            for (int j = 0; j < 11; ++j)
            {
                mapValues[i, j] = Random.Range(0, 10);
            }
        }
        for (int i = 0; i < 11; ++i)
        {
            int[] bazinga = new int[17];
            for (int j = 0; j < 17; ++j) 
            {
                bazinga[j] = mapValues[j, i];
            }
            bazinga2 = string.Join("", bazinga);
            tileMapValue = bazinga2 + tileMapValue;
        }
        textMeshPro.SetText($"<mspace=0.695em>{tileMapValue}");
    }
    public void Update()
    {
    }
    public int TileValue(int x, int y)
    {
        return mapValues[x, y];
    }

    public bool Check(int n) 
    {
        return true; 

    }
}
