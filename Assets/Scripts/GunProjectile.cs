using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        print(collider.name);
        if(collider.gameObject.tag == "Enemy")
        {
            Player.Instance.DetectHit();
            collider.TryGetComponent<OpenEvents>(out var events);
            events?.Interact();

        }

        Destroy(gameObject);
    }
}
