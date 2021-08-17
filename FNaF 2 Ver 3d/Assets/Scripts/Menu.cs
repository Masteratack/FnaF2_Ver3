using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public GameObject LoadingScreen;
    public Text ProgressText;
    #region Guziki
    public void Play(int sceneIndex)
    {
        StartCoroutine(Loading(sceneIndex));
    }
    IEnumerator Loading(int SceneIndex)
    {
        LoadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    #endregion
    #region UST
    public void SetUpVolume(float x)
    {
        mixer.SetFloat("_Vol", x);
    }
    #endregion
}