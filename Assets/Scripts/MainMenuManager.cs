using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Chuyển sang Scene Gameplay khi click nút Play
        SceneManager.LoadScene("GamePlay");
    }
    public void QuitGame()
    {
        // Thoát game khi click nút Thoát
        Application.Quit();
    }
}
