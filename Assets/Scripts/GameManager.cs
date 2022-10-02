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
        PersistanceItems.ResetProps();

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



public static class PersistanceItems
{
    public static bool Sword = false;
    public static bool Bow = false;
    public static bool Ie = false;
    public static bool Garlic = false;
    public static bool Flute = false;
    public static bool Basil = false;
    public static bool WormWood = false;
    public static bool Beads = false;

    public static int Food = 0;
    public static int Water = 0;


    public static bool CheckIfHasWaterAndFood()
    {
        if (Food > 0 && Water > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckIfItemsEmpty()
    {
        if (Sword == false && Bow == false && Ie == false && Garlic == false && Flute == false && Basil == false && WormWood == false && Food > 0 && Water > 0 && Beads == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool CheckIfBoughtItem(Items item)
    {
        switch (item)
        {
            case Items.Sword:
                return Sword;

            case Items.Bow:
                return Bow;

            case Items.IE:
                return Ie;

            case Items.Garlic:
                return Garlic;

            case Items.Flute:
                return Flute;

            case Items.Basil:
                return Basil;

            case Items.WormWood:
                return WormWood;

            case Items.Beads:
                return Beads;

            case Items.Water:
                return Water > 0;

            case Items.Food:
                return Food > 0;

            default:
                Debug.LogError("Item not found");
                return false;
        }
    }

    public static void BuyItems(Items item, int count)
    {
        switch (item)
        {
            case Items.Sword:
                Sword = true;
                break;
            case Items.Bow:
                Bow = true;
                break;
            case Items.IE:
                Ie = true;
                break;
            case Items.Garlic:
                Garlic = true;
                break;
            case Items.Flute:
                Flute = true;
                break;
            case Items.Basil:
                Basil = true;
                break;
            case Items.WormWood:
                WormWood = true;
                break;
            case Items.Beads:
                Beads = true;
                break;
            case Items.Water:
                Water += 5;
                break;
            case Items.Food:
                Food += 5;
                break;
            default:
                break;
        }
    }

    public static int GetFoodOrWaterCount(Items item)
    {
        switch (item)
        {
            case Items.Water:
                return Water;

            case Items.Food:
                return Food;

            default:
                Debug.LogError("Item not found");
                return 0;
        }
    }

    public static void RemoveItem(Items item)
    {
        switch (item)
        {
            case Items.Sword:
                Sword = false;
                break;
            case Items.Bow:
                Bow = false;
                break;
            case Items.IE:
                Ie = false;
                break;
            case Items.Garlic:
                Garlic = false;
                break;
            case Items.Flute:
                Flute = false;
                break;
            case Items.Basil:
                Basil = false;
                break;
            case Items.WormWood:
                WormWood = false;
                break;
            case Items.Beads:
                Beads = false;
                break;
            case Items.Water:
                Water -= 5;
                break;
            case Items.Food:
                Food -= 5;
                break;
            default:
                break;
        }
    }

    public static void ResetProps()
    {
        Sword = false;
        Bow = false;
        Ie = false;
        Garlic = false;
        Flute = false;
        Basil = false;
        WormWood = false;
        Beads = false;

        Food = 0;
        Water = 0;
    }
}