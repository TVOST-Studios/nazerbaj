using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{

    public TextMeshProUGUI crosshair;
    bool redCrossHair;

    public Slider HealthSlider;

    public static UI Instance;
    public void Awake()
    {
        if(Instance == null) Instance = this;
    }

    void Start()
    {
        crosshair.color = Color.green;
    }
    void Update()
    {
        CrosshairColorChange();
        crosshair.color = redCrossHair ? Color.red : Color.green;
    }

    public void CrosshairColorChange()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if(Physics.Raycast(ray,out var hit,Player.Instance.range) && hit.transform.CompareTag("Enemy"))
        {
            redCrossHair = true;
        }
        else
        {
            redCrossHair = false;
        }
    }

    public void UpdateUI()
    {
        HealthSlider.value = Player.Instance.PlayerHealth;
    }
}
