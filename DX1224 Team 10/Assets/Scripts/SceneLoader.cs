using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    private TMP_Text percentText;
    public string sceneToLoad;

    //public GameObject loadingScreen;
    //public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        percentText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }
    IEnumerator LoadSceneRoutine(string sceneName)
    {
        AsyncOperationHandle op = Addressables.LoadSceneAsync(sceneName);

        while (!op.IsDone)
        {
            float PercentComplete = Mathf.Clamp01(op.PercentComplete / .9f);

            yield return null;
        }
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