using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerLvl1 : MonoBehaviour
{
    public Level1 FirstLevel;
    public Sprite Player1;
    public Sprite Player2;

    // Update is called once per frame
    void Update()
    {
        // Match the current player to the player sprite
        if (FirstLevel.currentPlayer == 1)
        {
            GetComponent<Image>().sprite = Player1;
        }
        if (FirstLevel.currentPlayer == 2)
        {
            GetComponent<Image>().sprite = Player2;
        }
    }
}
