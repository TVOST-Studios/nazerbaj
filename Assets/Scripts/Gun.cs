using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject Pistol;
    [SerializeField]
    public GameObject PistolProjectile;
    [SerializeField]
    GameObject ProjectileSpawnPoint;

    // Pistol

    public float PistolProjectileSpeed = 200f;

    Animator animator;

    public static Gun Instance;

    public void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GunRecoil()
    {
        animator.SetTrigger("shoot");
    }

    public void GunFireProjectile()
    {
        GameObject pistolProjectile = Instantiate(PistolProjectile, ProjectileSpawnPoint.transform.position, Quaternion.identity);
        Rigidbody PistolProjectileRB = pistolProjectile.GetComponent<Rigidbody>();

        GunProjectile gunProjectile = pistolProjectile.GetComponent<GunProjectile>();
        if (gunProjectile != null)
        {
            gunProjectile.isPlayer = true;
        }

        PistolProjectileRB.AddForce(ProjectileSpawnPoint.transform.forward * PistolProjectileSpeed);
        Destroy(pistolProjectile,3f);
    }

}