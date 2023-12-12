using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeInText : MonoBehaviour
{
    public TextMeshProUGUI EndText; // Drag your TextMeshProUGUI object here in inspector
    public float FadeTime = 2f; // Duration of the fade-in effect

    void Start()
    {
        EndText.color = new Color(EndText.color.r, EndText.color.g, EndText.color.b, 0);
        ShowEndText();
    }

    public void ShowEndText()
    {
        StartCoroutine(FadeTextToFullAlpha(FadeTime, EndText));
        StartCoroutine(Quit());
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator Quit(){
        yield return new WaitForSeconds(10);
        Application.Quit();
    }
}