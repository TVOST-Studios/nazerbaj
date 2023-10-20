using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gun2 : MonoBehaviour
{
    [SerializeField]
    GameObject Rifle;
    [SerializeField]
    GameObject RifleProjectile;
    [SerializeField]
    GameObject ProjectileSpawnPoint2;

    // Rifle

    public float RifleProjectileSpeed = 200f;

    Animator animator;

    public static Gun2 Instance;

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

    public void GunFireProjectile2() {
    // Get the rotation of the player's camera
    Quaternion cameraRotation = Camera.main.transform.rotation;

    // Instantiate the projectile with the camera's rotation
    GameObject rifleProjectile = Instantiate(RifleProjectile, ProjectileSpawnPoint2.transform.position, cameraRotation);

    rifleProjectile.SetActive(true);
    
    Rigidbody RifleProjectileRB = rifleProjectile.GetComponent<Rigidbody>();

    // The projectile will now move in the direction of the camera's forward vector
    RifleProjectileRB.AddForce(Camera.main.transform.forward * RifleProjectileSpeed);
    
    Destroy(rifleProjectile,3f);
    }
}
