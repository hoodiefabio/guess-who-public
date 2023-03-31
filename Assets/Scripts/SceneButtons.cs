using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadingScene(sceneIndex));
    }

    private IEnumerator LoadingScene(int index)
    {
        SceneManager.LoadScene(index);
        yield return null;
    }
}
