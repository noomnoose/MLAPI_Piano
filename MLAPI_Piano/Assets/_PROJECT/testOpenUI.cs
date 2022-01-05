using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class testOpenUI : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameplaysetting;
    [SerializeField] private Transform transform;
    public bool UI = false; 
   
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) { return; }

        if (!Input.GetKeyDown(KeyCode.A)) { return; }
        ClickOpenUIServerRpc();

        //if(UI)
        //{
        //ClickOpenUIServerRpc();
        //}
    }
    public void OpenUI()
    {
        ClickOpenUIServerRpc();
    }

    [ServerRpc]
    private void ClickOpenUIServerRpc()
    {
        ClickOpenUIClientRpc();
    }
    [ClientRpc]
    private void ClickOpenUIClientRpc()
    {
        
        Instantiate(gameplaysetting,transform);
    }
}
