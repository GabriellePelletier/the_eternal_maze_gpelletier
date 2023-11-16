using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gererCompteur : MonoBehaviour
{
    public int valCompteur;
    public GameObject missionPerdue;
    public GameObject bucketGal;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Compteur", 1, 1);
        InvokeRepeating("Compteur", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (lhelico.GetComponent<tourne_vis>().demarreMoteur)
        {
            InvokeRepeating("Compteur", 1, 1);
        }*/

        //valCompteur += 10;
        //GetComponent<int>(). = valCompteur.ToString();
        //GetComponent<TextMeshProUGUI>().text = valCompteur.ToString();

        if (valCompteur <= 0)
        {
            CancelInvoke("Compteur");
            Invoke("Relancer", 5f);
            missionPerdue.gameObject.SetActive(true);
            bucketGal.GetComponent<ControlBucket>().vitesse = 0;
            bucketGal.GetComponent<ControlBucket>().vitessetourne = 2;

        }

    }

    void Compteur()
    {
        valCompteur -= 1;
        GetComponent<TextMeshProUGUI>().text = valCompteur.ToString();
    }

    public void Relancer()
    {
        Scene sceneactuelle = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneactuelle.name);

    }
}
