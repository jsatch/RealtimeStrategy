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

        // In the component we defined a series of SpawnPoints, that is why we get
        // the position and rotation of that transforms.
        GameObject unitSpawnerInstance = Instantiate(
            unitSpawnerPrefab, 
            networkConnection.identity.transform.position, 
            networkConnection.identity.transform.rotation);

        NetworkServer.Spawn(unitSpawnerInstance, networkConnection);
    }
}
