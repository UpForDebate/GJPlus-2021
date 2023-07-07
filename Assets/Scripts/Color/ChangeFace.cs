using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFace : MonoBehaviour
{
    
    [SerializeField]
    public SpriteRenderer faceRenderer, bodyRenderer;
    [SerializeField]
    Sprite neutral, sad, smiley, scared, angry;
    [SerializeField]
    Color blue, yellow, gray, green;

    private void Start() {
        ColorActions.neutral += ChangeToNeutral;
        ColorActions.blue += ChangeToSad;
        ColorActions.yellow += ChangeToSmiley;
        ColorActions.gray += ChangeToSurprised;
        ColorActions.green += ChangeToAngry;
    }

    public void ChangeToNeutral() {
        faceRenderer.sprite = neutral;
        bodyRenderer.color = Color.white;
    }
    public void ChangeToSad() {
        faceRenderer.sprite = sad;
        bodyRenderer.color = blue;
    }
    public void ChangeToSmiley() {
        faceRenderer.sprite = smiley;
        bodyRenderer.color = yellow;
    }
    public void ChangeToSurprised() {
        faceRenderer.sprite = scared;
        bodyRenderer.color = gray;
    }
    public void ChangeToAngry() {
        faceRenderer.sprite = angry;
        bodyRenderer.color = green;
    }
}
