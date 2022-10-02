using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class KnightScene : MonoBehaviourSingleton<KnightScene>
{
    [SerializeField] private ParticleSystem endPoint;
    [SerializeField] private EventCollider endPointCollider;

    [SerializeField] GameObject helperKnight;

    private void Awake()
    {
        endPoint.gameObject.SetActive(false);
    }

    public void Start()
    {
        StartCoroutine(narativeKnight());
    }


    public void OnKillKnight()
    {
        var BattleCards_UI = GameObject.Find("BattleCards_UI");
        BattleCards_UI.SetActive(false);

        MainCharacter.instance.DisableAllAbilityVisuals();

        endPoint.gameObject.SetActive(true);
        endPoint.Play();

        GamePersistance.finishedKnightScene = true;
        endPointCollider.action += LeaveMap;
    }


    private void LeaveMap(Collider other)
    {
        if (other.tag == "Animal")
        {
            GameManager.instance.GoToScene(GameScenes.Map);
        }
    }



    private IEnumerator narativeKnight()
    {
        yield return new WaitForSeconds(4f);
        helperKnight.SetActive(true);
        pauseGame();

    }


    private void pauseGame()
    {

        Time.timeScale = 0;

    }

    public void playGame()
    {

        Time.timeScale = 1;

        helperKnight.SetActive(false);

    }






}
