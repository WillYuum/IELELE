using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class KnightScene : MonoBehaviourSingleton<KnightScene>
{
    [SerializeField] private ParticleSystem endPoint;
    [SerializeField] private EventCollider endPointCollider;

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

        GameManager.instance.finishedKnightScene = true;
        endPointCollider.action += LeaveMap;
    }


    private void LeaveMap(Collider other)
    {
        if (other.tag == "Animal")
        {
            GameManager.instance.GoToScene(GameScenes.Map);
        }
    }


}
