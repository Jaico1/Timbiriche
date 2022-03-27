using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject Inner;
    private void OnMouseDown()
    {
        Debug.Log("mouse down");
        if (Inner.GetComponent<SpriteRenderer>().color == Color.blue || Inner.GetComponent<SpriteRenderer>().color == Color.red)
        {
            
        }
        else
        {
            if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
                Inner.GetComponent<SpriteRenderer>().color = Color.blue;
            else
                Inner.GetComponent<SpriteRenderer>().color = Color.red;

            BoardManager.Instance.SetLine(this);
        }

        BoardManager.Instance.checkLines();
        BoardManager.Instance.colorSquares();
    }
}
