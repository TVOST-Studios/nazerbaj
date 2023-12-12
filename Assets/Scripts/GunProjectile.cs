using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class GunProjectile : MonoBehaviour
{
    public bool isPlayer = false;

    private void OnTriggerEnter(Collider collider)
    {
        print(collider.name);
        if(collider.gameObject.tag == "Enemy")
        {
            Player.Instance.DetectHit();
            collider.TryGetComponent<OpenEvents>(out var events);
            events?.Interact();
        }

        if(collider.gameObject.tag != "Player"){
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
