using UnityEngine;

public class BoughtItems
{
    public int Sword = 0;
    public int Bow = 0;
    public int Ie = 0;
    public int Garlic = 0;
    public int Flute = 0;
    public int Basil = 0;
    public int WormWood = 0;
    public int Food = 0;
    public int Water = 0;
    public int Beads = 0;

    public bool CheckIfItemsEmpty()
    {
        if (Sword == 0 && Bow == 0 && Ie == 0 && Garlic == 0 && Flute == 0 && Basil == 0 && WormWood == 0 && Food == 0 && Water == 0 && Beads == 0)
        {
            return true;
        }
        return false;
    }


    public void increment(Items item, int amount)
    {
        switch (item)
        {
            case Items.Sword:
                Sword += amount;
                break;
            case Items.Bow:
                Bow += amount;
                break;
            case Items.IE:
                Ie += amount;
                break;
            case Items.Garlic:
                Garlic += amount;
                break;
            case Items.Flute:
                Flute += amount;
                break;
            case Items.Basil:
                Basil += amount;
                break;
            case Items.WormWood:
                WormWood += amount;
                break;
            case Items.Food:
                Food += amount;
                break;
            case Items.Water:
                Water += amount;
                break;
            case Items.Beads:
                Beads += amount;
                break;
            default:
                break;
        }
    }

    public void decrement(Items item, int amount)
    {
        switch (item)
        {
            case Items.Sword:
                Sword -= amount;
                break;
            case Items.Bow:
                Bow -= amount;
                break;
            case Items.IE:
                Ie -= amount;
                break;
            case Items.Garlic:
                Garlic -= amount;
                break;
            case Items.Flute:
                Flute -= amount;
                break;
            case Items.Basil:
                Basil -= amount;
                break;
            case Items.WormWood:
                WormWood -= amount;
                break;
            case Items.Food:
                Food -= amount;
                break;
            case Items.Water:
                Water -= amount;
                break;
            case Items.Beads:
                Beads -= amount;
                break;
            default:
                break;
        }
    }


    public int GetAmount(Items item)
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
            case Items.Food:
                return Food;
            case Items.Water:
                return Water;
            case Items.Beads:
                return Beads;
            default:
                Debug.LogError("Item not found");
                return 0;
        }
    }
}



[System.Serializable]
public class ItemsData
{
    [SerializeField] public ItemData Sword;
    [SerializeField] public ItemData Bow;
    [SerializeField] public ItemData Ie;
    [SerializeField] public ItemData Garlic;
    [SerializeField] public ItemData Flute;
    [SerializeField] public ItemData Basil;
    [SerializeField] public ItemData WormWood;
    [SerializeField] public ItemData Beads;


    public ItemData GetItems(Items item)
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
            default:
                Debug.LogError("Item not found");
                return Sword;
        }
    }
}


[System.Serializable]
public struct ItemData
{
    [SerializeField] public Items Item;
    [SerializeField] public int Cost;
    [SerializeField] public int Energy;
}

