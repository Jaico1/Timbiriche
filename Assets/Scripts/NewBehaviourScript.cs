using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text sizetxt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSize(float size)
    {
        PlayerPrefs.SetInt("Size", (int)size);
    }

    public void setText(float size)
    {
        sizetxt.text = "Grid Size: " + size + " x " + size;

    }
}    
