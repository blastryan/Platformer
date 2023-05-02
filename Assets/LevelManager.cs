using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPos;
    

    private void Awake()
    {
        PlayerSpawner();
    }
    void PlayerSpawner()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }
    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }
}