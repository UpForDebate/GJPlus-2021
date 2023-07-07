using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public void ResetCamera() {
        Camera.main.GetComponent<CameraMove>().ResetCamera();
    }
}
