using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class KnightScene : MonoBehaviourSingleton<KnightScene>
{

    public void OnKillKnight()
    {
        var BattleCards_UI = GameObject.Find("BattleCards_UI");
        BattleCards_UI.SetActive(false);
    }
}
