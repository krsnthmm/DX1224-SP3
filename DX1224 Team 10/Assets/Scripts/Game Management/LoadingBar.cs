using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    public float increaseDuration = 5f;
    private float startValue;
    private float targetValue;

    public SceneLoader sceneLoader; 
    public float loadThreshold = 1.0f; 

    private bool isLoading = false;

    private void Start()
    {
        startValue = slider.value;
        targetValue = slider.maxValue;

        StartCoroutine(IncreaseSliderValue());
    }

    private void Update()
    {
        if (!isLoading && slider.value >= loadThreshold)
        {
            isLoading = true;
            sceneLoader.LoadScene(sceneLoader.sceneToLoad);
        }
    }

    private IEnumerator IncreaseSliderValue()
    {
        float elapsedTime = 0f;

        while (elapsedTime < increaseDuration)
        {
            float t = elapsedTime / increaseDuration;
            float newValue = Mathf.Lerp(startValue, targetValue, t);

            slider.value = newValue;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = targetValue;
    }
}
