using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gererBouton : MonoBehaviour
{
    [Header("Références aux objets")]
    public GameObject[] objectActiver;
    public GameObject[] objectDesactiver;

    // Update is called once per frame
    void Update()
    {

    }

    public void commencerJeu()
    {
        foreach (GameObject obj in objectActiver)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectDesactiver)
        {
            obj.SetActive(false);
        }
    }

}