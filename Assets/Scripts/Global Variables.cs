using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public static GlobalVariables Instance;

    public void Awake()
    {
        if(Instance == null) { Instance = this; }
    }

    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
