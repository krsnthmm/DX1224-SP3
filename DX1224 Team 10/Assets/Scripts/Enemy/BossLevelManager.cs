using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject exitBlocker;
    [SerializeField] private GameObject finish;
    [SerializeField] private GameObject bossEnemyObj;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private AudioPlayer audioPlayer;
    private Enemy bossEnemy;

    [Header("Timer")]
    [HideInInspector] public float timer;
    [SerializeField] private float timeTilPhaseChange;
    [SerializeField] private float timeTilExitOpen;

    [HideInInspector] public bool hasSwitchedPhase;
    [HideInInspector] public bool isExitOpen;

    // Start is called before the first frame update
    void Start()
    {
        bossEnemy = bossEnemyObj.GetComponent<Enemy>();
        timer = timeTilExitOpen;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < timeTilExitOpen - timeTilPhaseChange && !hasSwitchedPhase)
        {
            SwitchPhase();
        }
        else if (timer < 0f && !isExitOpen)
        {
            OpenExit();
        }
    }

    private void SwitchPhase()
    {
        if (bossEnemy.canKnockback)
        {
            bossEnemy.moveSpeed = playerData.walkSpeed;
            bossEnemy.attack *= 2;
            bossEnemy.thrust *= 2;
            bossEnemy.idleTime /= 2;
        }
        else if (bossEnemy.projPrefab != null)
        {
            bossEnemy.moveSpeed = playerData.walkSpeed;
            bossEnemy.numOfProjectiles *= 2;
            bossEnemy.projectileSpread = 350;
            bossEnemy.idleTime /= 2;
        }

        hasSwitchedPhase = true;
    }

    private void OpenExit()
    {
        audioPlayer.PlayClip(1);
        exitBlocker.SetActive(false);
        finish.SetActive(true);
        isExitOpen = true;
    }
}
