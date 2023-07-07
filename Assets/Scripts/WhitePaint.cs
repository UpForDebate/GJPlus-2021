using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhitePaint : MonoBehaviour
{
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
    public void PlaySniff() {
        gameObject.GetComponent<AudioSource>().Play();
    }

}
