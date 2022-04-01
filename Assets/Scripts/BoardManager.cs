using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int P1score;
    public int P2score;
    public Text P1scoretxt;
    public Text P2scoretxt;
    public Point PointPrefab;
    public Line LinePrefab;
    public NameSquare NameSquarePrefab;
    public List<Line> Lines;
    public List<NameSquare> NameSquares;
    public bool foundSquare;
    
    

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateBoard(PlayerPrefs.GetInt("Size"), PlayerPrefs.GetInt("Size"));
    }

    public void GenerateBoard(int Height, int Width)
    {
        
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                var p = new Vector2(i, j);
                var lv = new Vector2(i, (float)j-0.5f); //posicion de lineas verticales
                var lh = new Vector2((float)i+0.5f, j); // posicion de lines horizontales
                var s = new Vector2((float)i + 0.5f, (float)j+0.5f); // posicion de lines horizontales
                Instantiate(PointPrefab, p, Quaternion.identity);
                
                if (i != Height-1)
                {
                    Lines.Add(Instantiate(LinePrefab, lh, Quaternion.Euler(0, 0, 90)));
                          
                }
                    
                if (j != 0)
                {
                   Lines.Add(Instantiate(LinePrefab, lv, Quaternion.identity));
                }

                if (i != Height - 1 && j != Width - 1)
                {
                    NameSquares.Add(Instantiate(NameSquarePrefab, s, Quaternion.identity));
                }
                

            }
        }
        var center = new Vector2((float)Width / 2 - 0.5f, (float)Height / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -20);

    }
     
    public void checkLines()   
    {
        
        foreach (NameSquare s in NameSquares)
        {
            s.checkedLines = 0;

            foreach (Line l in Lines)
            {
                bool Der = l.GetComponent<Transform>().position.x == s.GetComponent<Transform>().position.x + 0.5 && l.GetComponent<Transform>().position.y == s.GetComponent<Transform>().position.y;
                bool Izq = l.GetComponent<Transform>().position.x == s.GetComponent<Transform>().position.x - 0.5 && l.GetComponent<Transform>().position.y == s.GetComponent<Transform>().position.y;
                bool Down = l.GetComponent<Transform>().position.y == s.GetComponent<Transform>().position.y - 0.5 && l.GetComponent<Transform>().position.x == s.GetComponent<Transform>().position.x;
                bool Up = l.GetComponent<Transform>().position.y == s.GetComponent<Transform>().position.y + 0.5 && l.GetComponent<Transform>().position.x == s.GetComponent<Transform>().position.x;

                if (Der || Izq || Down || Up)
                {
                    if (l.Inner.GetComponent<SpriteRenderer>().color == Color.blue  || l.Inner.GetComponent<SpriteRenderer>().color == Color.red)
                    {
                        s.checkedLines ++;
                    }
                }
            }
        }
    }

    
    public void colorSquares()
    {
        this.foundSquare = false;
        foreach (NameSquare s in NameSquares)
        {
            if (s.checkedLines == 4 && s.isChecked == false)
            {
                if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
                {
                    P1score++;
                    P1scoretxt.text = "Player 1: " + P1score;
                    s.Inner.GetComponent<SpriteRenderer>().color = Color.blue;
                    s.isChecked = true;
                    checkScore();
                    //GameManager.Instance.UpdateGameState(GameManager.GameState.player2);
                }
                else
                {
                    P2score++;
                    P2scoretxt.text = "Player 2: " + P2score;
                    s.Inner.GetComponent<SpriteRenderer>().color = Color.red;
                    s.isChecked = true;
                    checkScore();
                    //GameManager.Instance.UpdateGameState(GameManager.GameState.player1);
                }
                this.foundSquare = true;
                //SetLine();
            }

        }
    }

    public void checkScore()
    {
        if (P1score > (NameSquares.Count/2))
        {
            Debug.Log("player1 wins");
            SceneManager.LoadScene("P1wins");
        }
        if (P2score > (NameSquares.Count / 2))
        {
            Debug.Log("player2 wins");
            SceneManager.LoadScene("P2wins");
        }
        if (P2score == (NameSquares.Count / 2) && P1score == (NameSquares.Count / 2))
        {
            Debug.Log("its a draw");
            SceneManager.LoadScene("Draw");
        }
    }
    
    public void SetLine()
    {
        GameManager.Instance.SwitchPlayer();
    }
}
