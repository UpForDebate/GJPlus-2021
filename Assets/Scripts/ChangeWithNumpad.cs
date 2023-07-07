using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWithNumpad : MonoBehaviour
{

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            ColorActions.CallNeutral();
            
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            ColorActions.CallBlue();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            ColorActions.CallYellow();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            ColorActions.CallGray();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            ColorActions.CallGreen();
        }
    }
}
