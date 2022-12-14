using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Map_SceneManager : MonoBehaviour
{
    [SerializeField] GameObject initalNarative;
    [SerializeField] GameObject helper_NoPathBuilt;
    [SerializeField] GameObject helper_NoItems;

    [SerializeField] GameObject book1;
    [SerializeField] GameObject book2;
    [SerializeField] GameObject book3;
    [SerializeField] GameObject book4;
    [SerializeField] GameObject book5;
    [SerializeField] GameObject book6;


    [SerializeField] Transform level1Button;

    private int itemCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        initalNarative.SetActive(true);

        // DOTween.Sequence()
        //     .Append(level1Button.DOScale(new Vector2(1.1f, 1.1f), 0.35f).SetDelay(0.35f))
        //     .Append(level1Button.DOScale(Vector2.one, 0.35f))
        //     .SetLoops(-1, LoopType.Restart);

        ShowOneOfTheLevels();

    }

    private void PulseTransform(Transform transform)
    {
        DOTween.Sequence()
            .Append(transform.DOScale(new Vector2(1.1f, 1.1f), 0.35f).SetDelay(0.35f))
            .Append(transform.DOScale(Vector2.one, 0.35f))
            .SetLoops(-1, LoopType.Restart);
    }


    [SerializeField] private GameObject KnightLevel;
    [SerializeField] private GameObject IeleleLevel;
    [SerializeField] private GameObject endingLevel;
    public void ShowOneOfTheLevels()
    {
        void DisplayX_Icon(GameObject levelIcon)
        {
            levelIcon.transform.Find("X_Icon").gameObject.SetActive(true);
            levelIcon.GetComponent<InteractableButton_map>().SetButtonTo(MapButtonState.Locked);
        }

        if (GamePersistance.finishedKnightScene)
        {
            DisplayX_Icon(KnightLevel);
            KnightLevel.GetComponent<Button>().interactable = false;

            PulseTransform(IeleleLevel.transform);
            IeleleLevel.GetComponent<InteractableButton_map>().SetButtonTo(MapButtonState.Normal);
            IeleleLevel.GetComponent<Button>().interactable = true;
        }
        else if (GamePersistance.finishedIeleleScene)
        {
            DisplayX_Icon(KnightLevel);
            DisplayX_Icon(IeleleLevel);
            KnightLevel.GetComponent<Button>().interactable = false;
            IeleleLevel.GetComponent<Button>().interactable = false;

            PulseTransform(endingLevel.transform);
            endingLevel.GetComponent<InteractableButton_map>().SetButtonTo(MapButtonState.Normal);
            endingLevel.GetComponent<Button>().interactable = true;

        }
        else
        {
            PulseTransform(KnightLevel.transform);
            KnightLevel.GetComponent<Button>().interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextInitial()
    {
        initalNarative.SetActive(false);
    }

    public void GoToIelele()
    {
        if (GamePersistance.finishedIeleleScene == false && GamePersistance.finishedKnightScene)
        {
            if (PersistanceItems.CheckIfItemsEmpty())
            {
                helper_NoItems.SetActive(true);
            }
            else
            {
                GameManager.instance.GoToScene(GameScenes.IELELE);
            }
        }

    }

    public void GoToKnight()
    {
        if (GamePersistance.finishedKnightScene == false)
        {
            if (PersistanceItems.CheckIfItemsEmpty())
            {
                helper_NoItems.SetActive(true);
            }
            else
            {
                GameManager.instance.GoToScene(GameScenes.KnighScene);
            }
        }

    }

    public void itemHelp()
    {

    }

    public void OpenInventory()
    {
        GameManager.instance.GoToScene(GameScenes.BuyScreen);
    }

    public void itemHelp_Back()
    {
        helper_NoItems.SetActive(false);
    }

    public void pathInvalid()
    {
        helper_NoPathBuilt.SetActive(true);
    }

    public void pathInvalid_Back()
    {
        helper_NoPathBuilt.SetActive(false);
    }


    public void book()
    {
        book1.SetActive(true);

    }

    public void book_exit()
    {
        book1.SetActive(false);
        book2.SetActive(false);
        book3.SetActive(false);
        book4.SetActive(false);
        book5.SetActive(false);
        book6.SetActive(false);
    }

    public void book_next12()
    {
        book1.SetActive(false);
        book2.SetActive(true);
    }

    public void book_back21()
    {
        book1.SetActive(true);
        book2.SetActive(false);
    }

    public void book_next23()
    {
        book2.SetActive(false);
        book3.SetActive(true);
    }

    public void book_back32()
    {
        book2.SetActive(true);
        book3.SetActive(false);
    }

    public void book_next34()
    {
        book3.SetActive(false);
        book4.SetActive(true);
    }

    public void book_back43()
    {
        book3.SetActive(true);
        book4.SetActive(false);
    }

    public void book_next45()
    {
        book4.SetActive(false);
        book5.SetActive(true);
    }

    public void book_back54()
    {
        book4.SetActive(true);
        book5.SetActive(false);
    }

    public void book_next56()
    {
        book5.SetActive(false);
        book6.SetActive(true);
    }

    public void book_back65()
    {
        book5.SetActive(true);
        book6.SetActive(false);
    }



}
