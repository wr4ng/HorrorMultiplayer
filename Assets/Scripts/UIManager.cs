using Unity.Netcode;
using UnityEngine;
using TMPro;

public class UIManager : NetworkBehaviour 
{
    [SerializeField] private TextMeshProUGUI playerCountText;
    private NetworkVariable<int> connectedPlayers = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private void FixedUpdate() {
        playerCountText.text = "Players: " + connectedPlayers.Value;

        if (IsServer || IsHost) {
            connectedPlayers.Value = NetworkManager.Singleton.ConnectedClients.Count;
        }
    }
}