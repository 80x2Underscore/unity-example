using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTesting : MonoBehaviour
{
public Transform respawnPoint; // assign a respawn point in the Unity Inspector

void Update()
{
    if (Input.GetKeyDown(KeyCode.R))
    {
        Respawn();
    }
}

void Respawn()
{
    // move the player to the respawn point
    transform.position = respawnPoint.position;
}
}
