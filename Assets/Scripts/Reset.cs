using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStuff
{
    static public void ResetScene() {
        ColorActions.CallNeutral();
        ColorActions.blue = null;
        ColorActions.gray = null;
        ColorActions.yellow = null;
        ColorActions.green = null;
        ColorActions.neutral = null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    static public void NextScene() {
        ColorActions.CallNeutral();
        ColorActions.blue = null;
        ColorActions.gray = null;
        ColorActions.yellow = null;
        ColorActions.green = null;
        ColorActions.neutral = null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
