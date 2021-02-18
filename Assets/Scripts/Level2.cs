using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    // The size of the field and the game tile that are in there
    public Vector2Int fieldSize;
    public GameObject gameTile;
    public Player player1;
    public Player player2;

    private Dictionary<Vector2, GameObject> gameTiles;
    private List<Vector2Int> tilesAroundPlayer;
    [HideInInspector]
    public int currentPlayerNumber = 1;
    private Player oppositePlayer;

    private round roundState = round.BEGIN;

    void Start()
    {
        // Draw the game tiles
        gameTiles = new Dictionary<Vector2, GameObject>();
        tilesAroundPlayer = new List<Vector2Int>();
        DrawField();

        oppositePlayer = player2;

        // Draw player1 at the top
        player1.transform.position = new Vector2((int)(fieldSize.x / 2), -1);

        // Draw player2 at the bottom
        player2.transform.position = new Vector2((int)(fieldSize.x / 2), fieldSize.y);

        // Move the camera to the center of the field
        Camera.main.transform.position = new Vector3((fieldSize.x / 2) - 0.5f, (fieldSize.y / 2), -fieldSize.y - 5);
        Camera.main.orthographicSize = fieldSize.y - (fieldSize.y / 3);
    }

    void Update()
    {
        if (currentPlayerNumber == 1)
        {
            PlayRound(player1);
        }
        else if (currentPlayerNumber == 2)
        {
            PlayRound(player2);
        }

    }
    private void PlayRound(Player currentPlayer)
    {
        if (roundState == round.END)
        {
            FinishLevel();
            ResetRound();
        }
        else if (roundState == round.MID)
        {
            MovePlayer(currentPlayer);
        }

        else if (roundState == round.BEGIN)
        {
            GetTilesAroundPlayer(currentPlayer);
            roundState = round.MID;
        }

    }

    // When all tiles are claimed finish the level
    private int FinishLevel()
    {
        // Go to Level 3
        for (int x = 0; x < fieldSize.x; x++)
        {
            for (int y = 0; y < fieldSize.y; y++)
            {
                if (gameTiles[new Vector2(x, y)].GetComponent<PlayingTile>().claimed == false)
                {
                    return 0;
                }
            }
        }

        if (player2.score > player1.score) GameManager.wins.y++;
        else if (player2.score < player1.score) GameManager.wins.x++;

        SceneManager.LoadScene("Level3");
        return 1;
    }

    private void ResetRound()
    {
        // Reset tiles to non selected
        for (int i = 0; i < tilesAroundPlayer.Count; i++)
        {
            if (tilesAroundPlayer[i].x >= 0 && tilesAroundPlayer[i].x < fieldSize.x
                && tilesAroundPlayer[i].y >= 0 && tilesAroundPlayer[i].y < fieldSize.y)
            {
                gameTiles[tilesAroundPlayer[i]].GetComponent<PlayingTile>().selected = false;
            }
        }

        //Reset tiles around player
        tilesAroundPlayer.Clear();

        // Switch player
        if (currentPlayerNumber == 1) { currentPlayerNumber = 2; oppositePlayer = player1; }
        else { currentPlayerNumber = 1; oppositePlayer = player2; }

        // Begin next round
        roundState = round.BEGIN;
    }

    private void MovePlayer(Player currentPlayer)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            // Check if the ray hit one of the tiles around the player
            for (int i = 0; i < tilesAroundPlayer.Count; i++)
            {
                if (hit.collider.gameObject.transform.position.x == tilesAroundPlayer[i].x &&
                    hit.collider.gameObject.transform.position.y == tilesAroundPlayer[i].y)
                {
                    currentPlayer.transform.position = new Vector3(tilesAroundPlayer[i].x, tilesAroundPlayer[i].y, -4);

                    if (currentPlayer.transform.position.y <= 0 && currentPlayerNumber == 2) currentPlayer.godMode = true;
                    if (currentPlayer.transform.position.y >= fieldSize.y - 1 && currentPlayerNumber == 1) currentPlayer.godMode = true;

                    // When stepped on, the game tile decreases their step count
                    gameTiles[tilesAroundPlayer[i]].GetComponent<PlayingTile>().StepOnTile(currentPlayer);

                    // Once moved end the round
                    roundState = round.END;
                }
            }
        }

    }

    private void GetTilesAroundPlayer(Player currentPlayer)
    {
        // Get the tiles around the player       
        // Get the four tiles around the player
        if (currentPlayer.godMode == false)
        {
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x - 1), (int)(currentPlayer.transform.position.y)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x), (int)(currentPlayer.transform.position.y + 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x), (int)(currentPlayer.transform.position.y - 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x + 1), (int)(currentPlayer.transform.position.y)));
        }
        if (currentPlayer.godMode == true)
        {
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x - 1), (int)(currentPlayer.transform.position.y)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x), (int)(currentPlayer.transform.position.y + 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x), (int)(currentPlayer.transform.position.y - 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x + 1), (int)(currentPlayer.transform.position.y)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x - 1), (int)(currentPlayer.transform.position.y - 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x - 1), (int)(currentPlayer.transform.position.y + 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x + 1), (int)(currentPlayer.transform.position.y + 1)));
            tilesAroundPlayer.Add(new Vector2Int((int)(currentPlayer.transform.position.x + 1), (int)(currentPlayer.transform.position.y - 1)));
        }

        for (int i = 0; i < tilesAroundPlayer.Count; i++)
        {

            if (tilesAroundPlayer[i] == new Vector2(oppositePlayer.transform.position.x, oppositePlayer.transform.position.y))
            {
                tilesAroundPlayer.RemoveAt(i);
            }
        }
        // Set tiles to selected
        for (int i = 0; i < tilesAroundPlayer.Count; i++)
        {

            if (tilesAroundPlayer[i].x >= 0 && tilesAroundPlayer[i].x < fieldSize.x
                && tilesAroundPlayer[i].y >= 0 && tilesAroundPlayer[i].y < fieldSize.y)
            {
                gameTiles[tilesAroundPlayer[i]].GetComponent<PlayingTile>().selected = true;
            }

        }
    }

    // Draw the playing field
    private void DrawField()
    {
        for (int x = 0; x < fieldSize.x; x++)
        {
            for (int y = 0; y < fieldSize.y; y++)
            {
                gameTiles.Add(new Vector2(x, y), Instantiate(gameTile) as GameObject);
                gameTiles[new Vector2(x, y)].transform.position = new Vector2(x, y);
            }
        }
    }
}
