using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaRespawn : MonoBehaviour
{
    public GameObject spawnPoint;
    private bool touched = false;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player touched the respawn object");
            touched = true;
        }
    }

    void Update() {
        if (touched) {
            Debug.Log("Respawning player");
            gameObject.transform.position = spawnPoint.transform.position;
            touched = false;
        }
    }

}