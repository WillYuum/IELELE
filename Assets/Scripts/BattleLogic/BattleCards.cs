using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class BattleCards : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Items Item;
    [SerializeField] private TextMeshProUGUI _energyCost;

    [SerializeField] private Button _button;

    private void Awake()
    {
        InitCard();
    }


    // private void Update()
    // {
    //     if (EventSystem.current.IsPointerOverGameObject())
    //     {

    //     }
    // }

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


    public void EventOnEnterMOuse()
    {
        print("Enter");
        OnHoverButton.Invoke(Item);
    }
    public void OnMouseOverLogic()
    {
        print("Exit");
        _onLeave.Invoke();
    }

    private Action<Items> OnHoverButton;
    public void SetHoverLogic(Action<Items> onHover)
    {
        OnHoverButton = onHover;
    }


    private Action _onLeave;
    public void SetLeaveHover(Action onLeave)
    {
        _onLeave = onLeave;
    }




    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        OnHoverButton.Invoke(Item);

        //Scale up with tween
        transform.DOScale(1.1f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        _onLeave.Invoke();

        //Scale down with tween
        transform.DOScale(1f, 0.2f);

    }
}
