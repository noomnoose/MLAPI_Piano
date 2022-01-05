using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class PianoHolder : NetworkBehaviour
{

    [SerializeField] private GameObject Piano;
    // Start is called before the first frame update
    private void Start()
    {
        Piano = GameObject.FindGameObjectWithTag("gameplay");
    }

    private void Update()
    {
        Piano = GameObject.FindGameObjectWithTag("gameplay");
 
        if (Input.GetKey(KeyCode.A))
        {
            
            PianoServerRpc();
        }    
    }

    [ServerRpc]
    private void PianoServerRpc()
    {
        PianoClientRpc();
        Debug.Log("A pass is " + IsClient);
    }

    [ClientRpc]
    private void PianoClientRpc()
    {
        if (IsOwner) { return; }

        Piano.gameObject.SetActive(true);
    }
}
