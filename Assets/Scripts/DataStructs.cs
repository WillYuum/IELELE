using UnityEngine;

public class BoughtItems
{
    public bool Sword = false;
    public bool Bow = false;
    public bool Ie = false;
    public bool Garlic = false;
    public bool Flute = false;
    public bool Basil = false;
    public bool WormWood = false;
    public int Food = 0;
    public int Water = 0;
    public bool Beads = false;

    public bool CheckIfItemsEmpty()
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

    public void AddNonFoodWaterITems(Items item)
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
            default:
                break;
        }
    }

    public bool CheckIfBoughtItem(Items item)
    {
        switch (item)
        {
            case Items.Sword:
                return true;

            case Items.Bow:
                return true;

            case Items.IE:
                return true;

            case Items.Garlic:
                return true;

            case Items.Flute:
                return true;

            case Items.Basil:
                return true;

            case Items.WormWood:
                return true;

            case Items.Food:
                return Food > 0;

            case Items.Water:
                return Water > 0;

            case Items.Beads:
                return true;

            default:
                return false;
        }
    }


    public void BuyItem(Items item, int amount)
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
            case Items.Food:
                Food += amount;
                break;
            case Items.Water:
                Water += amount;
                break;
            case Items.Beads:
                Beads = true;
                break;
            default:
                break;
        }
    }

    public void decrement(Items item, int amount)
    {
        switch (item)
        {
            case Items.Food:
                Food -= amount;
                break;
            case Items.Water:
                Water -= amount;
                break;
            default:
                break;
        }
    }


    public int GetAmount(Items item)
    {
        switch (item)
        {
            case Items.Food:
                return Food;
            case Items.Water:
                return Water;
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

