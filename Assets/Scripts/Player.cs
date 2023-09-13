using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance;

    [SerializeField]
    private int _playerHealth;


    Ray bulletRay;
    public int range = 200;
    public GameObject Gun;

    public void Awake()
    {
        if (Instance == null)
            Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        print(_playerHealth);
        PlayerHealthHandler(true,10);
        print(_playerHealth);


    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlayerShoot();

    }

    void PlayerHealthHandler(bool _takingDamage, int damage)
    {

        if (_takingDamage)
        {
            _playerHealth = _playerHealth - damage;
        }

        else
        {
            _playerHealth = _playerHealth + damage;
        }

    }

    void PlayerShoot()
    {
        print("You shot hehe");

        DetectHit();
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
