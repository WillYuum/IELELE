using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Map_SceneManager : MonoBehaviour
{
    [SerializeField] GameObject initalNarative;
    [SerializeField] GameObject helper_NoPathBuilt;
    [SerializeField] GameObject helper_NoItems;


    [SerializeField] Transform level1Button;

    private int itemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        initalNarative.SetActive(true);

        DOTween.Sequence()
            .Append(level1Button.DOScale(new Vector2(1.1f, 1.1f), 0.35f).SetDelay(0.35f))
            .Append(level1Button.DOScale(Vector2.one, 0.35f))
            .SetLoops(-1, LoopType.Restart);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextInitial()
    {
        initalNarative.SetActive(false);
    }

    public void itemHelp()
    {
        if(itemCount == 0)
        {
            helper_NoItems.SetActive(true);
        }
        
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

}
