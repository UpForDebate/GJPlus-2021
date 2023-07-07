using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action jump;
    public Action stopJump;
    float jumpPrevious;

    //1 if walking right, -1 if walking left
    public int walk;

    void Update()
    {
        if (Input.GetAxisRaw("Jump") != jumpPrevious) {
            if (Input.GetAxisRaw("Jump") == 1) {
                if (jump != null)
                    jump();
            }
            else {
                if (stopJump != null)
                    stopJump();
            }
        }
            jumpPrevious = Input.GetAxisRaw("Jump");

        walk = (int) Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneStuff.ResetScene();
        }
    }
}
