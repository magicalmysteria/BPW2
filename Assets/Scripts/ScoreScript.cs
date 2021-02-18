using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Get the player
    public Player player;

    // Update is called once per frame
    void Update()
    {
        // Set the text to the player score
        GetComponent<Text>().text = player.score.ToString(); 
    }
}
