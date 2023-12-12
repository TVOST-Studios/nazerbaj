using System.Collections;
using System.Collections.Generic;
using StarterAssets;
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
    Animator animator;

    private Coroutine healCoroutine;

    public FirstPersonController firstPersonController;

    public float pickupDistance = 5f;
    private GameObject _closestItem;
    public PlayerInventory playerInventory;


    public AudioSource[] gunSounds;

    public void Awake()
    {
        if (Instance == null)
            Instance = this; 

        Physics.IgnoreLayerCollision(6,7);
    }


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    public void Update()
    {
        if(UI.Instance.optionsOpen == true) { return; }
        if (Input.GetMouseButtonDown(0)) PlayerShoot();
        //Animation
		if(firstPersonController._speed == 0.0f){
			//Idle
			animator.SetFloat("Speed", 0);
		}
		else if(firstPersonController._speed >= 0.01f && firstPersonController._speed < firstPersonController.SprintSpeed){
			//Walk
			animator.SetFloat("Speed", 4);
		}
		else if(firstPersonController._speed == firstPersonController.SprintSpeed){
			//Run
			animator.SetFloat("Speed", 6);
		}

        _closestItem = FindClosestItem();

        if (Input.GetKeyDown(KeyCode.E) && _closestItem != null)
        {
            PickUp(_closestItem.gameObject);
        }
    }

    GameObject FindClosestItem()
    {
        float distanceToClosestItem = Mathf.Infinity;
        GameObject closestItem = null;
        GameObject[] allItems = GameObject.FindGameObjectsWithTag("PickUpItems");

        foreach (GameObject current in allItems)
        {
            float distanceToItem = (current.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToItem < distanceToClosestItem)
            {
                distanceToClosestItem = distanceToItem;
                closestItem = current;
            }
        }

        if (distanceToClosestItem <= pickupDistance)
        {
            return closestItem;
        }

        return null;
    }

    void PickUp(GameObject item)
    {
        // Increase the number of parts in the inventory.
        playerInventory.PartsCollected();
    
        // Set all children of the item to inactive.
        foreach (Transform child in item.transform)
        {
            child.gameObject.SetActive(false);
        }
    
        // Set the item itself to inactive.
        item.SetActive(false);
    }   


    public void PlayerDamageHandler(int damage)
    {
        PlayerHealth -= damage;
        UI.Instance.UpdateUI();
        if(PlayerHealth <= 0) { PlayerDead(); return; }

        if (healCoroutine != null)
        {
            StopCoroutine(healCoroutine);
        }

        healCoroutine = StartCoroutine(HealOverTime());
    }

    IEnumerator HealOverTime()
    {
        yield return new WaitForSecondsRealtime(5);

        while (PlayerHealth < 100)
        {
            PlayerHealth = PlayerHealth + 2;
            UI.Instance.UpdateUI();
            yield return new WaitForSecondsRealtime(1);
        }
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
            gunSounds[0].volume = GlobalVariables.Instance.masterVolume;
            gunSounds[0].Play();
        }

        else if (Gun2.Instance.gameObject.activeInHierarchy){
            Gun2.Instance.GunRecoil();
            Gun2.Instance.GunFireProjectile2();
            gunSounds[1].volume = GlobalVariables.Instance.masterVolume;
            gunSounds[1].Play();
        }

        shot = true;
        StartCoroutine(IWaitFor1Second());
    }

    public void DetectHit()
    {
        print("Enemy hit!");
    }

    IEnumerator IWaitFor1Second()
    {
        yield return new WaitForSecondsRealtime(cooldown);
        shot = false;
    }

    public void PlayerDead()
    {
        firstPersonController.enabled = false;
    }
}
