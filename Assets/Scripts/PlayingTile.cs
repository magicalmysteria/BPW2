using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingTile : MonoBehaviour
{
    // Number of steps before it can be claimed
    [HideInInspector]
    public int stepScore = 5;

    private void ChangeColor(Color newColor) { GetComponent<SpriteRenderer>().color = newColor; }

    [HideInInspector]
    public bool selected = false;

    [HideInInspector]
    public bool claimed = false;

    [HideInInspector]
    public Color color { get { return GetComponent<SpriteRenderer>().color; } }

   

    void Start()
    {
        // Set the step score to a random value
        stepScore = Random.Range(1, 5);
        GetComponentsInChildren<TextMesh>()[0].text = stepScore.ToString();
    }

    private void Update()
    {
        // If selected draw a yellow square around it
        if (selected)
            GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        else GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;

    }

    public void StepOnTile(Player currentPlayer)
    {
        stepScore--;

        if(stepScore == 0)
        {
            SetToZero(currentPlayer);
        }
        else if (stepScore > 0) GetComponentsInChildren<TextMesh>()[0].text = stepScore.ToString();
    }

    public void SetToZero(Player currentPlayer)
    {
        ChangeColor(currentPlayer.color);
        claimed = true;
        currentPlayer.score++;
        GetComponentsInChildren<TextMesh>()[0].text = " ";
    }
}
