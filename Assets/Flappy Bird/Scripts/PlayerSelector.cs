using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] List<PlayerController> PlayerPrefabs;
    [SerializeField] Transform PlayerSpawnPosition;
    private void Awake()
    {
        var selectedColor = MainMenuManager.selectedColor;
        var playerPrefab = PlayerPrefabs.First(x => x.PlayerColor == selectedColor);

        Instantiate(playerPrefab, PlayerSpawnPosition.position, Quaternion.identity);
    }
}
