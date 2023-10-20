using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector3 lastPos;
    [SerializeField] private Animator animator;
    void Start()
    {
        lastPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyWalkAnimation()
    {
        animator.Play("Walk");
    }

    public void EnemyShootAnimation()
    {
        animator.Play("Shoot");
    }
    
}
