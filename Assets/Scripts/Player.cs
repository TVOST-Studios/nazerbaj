using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance;

    [SerializeField]
    private int _playerHealth;


    public void Awake()
    {
        if (Instance == null)
            Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        print(_playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
