using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimateUIImage : MonoBehaviour
{
    public Image image;
    public Sprite[] spriteArray;
    private float speed = 0.1f; 

    private int indexSprite;
    Coroutine coroutineAnim;

    // Start is called before the first frame update
    void Start()
    {
        coroutineAnim = StartCoroutine(playImageAnimation());
    }

    IEnumerator playImageAnimation()
    {
        while (true) 
        {
            image.sprite = spriteArray[indexSprite];

            indexSprite = (indexSprite + 1) % spriteArray.Length;

            yield return new WaitForSeconds(speed); 
        }
    }
}
