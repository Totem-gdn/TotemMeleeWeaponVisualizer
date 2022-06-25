using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public void NextLevel(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
