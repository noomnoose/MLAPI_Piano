using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using TMPro;

public class LoginManagerDemo : NetworkBehaviour
{

    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private GameObject LoginUI;
    [SerializeField] private GameObject HostUI;
    [SerializeField] private GameObject CilentUI;

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
        Debug.Log("Start");

    }

    private void OnDestroy()
    {
        // Prevent error in the editor
        if (NetworkManager.Singleton == null) { return; }

        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
    }

    public void Login()
    {
        if (emailInputField.text == "host")
        {
            NetworkManager.Singleton.StartHost();
            LoginUI.gameObject.SetActive(false);
            Debug.Log("Login whit host");
        }
        else if (emailInputField.text == "user")
        {
            NetworkManager.Singleton.StartClient();
            LoginUI.gameObject.SetActive(false);
            Debug.Log("Login whit user");
        }
        else
        {
            Debug.Log("รหัสผิด");
        }
    }

    private void HandleServerStarted()
    {
        if (NetworkManager.Singleton.IsHost)
        {
           // HandleClientConnected(NetworkManager.Singleton.ServerClientId);
            HostUI.gameObject.SetActive(true);
            Debug.Log("Connected with host");
        }
    }

    private void HandleClientConnected(ulong clientId)
    {
        
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("Connected with cilent");
            HostUI.gameObject.SetActive(false);
            CilentUI.gameObject.SetActive(true);

            //if(IsHost)
            //{
            //    HostUI.gameObject.SetActive(true);
            //    CilentUI.gameObject.SetActive(false);
            //    Debug.Log("Connected with host");

            //}

            //if (IsClient)
            //{
            //    HostUI.gameObject.SetActive(false);
            //    CilentUI.gameObject.SetActive(true);
            //    Debug.Log("Connected with Client");

            //}
        }
    }

    private void HandleClientDisconnect(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            LoginUI.gameObject.SetActive(true);
            HostUI.gameObject.SetActive(false);
            CilentUI.gameObject.SetActive(false);
        }
    }
}
