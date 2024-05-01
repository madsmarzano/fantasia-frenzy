using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    int currentSceneIndex;

    public void Setup()
    {
        gameObject.SetActive(true);
        //Time.timeScale = 0f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(currentSceneIndex);
        //Time.timeScale = 1f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
