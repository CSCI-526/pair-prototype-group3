using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource theMusic;
    public bool startPlaying;

    public TowerObject[] playerOneTowers;
    public TowerObject[] playerTwoTowers;

    public GameObject gameOverScreen;
    public Text winnerText;
    public Button restartButton;

    void Start()
    {
        Time.timeScale = 1;
        instance = this;
        gameOverScreen.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theMusic.Play();
            }
        }
        else
        {
            CheckGameOver();
        }
    }

    public void CheckGameOver()
    {
        bool playerOneDefeated = IsPlayerDefeated(playerOneTowers);
        bool playerTwoDefeated = IsPlayerDefeated(playerTwoTowers);

        if (playerOneDefeated || playerTwoDefeated)
        {
            EndGame(playerTwoDefeated ? "Player One" : "Player Two");
        }
    }

    bool IsPlayerDefeated(TowerObject[] towers)
    {
        bool isDefeated = false;
        foreach (var tower in towers)
        {
            if (tower.health <= 0)
            {
                isDefeated = true;
            }
        }
        return isDefeated;
    }

    void EndGame(string winner)
    {
        theMusic.Stop();
        gameOverScreen.SetActive(true);
        // Debug.Log(winner);
        winnerText.text = winner + " Wins!";
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NoteHit() { }
    public void NormalHit() { }
    public void GoodHit() { }
    public void PerfectHit() { }
    public void NoteMissed() { }
}