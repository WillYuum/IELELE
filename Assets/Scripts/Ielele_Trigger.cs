using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ielele_Trigger : MonoBehaviour
{
    public bool triggerHora;

    // Start is called before the first frame update
    void Start()
    {
        triggerHora = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Animal")
        {
            triggerHora = true;
        }

        Debug.Log(other.gameObject.name);

    }
}
