using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void GameWin()
    {
        gameWinUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
