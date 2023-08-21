using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FogOfWar : MonoBehaviour
{
    public Tilemap[] fogOfWars;
    public Tilemap[] fadeInRoom;
    private float fadeInDuration = 0.5f; 
    private Coroutine fadingCoroutine;
    private bool playerNotAtMH;
    private bool playerNotAtZbRoom;

    private void Start()
    {
        foreach (Tilemap tilemap in fadeInRoom)
        {
            Color color = tilemap.color;
            color.a = 0f;
            tilemap.color = color;
        }
    }

    private void Update()
    {
        if (playerNotAtMH)
        {
            if (!GameObject.FindGameObjectWithTag("Player"))
            {
                foreach (Tilemap tilemap in fogOfWars)
                {
                    tilemap.gameObject.SetActive(false);
                }
                fogOfWars[5].gameObject.SetActive(true);
            }
        }

        else if (playerNotAtZbRoom)
        { 
            if (!GameObject.FindGameObjectWithTag("Player"))
            {
                foreach (Tilemap tilemap in fogOfWars)
                {
                    tilemap.gameObject.SetActive(false);
                }
                fogOfWars[3].gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("TP1"))
        {
            if (fadingCoroutine != null)
                StopCoroutine(fadingCoroutine);

            fadingCoroutine = StartCoroutine(FadeInTilemaps());

            foreach (Tilemap tilemap in fogOfWars)
            {
                tilemap.gameObject.SetActive(false);
                fogOfWars[0].gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("TP2"))
        {
            if (fadingCoroutine != null)
                StopCoroutine(fadingCoroutine);

            fadingCoroutine = StartCoroutine(FadeInTilemaps());

            foreach (Tilemap tilemap in fogOfWars)
            {
                tilemap.gameObject.SetActive(false);
                fogOfWars[2].gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("TP3"))
        {
            if (fadingCoroutine != null)
                StopCoroutine(fadingCoroutine);

            fadingCoroutine = StartCoroutine(FadeInTilemaps());

            foreach (Tilemap tilemap in fogOfWars)
            {
                tilemap.gameObject.SetActive(false);
                fogOfWars[3].gameObject.SetActive(true);
            }

            playerNotAtZbRoom = false;
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("Room4"))
        {
            if (fadingCoroutine != null)
                StopCoroutine(fadingCoroutine);

            fadingCoroutine = StartCoroutine(FadeInTilemaps());

            foreach (Tilemap tilemap in fogOfWars)
            {
                tilemap.gameObject.SetActive(false);
                fogOfWars[4].gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("MainHall"))
        {
            if (fadingCoroutine != null)
                StopCoroutine(fadingCoroutine);

            fadingCoroutine = StartCoroutine(FadeInTilemaps());

            foreach (Tilemap tilemap in fogOfWars)
            {
                tilemap.gameObject.SetActive(false);
                fogOfWars[5].gameObject.SetActive(true);
            }

            playerNotAtMH = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.CompareTag("Hallway"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[1].gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("TP1"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[0].gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("Hallway"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[1].gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("TP2"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[2].gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("TP3"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[3].gameObject.SetActive(false);
            }

            playerNotAtZbRoom = true;
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("Room4"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[4].gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("MainHall"))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                fogOfWars[5].gameObject.SetActive(false);
            }

            playerNotAtMH = true;
        }

        if (other.CompareTag("Player") && (!gameObject.CompareTag("TP1") || !gameObject.CompareTag("Hallway") || !gameObject.CompareTag("TP2") || !gameObject.CompareTag("TP3") || !gameObject.CompareTag("Room4") || !gameObject.CompareTag("MainHall")))
        {
            foreach (Tilemap tilemap in fogOfWars)
            {
                tilemap.gameObject.SetActive(false);
                fogOfWars[1].gameObject.SetActive(true);
            }
        }

    }

    private IEnumerator FadeInTilemaps()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            foreach (Tilemap tilemap in fadeInRoom)
            {
                Color color = tilemap.color;
                color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
                tilemap.color = color;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeOutTilemaps()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            foreach (Tilemap tilemap in fadeInRoom)
            {
                Color color = tilemap.color;
                color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeInDuration);
                tilemap.color = color;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
