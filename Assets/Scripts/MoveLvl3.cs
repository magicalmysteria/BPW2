using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLvl3 : MonoBehaviour
{
    public Level3 ThirdLevel;
    public Player player1;
    public Player player2;

    // Update is called once per frame
    void Update()
    {
        if (ThirdLevel.roundState == round.BOMB) GetComponent<Text>().text = "BOMB";
        else
        {
            if (ThirdLevel.currentPlayerNumber == 1 && player1.godMode == true) GetComponent<Text>().text = "Godmode";
            if (ThirdLevel.currentPlayerNumber == 1 && player1.godMode == false) GetComponent<Text>().text = "Walk";
            if (ThirdLevel.currentPlayerNumber == 2 && player2.godMode == true) GetComponent<Text>().text = "Godmode";
            if (ThirdLevel.currentPlayerNumber == 2 && player2.godMode == false) GetComponent<Text>().text = "Walk";
        }
    }
}
