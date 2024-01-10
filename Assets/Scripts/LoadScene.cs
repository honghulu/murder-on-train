using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string sceneName) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Load (int sceneNumber) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNumber);
    }
}
