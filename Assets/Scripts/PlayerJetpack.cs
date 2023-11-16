using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJetpack : MonoBehaviour
{
    public float JetpackAcceleration = 0.8f;
    public float MaxJetpackAcceleration = 5.0f;
    public float JetpackSpeed = 1.0f;
    public float MaxJetpackSpeed = 3.0f; // Maximum speed
    public float MaxJetpackDuration = 5.0f; // Maximum duration

    private bool _isJetpacking;
    private Vector3 _jetpackVelocity;
    private CharacterController _characterController;
    private float _jetpackTimer; // Timer for jetpack duration

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !_isJetpacking)
        {
            StartCoroutine(StartJetpackAfterDelay(0.4f));
        }
        else if (!Input.GetKey(KeyCode.Space) && _isJetpacking)
        {
            StopJetpack();
        }

        if (_isJetpacking)
        {
            ApplyJetpack();
        }
    }

    private IEnumerator StartJetpackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (Input.GetKey(KeyCode.Space))
        {
            _isJetpacking = true;
            _jetpackTimer = 0; // Reset the timer when starting the jetpack
            FirstPersonController.Instance.Gravity = 0;
        }
    }

    private void StopJetpack()
    {
        _isJetpacking = false;
        _jetpackVelocity = Vector3.zero;
        FirstPersonController.Instance.Gravity = -15;
    }

    private void ApplyJetpack()
    {
        _jetpackVelocity.y += JetpackAcceleration * Time.deltaTime;
        _jetpackVelocity.y = Mathf.Min(_jetpackVelocity.y, MaxJetpackAcceleration);

        // Add horizontal movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _jetpackVelocity += move * JetpackSpeed * Time.deltaTime;

        // Clamp the speed to the maximum speed
        _jetpackVelocity = Vector3.ClampMagnitude(_jetpackVelocity, MaxJetpackSpeed);

        _characterController.Move(_jetpackVelocity * Time.deltaTime);

        // Increase the timer and stop the jetpack if the maximum duration is reached
        _jetpackTimer += Time.deltaTime;
        if (_jetpackTimer >= MaxJetpackDuration)
        {
            StopJetpack();
        }
    }
}
