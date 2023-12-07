using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenecamera : MonoBehaviour
{
    public Transform targetObject;

    void Update()
    {
        if (targetObject != null)
        {
            transform.position = targetObject.position;
            transform.rotation = targetObject.rotation;
        }
    }
}
