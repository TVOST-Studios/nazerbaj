using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextScript : MonoBehaviour
{
    public GameObject EndText;

    void Start()
    {
        EndText.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Checker")
        {
            EndText.SetActive(true);
        }
    }
}