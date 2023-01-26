using UnityEngine;
using Unity.Netcode;

namespace HCIUD.HoloLSL
{
    public class ConnectionManager : MonoBehaviour
    {
        public enum NetworkModes { Host, Server, Client}
        public NetworkModes networkMode;


        private void Start()
        {
            var networkManager = NetworkManager.Singleton;

            if (!networkManager.IsClient && !networkManager.IsServer)
            {
                switch (networkMode)
                {
                    case NetworkModes.Host:
                        networkManager.StartHost();
                        break;
                    case NetworkModes.Server:
                        networkManager.StartServer();
                        break;
                    case NetworkModes.Client:
                        networkManager.StartClient();
                        break;
                }
            }            

        }


        //private void OnGUI()
        //{
        //    GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        //    var networkManager = NetworkManager.Singleton;
        //    if (!networkManager.IsClient && !networkManager.IsServer)
        //    {
        //        if (GUILayout.Button("Host"))
        //        {
        //            networkManager.StartHost();
        //        }

        //        if (GUILayout.Button("Client"))
        //        {
        //            networkManager.StartClient();
        //        }

        //        if (GUILayout.Button("Server"))
        //        {
        //            networkManager.StartServer();
        //        }
        //    }
        //    else
        //    {
        //        GUILayout.Label($"Mode: {(networkManager.IsHost ? "Host" : networkManager.IsServer ? "Server" : "Client")}");

        //        // "Random Teleport" button will only be shown to clients
        //        if (networkManager.IsClient)
        //        {
        //            if (GUILayout.Button("Random Teleport"))
        //            {
        //                if (networkManager.LocalClient != null)
        //                {
        //                    // Get `Player` component from the player's `PlayerObject`
        //                    if (networkManager.LocalClient.PlayerObject.TryGetComponent(out Player connectedPlayer))
        //                    {
        //                        // Invoke a `ServerRpc` from client-side to teleport player to a random position on the server-side
        //                        connectedPlayer.RpcRandomTeleportServerRpc();
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    GUILayout.EndArea();
        //}
    }
}
