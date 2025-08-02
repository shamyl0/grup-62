using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro için ekleyin

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject[] players;

    [Header("UI")]
    public TMP_Text winText; // WinText objesini buraya atayacaksýnýz

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (winText != null)
            winText.gameObject.SetActive(false);
    }

    public void CheckWinState()
    {
        int aliveCount = 0;
        GameObject winner = null;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeSelf) {
                aliveCount++;
                winner = players[i];
            }
        }

        if (aliveCount == 1 && winner != null) {
            ShowWinText(winner.name);
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySFX("victory");
            Invoke(nameof(ReturnToMainMenu), 6f);
        }
        else if (aliveCount <= 1) // Hiç oyuncu kalmadýysa
        {
            Invoke(nameof(ReturnToMainMenu), 6f);
        }
    }

    private void ShowWinText(string winnerName)
    {
        if (winText == null)
            return;
        SoundManager.Instance.StopMusic();
        // Oyuncu adýndan numarayý çek (ör: "Player 2")
        string playerNumber = winnerName.Replace("Player", "").Trim();
        winText.text = $"PLAYER {playerNumber} WON!";
        winText.gameObject.SetActive(true);
        Invoke(nameof(HideWinText), 5f);
    }

    private void HideWinText()
    {
        if (winText != null)
            winText.gameObject.SetActive(false);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
