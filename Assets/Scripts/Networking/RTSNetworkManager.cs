using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class RTSNetworkManager : NetworkManager
{
    [SerializeField]
    private GameObject unitSpawnerPrefab;
    public override void OnServerAddPlayer(NetworkConnectionToClient networkConnection)
    {
        base.OnServerAddPlayer(networkConnection);

        GameObject unitSpawnerInstance = Instantiate(
            unitSpawnerPrefab, 
            networkConnection.identity.transform.position, 
            networkConnection.identity.transform.rotation);

        NetworkServer.Spawn(unitSpawnerInstance, networkConnection);
    }
}
