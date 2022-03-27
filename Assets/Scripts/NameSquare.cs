using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSquare : MonoBehaviour
{
    public int checkedLines;
    public static NameSquare Instance;
    public GameObject Inner;
    public bool isChecked;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
