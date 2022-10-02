using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleCards : MonoBehaviour
{
    [SerializeField] public Items Item;
    [SerializeField] private TextMeshProUGUI _energyCost;

    [SerializeField] private Button _button;

    private void Awake()
    {
        InitCard();
    }

    public void InitCard()
    {
        var data = GameManager.instance.ItemsData.GetItems(Item);
        _energyCost.text = data.Energy.ToString();
    }



    public void OnClickButton(Action<int, Items> onBuy)
    {
        _button.onClick.AddListener(() =>
        {
            var data = GameManager.instance.ItemsData.GetItems(Item);
            onBuy.Invoke(data.Energy, Item);
        });
    }


    void OnMouseOver()
    {
        OnHoverButton.Invoke(Item);
    }

    private Action<Items> OnHoverButton;
    public void SetHoverLogic(Action<Items> onHover)
    {
        OnHoverButton = onHover;
    }




}
