using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNarative_SceneManager : MonoBehaviour
{
    [SerializeField] GameObject narative1;
    [SerializeField] GameObject narative2;
    [SerializeField] GameObject narative3;

    // Start is called before the first frame update
    void Start()
    {
        narative1.SetActive(true);
        narative2.SetActive(false);
        narative3.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next1()
    {
        narative1.SetActive(false);
        narative2.SetActive(true);
        narative3.SetActive(false);

    }

    public void next2()
    {
        narative1.SetActive(false);
        narative2.SetActive(false);
        narative3.SetActive(true);

    }




}
