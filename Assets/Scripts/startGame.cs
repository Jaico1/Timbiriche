using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Size", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGames()
    {
        
        SceneManager.LoadScene("SampleScene");
    }
}
