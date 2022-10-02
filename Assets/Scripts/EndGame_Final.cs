using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_Final : MonoBehaviour
{
    [SerializeField] GameObject helper_End3;
    [SerializeField] GameObject helper_End4;


    private bool narative34;

    // Start is called before the first frame update
    void Start()
    {
        narative34 = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal" && narative34 == false)
        {
            helper_End3.SetActive(true);

            narative34 = true;


        }

    }

    public void help4_open()
    {
        helper_End3.SetActive(false);
        helper_End4.SetActive(true);
    }

    public void endGame()
    {
        GameManager.instance.GoToScene(GameScenes.Menu);
    }



}
