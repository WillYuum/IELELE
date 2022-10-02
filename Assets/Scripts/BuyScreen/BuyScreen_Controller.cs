using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils.GenericSingletons;

public enum Items
{
    Sword,
    Bow,
    IE,
    Garlic,
    Flute,
    Basil,
    WormWood,
    Food,
    Water,
    Beads,
}

public class BuyScreen_Controller : MonoBehaviour
{

    [System.Serializable]
    class Indicator
    {
        [SerializeField] public Items Item;
        [SerializeField] private TextMeshProUGUI _indicator;
        [SerializeField] private Button _incrementButton;
        [SerializeField] private Button _decrementButton;
        private int _cost = 5;

        public void Init(UnityAction<int, Items> onIncrease, UnityAction<int, Items> onDecrease)
        {
            if (_cost == 0)
            {
                Debug.LogError("Cost is 0");
            }

            _indicator.text = "0";

            _incrementButton.onClick.AddListener(() =>
            {
                onIncrease.Invoke(_cost, Item);
            });

            _decrementButton.onClick.AddListener(() =>
            {
                onDecrease.Invoke(_cost, Item);
            });
        }

        public void Render(int amount)
        {
            _indicator.text = amount.ToString();
        }
    }


    [SerializeField] private int _startingCoin = 250;
    [SerializeField] private TextMeshProUGUI _coinIndicator;
    [SerializeField] private Indicator[] _indicators;

    [SerializeField] private BuyCard[] _cards;




    private void Awake()
    {
        _coinIndicator.text = _startingCoin.ToString();

        foreach (var item in _indicators)
        {
            item.Init(OnBuyItem, OnSellItem);
        }


        foreach (var card in _cards)
        {
            card.AddClickListeners(OnBuyItem);
        }
    }


    private void OnBuyItem(int cost, Items item)
    {
        if (_startingCoin >= cost)
        {
            switch (item)
            {
                case Items.Food:
                case Items.Water:
                    PersistanceItems.BuyItems(item, 5);
                    // GameManager.instance.CollectedItems.BuyItem(item, 5);
                    _startingCoin -= cost;
                    UpdateAmounts();

                    break;
                default:

                    bool boughtItem = PersistanceItems.CheckIfBoughtItem(item);

                    if (boughtItem == false)
                    {
                        //They;re a boolean
                        PersistanceItems.BuyItems(item, 0);
                        _startingCoin -= cost;
                    }
                    // GameManager.instance.CollectedItems.AddNonFoodWaterITems(item);
                    break;
            }

            _coinIndicator.text = _startingCoin.ToString();
            // GameManager.instance.CollectedItems.BuyItem(item, 1);
        }
    }

    private void OnSellItem(int cost, Items item)
    {
        if (PersistanceItems.CheckIfBoughtItem(item))
        {
            _startingCoin += cost;
            _coinIndicator.text = _startingCoin.ToString();
            // GameManager.instance.CollectedItems.decrement(item, 1);
            PersistanceItems.RemoveItem(item);
            UpdateAmounts();
        }
    }


    private void UpdateAmounts()
    {
        foreach (var item in _indicators)
        {
            item.Render(PersistanceItems.GetFoodOrWaterCount(item.Item));
        }
    }

    [SerializeField] private GameObject _CannontContinueAsshole;
    public void GoToMapScreen()
    {
        if (PersistanceItems.CheckIfItemsEmpty())
        {
            _CannontContinueAsshole.SetActive(true);
            return;
        }

        GameManager.instance.GoToScene(GameScenes.Map);
    }


}




