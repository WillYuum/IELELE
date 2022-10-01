using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using UnityEngine.SceneManagement;

public enum GameScenes
{
    KnighScene,
    IELELE,
    Map,
}

public class GameManager : GenericStaticClass<GameManager>
{
    public void StartGame()
    {

    }



    public void GoToScene(GameScenes scene)
    {
        switch (scene)
        {
            case GameScenes.KnighScene:
                SceneManager.LoadScene("Knight_Scene");
                break;
            case GameScenes.IELELE:
                SceneManager.LoadScene("IELELE_Scene");
                break;
            case GameScenes.Map:
                SceneManager.LoadScene("Map_Scene");
                break;

            default:
                break;
        }
    }
}
