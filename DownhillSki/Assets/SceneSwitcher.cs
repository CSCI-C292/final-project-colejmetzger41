using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public void GotoStartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void GotoGameScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GotoGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

}