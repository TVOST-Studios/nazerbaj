using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int PlayerHealth;

    public Collider EnemyCollider;
    [SerializeField]
    ParticleSystem particleSystem;

    bool shot = false;
    [SerializeField]
    float cooldown = 0.05f;

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

    void ParticleSystem(){
        var part = particleSystem;
        part.Play();
        Destroy(gameObject, part.main.duration);
    }

    void PlayerShoot()
    {
        if (shot) return;
        
        print("You shot hehe");

        DetectHit();
        Gun.Instance.GunRecoil();
        Gun.Instance.GunFireProjectile();
        shot = true;
        StartCoroutine(IWaitFor1Second());
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
            
            return;
        }


    }

    IEnumerator IWaitFor1Second()
    {
        yield return new WaitForSecondsRealtime(cooldown);
        shot = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("osui");
        }
    }

}
