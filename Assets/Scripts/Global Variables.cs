using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public float masterVolume;


    public static GlobalVariables Instance;    // Using the singleton pattern

    public void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(this); }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
