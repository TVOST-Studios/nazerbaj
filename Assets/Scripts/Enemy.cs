using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //EnemyAI _enemyai;
    Vector3 lastPos;
    [SerializeField] private Animator animator;
    public float EnemyHealth = 100;

    public bool isDead = false;

    public float bodyFadeSpeed = 10.0f;
    void Start()
    {
        lastPos = transform.position;
        animator = GetComponent<Animator>();
        //_enemyai = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) StartCoroutine(Wait25Seconds());
    }

    public void EnemyWalkAnimation()
    {
        animator.Play("Walk");
    }

    public void EnemyShootAnimation()
    {
        animator.Play("Shoot");
    }

    public void TakeDamage(float dmg)
    {
        EnemyHealth -= dmg;
        print(EnemyHealth);
        if(EnemyHealth <= 0 ) { EnemyDie(); }
    }
    
    void EnemyDie()
    {
        animator.enabled = false;
        isDead = true;

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }
        //_enemyai.agent.enabled = false;


        GetComponent<Rigidbody>().AddForce(-transform.forward * 5f, ForceMode.Impulse);
    }

    IEnumerator Wait5Seconds()
    {
        yield return new WaitForSecondsRealtime(25);
        EnemyDespawn();
    }

    public void EnemyDespawn()
    {
        Destroy(gameObject);
    }

}
