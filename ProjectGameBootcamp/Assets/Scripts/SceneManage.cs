using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level Easy";
    [SerializeField] private string optionlevel = "Option";
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void NewOptionLevelButton()
    {
        SceneManager.LoadScene(optionlevel);
    }
}
