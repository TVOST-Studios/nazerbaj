using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject Pistol;

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

}
