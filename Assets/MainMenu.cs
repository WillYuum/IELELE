using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        GameManager.instance.GoToScene(GameScenes.Narrative);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
