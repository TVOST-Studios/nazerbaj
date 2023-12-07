using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Player")
        {
            Player.Instance.PlayerDamageHandler(120);
        }
    }
}
