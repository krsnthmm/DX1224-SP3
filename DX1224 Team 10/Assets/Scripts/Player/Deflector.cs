using System.Collections;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    private PlayerController player;
    private GameObject shield;
    private bool isShieldActive;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        shield = transform.GetChild(0).gameObject;
        isShieldActive = false;
        shield.SetActive(false);
    }

    private void Update()
    {
        if (shield != null)
        {
            if (Input.GetKeyDown(KeyCode.Q) && player.playerData.hasCrossEquipped)
            {
                Debug.Log("a");
                StartCoroutine(ShieldUpCo());
            }
            else if (!player.playerData.hasCrossEquipped)
            {
                isShieldActive = false;
            }

            shield.SetActive(isShieldActive);
        }
    }

    private IEnumerator ShieldUpCo()
    {
        if (shield != null)
        {
            isShieldActive = true;

            yield return new WaitForSeconds(player.playerData.shieldDuration);

            isShieldActive = false;
        }
    }
}
