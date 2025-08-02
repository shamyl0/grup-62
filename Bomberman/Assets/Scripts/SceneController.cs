using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("game");
        SoundManager.Instance.PlayMusic("gamemusic");
    }

    public void GoToControls()
    {
        SceneManager.LoadScene("control");
        SoundManager.Instance.PlayMusic("menumusic");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
        SoundManager.Instance.PlayMusic("menumusic");
    }
}