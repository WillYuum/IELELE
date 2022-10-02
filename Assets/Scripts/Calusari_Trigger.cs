using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calusari_Trigger : MonoBehaviour
{
    [SerializeField] Calusari_ScreenManager CSM;
    [SerializeField] GameObject helper_End2;

    public bool triggerCalusari;

    // Start is called before the first frame update
    void Start()
    {
        triggerCalusari = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal" && triggerCalusari == false)
        {
            StartCoroutine(narative2());
            triggerCalusari = true;
            
        }

    }

    private IEnumerator narative2()
    {
        yield return new WaitForSeconds(10f);

        helper_End2.SetActive(true);
        CSM.calusariSong.Stop();
        Destroy(CSM.calusariBand);

    }

    public void help2_close()
    {
        helper_End2.SetActive(false);
    }


}
