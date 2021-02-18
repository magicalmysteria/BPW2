using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLvl2 : MonoBehaviour
{
    public Level2 secondLevel;
    public Player player1;
    public Player player2;

    // Update is called once per frame
    void Update()
    {
        if (secondLevel.currentPlayerNumber == 1 && player1.godMode == true) GetComponent<Text>().text = "Godmode";
        if (secondLevel.currentPlayerNumber == 1 && player1.godMode == false) GetComponent<Text>().text = "Walk";
        if (secondLevel.currentPlayerNumber == 2 && player2.godMode == true) GetComponent<Text>().text = "Godmode";
        if (secondLevel.currentPlayerNumber == 2 && player2.godMode == false) GetComponent<Text>().text = "Walk";
    }
}
