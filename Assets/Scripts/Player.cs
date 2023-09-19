using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int PlayerHealth;

    Ray bulletRay;
    public int range = 200;
    public GameObject PlayerGun;

    public void Awake()
    {
        if (Instance == null)
            Instance = this; 
    }

    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlayerShoot();
    }

    void PlayerHealthHandler(bool _takingDamage, int damage)
    {

        if (_takingDamage)
        {
            PlayerHealth = PlayerHealth - damage;
        }

        else
        {
            PlayerHealth = PlayerHealth + damage;
        }

        UI.Instance.UpdateUI();
    }

    void PlayerShoot()
    {
        print("You shot hehe");

        DetectHit();
        Gun.Instance.GunRecoil();
    }

    void DetectHit()
    {
        bulletRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward * range);
        if (!Physics.Raycast(bulletRay, out var hit,range))
        {
            return;
        }

        if(hit.transform.CompareTag("Enemy"))
        {
            print("Enemy hit");

            return;
        }
    }
}
