using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{
    public void StartGame() {
        SceneStuff.NextScene();
    }
    public void ExitGame() {
        Application.Quit();
    }
}
