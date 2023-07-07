using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerMovement player;
    BoxCollider2D box;
    [SerializeField]
    int laserNumber = 5;
    bool previous, current;

    float skinWidth = 0.05f;
    void Start()
    {
        player = gameObject.GetComponent<PlayerMovement>();
        box = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        current = Check();
        
            
        if (previous && !current) {
            StartCoroutine(GroundedTime());
        }
        if (current) {
            player.grounded = true;
        }

        previous = current;
    }

    bool Check() {
        ContactPoint2D[] points = new ContactPoint2D[1];
        if (box.GetContacts(points) == 0) {
            return false;
        }


        for (int i = 0; i < laserNumber; i++) {
            RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(box.bounds.min.x + skinWidth + (box.bounds.size.x - 2 * skinWidth) / (laserNumber - 1) * i, box.bounds.min.y - skinWidth), Vector2.down, 0.05f);
            if (raycastHit) {
                if(raycastHit.collider.gameObject.layer != player.ignored && raycastHit.collider.gameObject.layer != 3)
                    return true;
            }
        }
        return false;
    }

    IEnumerator GroundedTime() {
        player.grounded = true;
        yield return new WaitForSeconds(.05f);
        if (player.grounded) {
            player.grounded = false;
        }

    }
}
