using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.HasAllParts()) {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
