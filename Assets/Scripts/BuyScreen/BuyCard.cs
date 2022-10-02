using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyCard : MonoBehaviour
{
    [SerializeField] private Items _item;

    [SerializeField] private TextMeshProUGUI _costIndicator;
    [SerializeField] private TextMeshProUGUI _energyIndicator;


    private Action<int, Items> _onBuy;

    [SerializeField] private Button _button;

    [SerializeField] private GameObject highlight;

    private void Start()
    {
        Render();
        highlight.SetActive(false);
        // _buyButton.Init(OnBuy);
    }

    private void Render()
    {
        var data = GameManager.instance.ItemsData.GetItems(_item);
        _costIndicator.text = data.Cost.ToString();
        _energyIndicator.text = data.Energy.ToString();
    }

    public void AddClickListeners(Action<int, Items> onBuy)
    {
        _onBuy = onBuy;
        _button.onClick.AddListener(() =>
        {
            print("CLicked");
            var data = GameManager.instance.ItemsData.GetItems(_item);

            _onBuy.Invoke(data.Cost, _item);

            if (PersistanceItems.CheckIfBoughtItem(_item))
            {
                HightlightCard();
            }
        });
    }

    private void HightlightCard()
    {
        highlight.SetActive(true);
    }
}
