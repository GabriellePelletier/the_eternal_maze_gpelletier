using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlOpt : MonoBehaviour
{
    public GameObject[] lesCams;

    // Start is called before the first frame update
    void Start()
    {
        ActiverCam(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiverCam(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiverCam(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiverCam(2);
        }
    }

    public void ActiverCam(int indexCamActive)
    {
        foreach (GameObject laCam in lesCams)
        {
            laCam.SetActive(false);
            //GetComponent<AudioListener>().enabled = false;
        }

        lesCams[indexCamActive].SetActive(true);
        //GetComponent<AudioListener>().enabled = true;
        lesCams[indexCamActive].GetComponent<AudioListener>().enabled = true;
    }
}
