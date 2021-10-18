using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using MLAPI.Serialization;
using MLAPI.Messaging;



public class TestCheckRaddy : NetworkBehaviour
{
    public void AgreeCheckStudent() => AgreeCheckStudentServerRpc();

    [ServerRpc(RequireOwnership = false)]
    private void AgreeCheckStudentServerRpc(ServerRpcParams serverRpcParams = default)
    {
        ulong senderId = serverRpcParams.Receive.SenderClientId;

        NetworkObject playerObject = NetworkSpawnManager.GetPlayerNetworkObject(senderId);

        if (playerObject == null) { return; }

        var RaddyButton = playerObject.GetComponent<RaddyManager>();

    }
}

