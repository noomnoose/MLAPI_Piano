using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;


public class PlayerManager : NetworkBehaviour
{

    [SerializeField] private GameObject hostPanel;
    [SerializeField] private GameObject clientPanel;

    private void Start()
    {

        if(NetworkManager.Singleton.IsHost)
        {
            HandleServerStarted();

            //HandleClientConnected(NetworkManager.Singleton.ServerClientId);
            //NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        }

        if(NetworkManager.Singleton.IsConnectedClient)
        {
            hostPanel.SetActive(false);
            clientPanel.SetActive(true);

        }

    }

    private void OnDestroy()
    {
        // Prevent error in the editor
        if (NetworkManager.Singleton == null) { return; }

        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
    }

    private void HandleServerStarted()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            HandleClientConnected(NetworkManager.Singleton.ServerClientId);
            hostPanel.SetActive(true);
            clientPanel.SetActive(false);
        }
    }

    private void HandleClientConnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            hostPanel.SetActive(false);
            clientPanel.SetActive(true);
        }
    }

    private void HandleClientDisconnect(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            hostPanel.SetActive(false);
            clientPanel.SetActive(false);
        }
    }

}
