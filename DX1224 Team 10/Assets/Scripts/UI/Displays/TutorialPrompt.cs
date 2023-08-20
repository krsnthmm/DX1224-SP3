using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompt : MonoBehaviour
{
    public GameObject textPrompt;
    private Animator textPromptAnimator;
    private bool GotKey = true;

    private void Start()
    {
        textPromptAnimator = textPrompt.GetComponent<Animator>();
        textPromptAnimator.Play("None");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textPromptAnimator.Play("TextFadeIn");
        }

        if (collision.CompareTag("Player") && gameObject.CompareTag("TP5") && GotKey)
        {
            textPromptAnimator.Play("TextFadeIn");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textPromptAnimator.Play("TextFadeOut");
        }

        if (collision.CompareTag("Player") && gameObject.CompareTag("TP5") && GotKey)
        {
            textPromptAnimator.Play("TextFadeOut");
        }
    }

}
