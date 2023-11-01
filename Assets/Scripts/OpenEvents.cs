using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenEvents : MonoBehaviour         //Script to run events when something happens in-game
{
    public UnityEvent events;

    public void Interact() => events?.Invoke();     //Invokes the event
}