using UnityEngine;

public class TutorialPrompt : MonoBehaviour
{
    public GameObject textPrompt;
    private Animator textPromptAnimator;

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textPromptAnimator.Play("TextFadeOut");
        }
    }

}
