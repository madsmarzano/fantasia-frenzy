using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void GoToHoney()
    {
        SceneManager.LoadScene("Honey");
    }

    public void GoToHood()
    {
        SceneManager.LoadScene("Hood");
    }

    public void GoToCasino()
    {
        SceneManager.LoadScene("Casino");
    }

    public void GoToShane()
    {
        SceneManager.LoadScene("Shane");
    }
}
