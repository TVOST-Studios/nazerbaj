using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerJetpack : MonoBehaviour
{
    public GameObject Player;

    public float JetpackAcceleration = 0.2f;
    public float MaxJetpackAcceleration = 5.0f;
    private bool JetpackStatus;

    private Vector3 _lastVelocity;
    private CharacterController _characterController;

    private Vector3 _defaultVelocity;

    public static PlayerJetpack Instance;

    public void Awake()
    {
        if(Instance == null) { Instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { JetpackStatus = false; _lastVelocity = Vector3.zero; return; }      // Guard clause to check if space bar is released

        if (Input.GetKeyDown(KeyCode.Space) || JetpackStatus == true) { Jetpacking(); }

        FirstPersonController.Instance.Gravity = JetpackStatus ? 0 : -15;
    }

    public void Jetpacking()
    {
        Vector3 mv = _lastVelocity;

        mv.y += JetpackAcceleration;                               // Acceleration happens over time* Time.deltaTime

       // if(mv.y > MaxJetpackAcceleration) { mv.y = MaxJetpackAcceleration; }

        mv.y -= Physics.gravity.y;

       _characterController.Move(mv * (Time.deltaTime/2));  //

        _lastVelocity = _characterController.velocity;
    




        JetpackStatus = true;
        print("Im jetpackingg");
    }
}
