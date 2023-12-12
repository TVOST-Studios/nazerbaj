using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Tracing;

public class UI : MonoBehaviour
{

    public TextMeshProUGUI crosshair;
    bool redCrossHair;

    public Slider HealthSlider;
    public TextMeshProUGUI HealthText;

    public Image RifleOutline;

    public Image PistolOutline;
    [SerializeField]
    private GameObject Pistol;
    [SerializeField]
    private GameObject Rifle;

    public GameObject OptionsPanel;

    public bool optionsOpen = false;

    public static UI Instance;

    public TextMeshProUGUI textElement;

    public PlayerInventory playerInventory;
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsOpen && OptionsPanel.activeSelf) { CloseOptions(); return; }
            if (!optionsOpen && !OptionsPanel.activeSelf) { OpenOptions(); }

        }
    }
    
    public void OutlineToggle()
    {
        PistolOutline.enabled = Pistol.activeInHierarchy;
        RifleOutline.enabled = Rifle.activeInHierarchy;
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
        HealthText.text = HealthSlider.value.ToString();
    }

    public void OpenOptions()
    {
        print("options open");
        optionsOpen = true;
        OptionsPanel.SetActive(true);
        Time.timeScale = 0.0f;
        Player.Instance.firstPersonController.enabled = false;
        Cursor.visible = true;
    }

    public void CloseOptions()
    {
        optionsOpen = false;
        Time.timeScale = 1.0f;
        OptionsPanel.SetActive(false);
        print("opstions closed");
        Player.Instance.firstPersonController.enabled = true;
        Cursor.visible = false;

    }

    public void CollectPart(){
        
        if (playerInventory != null && textElement != null) {
            textElement.text = "Parts Collected: " + playerInventory.NumberOfParts;
        } else {
            if (playerInventory == null) {
                Debug.LogError("Player Inventory is not assigned in UI script.");
            }
            if (textElement == null) {
                Debug.LogError("Text Element is not assigned in UI script.");
            }
        }
    }

}
