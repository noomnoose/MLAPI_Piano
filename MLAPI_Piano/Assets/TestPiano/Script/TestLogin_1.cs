using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using TMPro;
using System;
using System.Text;

public class TestLogin_1 : NetworkBehaviour
{
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private GameObject passwordEntryUI;
    [SerializeField] private GameObject leaveButton;
    //[SerializeField] private GameObject hostPanel;
    //[SerializeField] private GameObject clientPanel;

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
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
            //hostPanel.SetActive(true);
            //clientPanel.SetActive(false);

        }
    }

    private void HandleClientConnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            passwordEntryUI.SetActive(false);
            leaveButton.SetActive(true);
            //hostPanel.SetActive(false);
            //clientPanel.SetActive(true);

        }
    }

    private void HandleClientDisconnect(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            passwordEntryUI.SetActive(true);
            leaveButton.SetActive(false);
            //hostPanel.SetActive(false);
            //clientPanel.SetActive(false);
        }
    }

    public void Host()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck; 
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host strat");

    }

    public void Client()
    {
        NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(passwordInputField.text);
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client strat");

    }

    public void Leave()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.StopHost();
            NetworkManager.Singleton.ConnectionApprovalCallback -= ApprovalCheck;
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.StopClient();
        }

        passwordEntryUI.SetActive(true);
        leaveButton.SetActive(false);
        //hostPanel.SetActive(false);
        //clientPanel.SetActive(false);
    }

    public void Enter()
    {
        if(passwordInputField.text == "host")
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("Login whit host");
        }
        else if (passwordInputField.text == "test")
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log("Login whit user");
        }
        else
        {
            Debug.Log("รหัสผิด");
        }
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientId,NetworkManager.ConnectionApprovedDelegate callback)
    {
        string password = Encoding.ASCII.GetString(connectionData);
        bool approveConnection = password == passwordInputField.text;
        callback(true, null, approveConnection, null, null);
    }
}
