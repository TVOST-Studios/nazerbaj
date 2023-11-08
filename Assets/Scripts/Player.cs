using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int PlayerHealth;

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

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Camera"), LayerMask.NameToLayer("PlayerProjectile"));
    }

    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlayerShoot();

        //Animation
		// if(_speed == Vector3.zero){
		// 	//Idle
		// 	animator.SetFloat("Speed", 0);
		// }
		// else if(!Input.GetKey(KeyCode.LeftShift)){
		// 	//Walk
		// 	animator.SetFloat("Speed", 4);
		// }
		// else{
		// 	//Run
		// 	animator.SetFloat("Speed", 5);
		// }
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
        
       
        if (Gun.Instance.gameObject.activeInHierarchy){
            Gun.Instance.GunRecoil();
            Gun.Instance.GunFireProjectile();
        }

        else if (Gun2.Instance.gameObject.activeInHierarchy){
            Gun2.Instance.GunRecoil();
            Gun2.Instance.GunFireProjectile2();
        }

        shot = true;
        StartCoroutine(IWaitFor1Second());
    }

    public void DetectHit()
    {
        /*bulletRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward * range);
        if (!Physics.Raycast(bulletRay, out var hit,range))
        {
            return;
        }

        if(hit.transform.CompareTag("Enemy"))
        {
            print("Enemy hit");

            return;
        }
        */

        print("Enemy hit!");
        

    }



    IEnumerator IWaitFor1Second()
    {
        yield return new WaitForSecondsRealtime(cooldown);
        shot = false;
    }
}
