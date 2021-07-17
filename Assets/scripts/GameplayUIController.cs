using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameplayUIController : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("Main game");
    }
    public void home()
    {
        SceneManager.LoadScene("main menu");
    }
}
