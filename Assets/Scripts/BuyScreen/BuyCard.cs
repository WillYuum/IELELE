using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyCard : MonoBehaviour
{
    [SerializeField] public Items _item;

    [SerializeField] private TextMeshProUGUI _costIndicator;
    [SerializeField] private TextMeshProUGUI _energyIndicator;


    [SerializeField] private Button _button;

    [SerializeField] private GameObject highlight;

    private void Start()
    {
        Render();
        highlight.SetActive(false);
    }

    private void Render()
    {
        var data = GameManager.instance.ItemsData.GetItems(_item);
        _costIndicator.text = data.Cost.ToString();
        _energyIndicator.text = data.Energy.ToString();
    }

    public void AddClickListeners(Action<int, Items> onBuy, Action<int, Items> onSell)
    {
        var data = GameManager.instance.ItemsData.GetItems(_item);

        _button.onClick.AddListener(() =>
        {
            if (PersistanceItems.CheckIfBoughtItem(_item))
            {
                onSell.Invoke(data.Cost, _item);
                ToggleHightlightCard(false);
            }
            else
            {
                onBuy.Invoke(data.Cost, _item);
                if (PersistanceItems.CheckIfBoughtItem(_item))
                {
                    ToggleHightlightCard(true);
                }
            }
        });
    }

    public void ToggleHightlightCard(bool active)
    {
        highlight.SetActive(active);
    }
}
