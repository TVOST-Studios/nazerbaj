using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIGun : MonoBehaviour
{
    [SerializeField]
    GameObject Rifle;
    [SerializeField]
    GameObject RifleProjectileAI;
    [SerializeField]
    GameObject ProjectileSpawnPointAI;

    // Rifle

    public float RifleProjectileSpeed = 200f;

    Animator animator;

    public static AIGun Instance;

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

    public void GunFireProjectileAI() {
    // Get the rotation of the enemy
    Quaternion enemyRotation = this.transform.rotation;

    // Instantiate the projectile with the enemy's rotation
    GameObject rifleProjectileAI = Instantiate(RifleProjectileAI, ProjectileSpawnPointAI.transform.position, enemyRotation);

    rifleProjectileAI.SetActive(true);

    Rigidbody RifleProjectileRBAI = rifleProjectileAI.GetComponent<Rigidbody>();

    // The projectile will now move in the opposite direction of the enemy's forward vector
    RifleProjectileRBAI.AddForce(-this.transform.forward * RifleProjectileSpeed);

    Destroy(rifleProjectileAI,3f);
}

}
