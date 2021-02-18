using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerLvl3 : MonoBehaviour
{
    public Level3 ThirdLevel;
    public Sprite Player1;
    public Sprite Player2;

    // Update is called once per frame
    void Update()
    {
        // Match the current player to the player sprite
        if (ThirdLevel.currentPlayerNumber == 1)
        {
            GetComponent<Image>().sprite = Player1;
        }
        if (ThirdLevel.currentPlayerNumber == 2)
        {
            GetComponent<Image>().sprite = Player2;
        }
    }
}
