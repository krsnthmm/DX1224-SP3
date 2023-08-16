using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneLoader sceneLoader = GameObject.FindObjectOfType<SceneLoader>();

            if (sceneLoader != null)
            {
                sceneLoader.LoadScene(sceneToLoad);
            }
        }
    }
}
