using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalCanvas : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex;
    public void StartGame()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
