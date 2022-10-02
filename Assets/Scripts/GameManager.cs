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
    BuyScreen,
    Narrative,
    Calusari,
    Menu
}

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public bool finishedKnightScene = false;
    public bool finishedIeleleScene = false;

    [SerializeField] public ItemsData ItemsData;

    public BoughtItems CollectedItems = new BoughtItems();


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
            case GameScenes.BuyScreen:
                SceneManager.LoadScene("Buy_Scene");
                break;
            case GameScenes.Narrative:
                SceneManager.LoadScene("StartNaratives_Scene");
                break;
            case GameScenes.Menu:
                SceneManager.LoadScene("MainMenu_Scene");
                break;
            case GameScenes.Calusari:
                SceneManager.LoadScene("Trial3_0_Calusari_Scene");
                break;

            default:
                break;
        }
    }


    public void LoseGame()
    {
        // Time.timeScale = 0;

        ShowLoseScreen();
        Invoke(nameof(RestartGame), 1.0f);
    }

    private void ShowLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Additive);
    }

    private void RestartGame()
    {
        Time.timeScale = 1;

        GoToScene(GameScenes.BuyScreen);
    }

}
