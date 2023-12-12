using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GunProjectileAI : MonoBehaviour
{
    public bool isPlayer = false;
    private void OnTriggerEnter(Collider collider)
    {
        print(collider.name);

        if(collider.gameObject.tag != "Enemy"){
            Destroy(gameObject);
        }

        if(collider.gameObject.tag == "Player" && !isPlayer)
        {
            print("Enemy hit you");
            collider.TryGetComponent<OpenEvents>(out var events);
            events?.Interact();
        }
    }
}
