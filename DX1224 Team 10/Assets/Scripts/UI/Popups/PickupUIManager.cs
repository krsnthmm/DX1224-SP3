using UnityEngine;
using TMPro;

public class PickupUIManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;
    [SerializeField] private Animator animator;

    public void OpenPrompt(Item item)
    {
        Debug.Log("Prompting description for " + item.item.name);
        animator.SetBool("open", true);

        itemName.text = item.item.name;
        itemDescription.text = item.item.description;
    }

    public void ClosePrompt()
    {
        animator.SetBool("open", false);
    }
}
