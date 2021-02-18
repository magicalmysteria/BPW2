using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerLvl2 : MonoBehaviour
{
    public Level2 SecondLevel;
    public Sprite Player1;
    public Sprite Player2;

    // Update is called once per frame
    void Update()
    {
        // Match the current player to the player sprite
        if (SecondLevel.currentPlayerNumber == 1)
        {
            GetComponent<Image>().sprite = Player1;
        }
        if (SecondLevel.currentPlayerNumber == 2)
        {
            GetComponent<Image>().sprite = Player2;
        }
    }
}
