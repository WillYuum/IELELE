using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_Narative : MonoBehaviour
{

    [SerializeField] GameObject helper_End1;


    private bool narative1;

    // Start is called before the first frame update
    void Start()
    {
        narative1 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void help1_close()
    {
        helper_End1.SetActive(false);
        Debug.Log("Btn pressed");
        Time.timeScale = 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal" && narative1 == false)
        {
            helper_End1.SetActive(true);

            narative1 = true;
            Time.timeScale = 0;


        }

    }


}
