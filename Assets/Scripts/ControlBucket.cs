using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBucket : MonoBehaviour
{
    /// <summary>
    /// Script pour controller le mannequin
    /// </summary>

    [Header("Références aux objets")]
    public GameObject cameraPerso;

    [Header("Références aux floats")]
    public float vitessetourne;
    public float vitesse;
    public float hauteurSaut;
    public float ajoutGravite;
    float forceDeplacement;
    float forceSaut;

    [Header("Références aux booléens")]
    public bool auSol;
    public bool curseurLock;
    public bool missionechouee;

    [Header("Références aux vectors")]
    public Vector3 distanceCamera;


    void Start()
    {
        if (curseurLock) Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Physics.Raycast(); //2D
        //Physics.SphereCast //3D

        RaycastHit infoCollision;

        auSol = Physics.SphereCast(transform.position + new Vector3(0f, 0.2f, 0f), 0.02f, Vector3.down, out infoCollision, 0.8f);

        //if (!Input.GetKeyDown(KeyCode.W))
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        //}

        //forceDeplacement = Input.GetAxis("Vertical") * vitesse;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            forceDeplacement = Input.GetAxis("Vertical") * vitesse;
        }
        else
        {
            forceDeplacement = 0f;
        }

        float forceTourne = Input.GetAxis("Mouse X") * vitessetourne;

        transform.Rotate(0f, forceTourne, 0f);

        GetComponent<Animator>().SetBool("saut", !auSol);


        if (Input.GetKeyDown(KeyCode.Space) && auSol)
        {
            forceSaut = hauteurSaut;
        }
    }

    void FixedUpdate()
    {
        if (auSol)
        {
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceSaut, forceDeplacement, ForceMode.VelocityChange);
        }
        else
        {
            GetComponent<Rigidbody>().AddRelativeForce(0f, ajoutGravite, forceDeplacement, ForceMode.VelocityChange);
        }

        //GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, forceDeplacement, ForceMode.VelocityChange);

        GetComponent<Animator>().SetFloat("vitesse", forceDeplacement);

        forceSaut = 0f;

        //GetComponent<Animator>().SetBool("saut", false);
    }
}
