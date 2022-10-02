using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class KnightScene : MonoBehaviourSingleton<KnightScene>
{
    [SerializeField] private ParticleSystem endPoint;


    private void Awake()
    {
        endPoint.gameObject.SetActive(false);
    }
    public void OnKillKnight()
    {
        var BattleCards_UI = GameObject.Find("BattleCards_UI");
        BattleCards_UI.SetActive(false);

        MainCharacter.instance.DisableAllAbilityVisuals();

        endPoint.gameObject.SetActive(true);
        endPoint.Play();
    }
}
