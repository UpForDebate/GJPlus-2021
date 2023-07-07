using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    int animationLength = 20;
    private void OnTriggerEnter2D(Collider2D collider) {
        
        if (collider.CompareTag("Player")) {
            switch (gameObject.layer) {
                case 1:
                    ColorActions.CallNeutral();
                    break;
                case 6:
                    ColorActions.CallGreen();
                    break;
                case 7:
                    ColorActions.CallBlue();
                    break;
                case 8:
                    ColorActions.CallYellow();
                    break;
                case 9:
                    ColorActions.CallGray();
                    break;

            }
            collider.GetComponent<Animation>().Play("PlayerSniff");
            collider.GetComponent<AudioSource>().Play();
            Destroy(gameObject, animationLength/60);
        }
    }
    
}
