using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
public class IDManager : NetworkBehaviour
{
    [SerializeField] private Text EnterID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }

}
