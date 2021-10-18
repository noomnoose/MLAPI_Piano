using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;


public class UIManagerDemo : NetworkBehaviour
{
    [SerializeField] private GameObject HostUI;
    [SerializeField] private GameObject CilentUI;
    // Start is called before the first frame update

    private void Start()
    {
       // HostUI.gameObject.SetActive(false);
       // CilentUI.gameObject.SetActive(false);
    }
    public override void NetworkStart()
    {
       
            NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
    
        //if (IsHost)
        //{
        //    HostUI.gameObject.SetActive(true);
        //    NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        //    NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
        //}
        //if (IsClient)
        //{
        //    CilentUI.gameObject.SetActive(true);
        //    NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        //    NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
        //}     
    }
    private void OnDestroy()
    {
        // Prevent error in the editor
        if (NetworkManager.Singleton == null) { return; }

        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
    }

    private void HandleClientConnected(ulong clientId)
    {

        if (IsHost)
        {
            HostUI.gameObject.SetActive(true);
        }

    }
    private void HandleClientDisconnect(ulong clientId)
    {

    }
}
