using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class SpawnIn : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
    }
}