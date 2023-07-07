using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    PlayerInput playerIn;
    [SerializeField]
    Transform spritesTrans;
    
    [SerializeField]
    float playerWalkSpeed = 10f;

    public bool grounded = false;


    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerIn = gameObject.GetComponent<PlayerInput>();
        playerIn.jump += TryJump;
        playerIn.stopJump += StopJump;
        ColorActions.neutral += Neutral;
        ColorActions.blue += Blue;
        ColorActions.yellow += Yellow;
        ColorActions.gray += Gray;
        ColorActions.green += Green;
    }
    // Update is called once per frame
    void Update()
    {
        spritesTrans.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(spritesTrans.rotation.eulerAngles.z, playerRB.velocity.x, 0.2f));
        Move(playerIn.walk);            
        if (ignored == 8) {
            Jump();
        }
        if (tryJump) {
            TryJump();
        }

    }

    float walking;
    void Move(float x) {
        if (ignored != 6) {
            if (ignored == 9) {
                walking = -x;
            }
            else walking = x;
        }
        else {
            if ((x == 0 || x == walking) && playerRB.velocity.x==0) {
                walking = -walking;
            }
            if (x != 0) {
                walking = x;
            }
            if (walking == 0) {
                walking = 1;
            }
        }




        //Avoid getting stuck on a wall, by being in mid-air and pushing onto it
        ContactPoint2D[] contacts = new ContactPoint2D[1];
        if (!grounded && gameObject.GetComponent<BoxCollider2D>().GetContacts(contacts) != 0)
            if((contacts[0].point.x-transform.position.x>0 && walking > 0)|| (contacts[0].point.x - transform.position.x < 0 && walking < 0))
            return;


        playerRB.velocity = new Vector2(walking * playerWalkSpeed, playerRB.velocity.y);
    }


    //Jump Mechanics
    bool holdingJump = false;
    [SerializeField]
    float jumpSpeed = 10f;
    [SerializeField]
    float yellowJumpBoost = 20f;
    [SerializeField]
    float gravityScaleUp = 2, gravityScaleDown = 4;
    [SerializeField]
    float stopJumpStrength = 3f;



    private void FixedUpdate() {
        if (playerRB.velocity.y > 0) {
            playerRB.gravityScale = gravityScaleUp;
        }
        if (playerRB.velocity.y < 0) {
            playerRB.gravityScale = gravityScaleDown;
        }
    }
    IEnumerator JumpHold() {
        tryJump = true;
        yield return new WaitForSeconds(.1f); 
        if (tryJump) tryJump = false;
    }
    bool tryJump = false;

    void TryJump() {
        if (ignored == 8) {
            tryJump = true;
            return;
        }
        if (tryJump) {
            if (Jump()) {
                tryJump = false;
            }
            return;
        }
        

        StartCoroutine(JumpHold());
    }

    bool Jump() {
        if (grounded && ignored != 7) {
            float jump = jumpSpeed - playerRB.velocity.y;
            if (ignored == 8 && tryJump)
                jump += yellowJumpBoost;

            playerRB.velocity += Vector2.up * (jump);
            holdingJump = true;
            return true;
        }
        return false;
        
    }
    void StopJump() {
        tryJump = false;
        if (grounded || ignored == 8 || ignored == 7) {
            return;
        }
        if (playerRB.velocity.y > 0 && holdingJump) {
            playerRB.velocity = new Vector2 (playerRB.velocity.x, playerRB.velocity.y/ stopJumpStrength);
        }
        holdingJump = false;
    }




    //Colors
    public int ignored = -1;
    void Neutral() {
        if (ignored == -1) return;
        Physics2D.IgnoreLayerCollision(3, ignored, false);
        ignored = -1;
    }
    void Green() {
        if (ignored != -1) {
            Physics2D.IgnoreLayerCollision(3, ignored, false);
        }
        Physics2D.IgnoreLayerCollision(3, 6, true);
        ignored = 6;
    }
    void Blue() {
        if (ignored != -1) {
            Physics2D.IgnoreLayerCollision(3, ignored, false);
        }
        Physics2D.IgnoreLayerCollision(3, 7, true);
        ignored = 7;
    }
    void Yellow() {
        if (ignored != -1) {
            Physics2D.IgnoreLayerCollision(3, ignored, false);
        }
        Physics2D.IgnoreLayerCollision(3, 8, true);
        ignored = 8;
    }
    void Gray() {
        if (ignored != -1) {
            Physics2D.IgnoreLayerCollision(3, ignored, false);
        }
        Physics2D.IgnoreLayerCollision(3, 9, true);
        ignored = 9;
    }
}
