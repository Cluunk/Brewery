using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1;
    private bool transitionActive = false;
    [SerializeField] private AudioClip transitionSound;

    public void LoadSceneCo(string sceneName)
    {
        if (transitionActive)
            return;
        transitionActive = true;
        StartCoroutine(LoadScene(sceneName));
    }
    
    private IEnumerator LoadScene(string sceneName)
    {
        SoundManager.Instance.PlayAudio(transitionSound);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
        transitionActive = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
