using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ielele_SceneManager : MonoBehaviour
{
    [SerializeField] GameObject hora;
    [SerializeField] Ielele_Trigger IT;

    [SerializeField] GameObject helper_Ielele1;
    [SerializeField] GameObject helper_Ielele2;

    [SerializeField] GameObject endPointIonut;

    AudioSource ieleleSong;

    private Vector3 horaPosition;

    private bool horaStart;

    [SerializeField] private EventCollider wellCollider;

    // Start is called before the first frame update
    void Start()
    {
        wellCollider.action += onFinishIelele;

        horaPosition = new Vector3(34.75f, -1.0f, 39.98f);
        horaStart = false;

        endPointIonut.SetActive(false);

    }

    private GameObject enemyLeft;

    // Update is called once per frame
    void Update()
    {
        if (horaStart == false && IT.triggerHora == true)
        {
            enemyLeft = Instantiate(
           hora,
           horaPosition,
           Quaternion.Euler(0f, 0f, 0f),
           transform);

            ieleleSong = GetComponent<AudioSource>();
            ieleleSong.Play(0);


            StartCoroutine(narativIelele1());


            horaStart = true;
        }

        Debug.Log("Hora start is " + horaStart + "; triggerHora is" + IT.triggerHora);

    }



    [SerializeField] private ParticleSystem endPoint;
    [SerializeField] private EventCollider endPointCollider;


    public void onFinishIelele(Collider other)
    {
        if (other.tag == "Animal")
        {
            Destroy(gameObject.GetComponent<AudioSource>());
            Destroy(enemyLeft);
            endPointCollider.action += LeaveMap;


            narativIelele2();
        }

    }


    private void LeaveMap(Collider other)
    {
        if (other.tag == "Animal")
        {
            GameManager.instance.GoToScene(GameScenes.Calusari);
        }
    }



    private IEnumerator narativIelele1()
    {
        yield return new WaitForSeconds(2.0f);
        helper_Ielele1.SetActive(true);
        Time.timeScale = 0;


    }

    public void narativ1Ielele_close()
    {
        helper_Ielele1.SetActive(false);
        Time.timeScale = 1;
    }


    public void narativIelele2()
    {
        helper_Ielele2.SetActive(true);
        Time.timeScale = 0;
    }

    public void narativ2Ielele_close()
    {
        helper_Ielele2.SetActive(false);
        Time.timeScale = 1;

        endPointIonut.SetActive(true);
    }

}
