using System.Collections;
using UnityEngine;
using TMPro;

public class BossLevelUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BossLevelManager bossLevelManager;
    [SerializeField] private Animator animator;

    [Header("UI Components")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text dangerText;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("counting", false);
        StartCoroutine(OpenPrompt());
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossLevelManager.isExitOpen)
        {
            int minutes = Mathf.FloorToInt(bossLevelManager.timer / 60f);
            int seconds = Mathf.FloorToInt(bossLevelManager.timer % 60f);

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            if (bossLevelManager.hasSwitchedPhase)
            {
                dangerText.text = "DANGER!";
            }
        }
        else
        {
            timerText.text = "Exit opened!";
            dangerText.text = "";
            StartCoroutine(ClosePrompt());
        }
    }

    private IEnumerator OpenPrompt()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("counting", true);
    }

    private IEnumerator ClosePrompt()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("counting", false);
    }
}
