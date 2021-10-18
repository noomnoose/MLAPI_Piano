using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MLAPI;
using System;

public class PlayerController : NetworkBehaviour
{
    public NavMeshAgent nav;
    public Camera cam;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        nav = transform.GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main;

        if (IsLocalPlayer)
        {
            Movement();
        }
    }

    void Movement()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit,100) && hit.transform.tag == "Floor")
            {
                nav.SetDestination(hit.point);
            }
        }
    }
}
