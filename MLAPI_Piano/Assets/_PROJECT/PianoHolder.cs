using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class PianoHolder : NetworkBehaviour
{

    [SerializeField] private NetworkObject Piano;
    // Start is called before the first frame update
    public override void NetworkStart()
    {
        if (IsServer)
        {
            if (NetworkManager.Singleton.ConnectedClientsList.Count == 1)
            {
                transform.position = new Vector3(0f, 3f, 0f);
            }
            else
            {
                transform.position = new Vector3(0f, -3f, 0f);
            }
        }
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pass is " + IsClient);
            PianoServerRpc();
        }    
    }

    [ServerRpc(Delivery = RpcDelivery.Unreliable)]
    private void PianoServerRpc()
    {
        PianoClientRpc();
    }

    [ClientRpc(Delivery =  RpcDelivery.Unreliable)]
    private void PianoClientRpc()
    {
        if (IsOwner) { return; }

        //Piano.SetActive(false);
    }
}
