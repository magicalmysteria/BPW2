using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Color _playerColor;
    public Color color { get { return _playerColor; } }

    [HideInInspector]
    public bool hasBomb = true;

    [HideInInspector]
    public bool godMode = false;

    [HideInInspector]
    public int score = 0;

   /* [HideInInspector]
    static public Vector2 wins = new Vector2(0, 0);*/

    public void MovePlayer(Vector2 newPosition){ transform.position = newPosition;  }

    private void Start()
    {
        // Set the player to the player color
        _playerColor = GetComponent<SpriteRenderer>().color;
    }
}
