using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MapButtonState
{
    Normal,
    Hover,
    Locked,
}

public class InteractableButton_map : MonoBehaviour
{
    [SerializeField] private Sprite targetGraphic;
    [SerializeField] private Sprite highlightedGraphic;

    [SerializeField] private Sprite closedGraphic;



    public void SetButtonTo(MapButtonState state)
    {
        switch (state)
        {
            case MapButtonState.Normal:
                GetComponent<Image>().sprite = targetGraphic;
                break;
            case MapButtonState.Hover:
                GetComponent<Image>().sprite = highlightedGraphic;
                break;
            case MapButtonState.Locked:
                GetComponent<Image>().sprite = closedGraphic;
                break;
            default:
                break;
        }
    }
}
