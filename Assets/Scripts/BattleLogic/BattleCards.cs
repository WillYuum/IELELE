using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCards : MonoBehaviour
{
    [SerializeField] private Items _item;
    [SerializeField] private TextMeshProUGUI _energyCost;


    public void SetEnergyCost()
    {
        var data = GameManager.instance.ItemsData.GetItems(_item);
        _energyCost.text = data.Energy.ToString();
    }



    private void OnClickButton()
    {
        var data = GameManager.instance.ItemsData.GetItems(_item);

    }


}
