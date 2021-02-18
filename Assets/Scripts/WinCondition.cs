using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{ 
    public Sprite player1Sprite;
    public Sprite player2Sprite;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.wins.x > GameManager.wins.y) GetComponent<Image>().sprite = player1Sprite;
        if (GameManager.wins.x < GameManager.wins.y) GetComponent<Image>().sprite = player2Sprite;

        GameManager.wins = new Vector2(0, 0);

    }

}
