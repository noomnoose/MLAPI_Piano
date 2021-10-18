using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using MLAPI.Messaging;
using System;

public class RaddyManager : NetworkBehaviour
{
    [SerializeField] private GameObject RaddyPanel;

    

    private void Update()
    {
        // Make sure this is belongs to us
        if (!IsOwner) { return; }

        // Check to see if we just hit the space key
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }

        // Send a message to THE server to execute this method
        SpawnParticleServerRpc();

        // Spawn it instantly for ourself since we don't need to
        // wait for the server
        RaddyPanel.SetActive(true);
       // Destroy(RaddyPanel, 5f);
        //Instantiate(RaddyPanel, transform.position, Quaternion.identity);
    }

    public void OpenPanelRaddy()
    {
        if (!IsOwner) { return; }

        SpawnParticleServerRpc();

        RaddyPanel.SetActive(true);

    }

    [ServerRpc(Delivery = RpcDelivery.Unreliable)]
    private void SpawnParticleServerRpc()
    {
        // Send a message to ALL clients to execute this method
        SpawnParticleClientRpc();
    }

    [ClientRpc(Delivery = RpcDelivery.Unreliable)]
    private void SpawnParticleClientRpc()
    {
        
        // Make sure we don't spawn it twice for ourselves
        if (IsOwner) { return; }

        RaddyPanel.SetActive(true);
        //Destroy(RaddyPanel, 5f);
        // Spawn the particles!
        //Instantiate(RaddyPanel, transform.position, Quaternion.identity);
    }

}
