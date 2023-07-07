using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Rect levelBounds;
    Rect cameraBounds;
    GameObject player;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        ResetCamera();
    }

    public void ResetCamera() {
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (levelBounds.width == 0 || levelBounds.height == 0) {
            levelBounds.width = float.PositiveInfinity;
            levelBounds.height = float.PositiveInfinity;
            levelBounds.center = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        }
        mainCamera = Camera.main;
        if (mainCamera.orthographicSize > levelBounds.height / 2) {
            mainCamera.orthographicSize = levelBounds.height / 2;
        }
        if (mainCamera.orthographicSize * mainCamera.aspect > levelBounds.width / 2) {
            mainCamera.orthographicSize = levelBounds.width / (mainCamera.aspect * 2);
        }
        cameraBounds = levelBounds;
        cameraBounds.height -= mainCamera.orthographicSize * 2;
        cameraBounds.width -= mainCamera.orthographicSize * 2 * mainCamera.aspect;
        cameraBounds.center += new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
    }

    // Update is called once per frame
    void Update(){

        Vector2 newCamPos = player.transform.position;

        newCamPos = new Vector2(Mathf.Clamp(newCamPos.x, cameraBounds.xMin, cameraBounds.xMax), Mathf.Clamp(newCamPos.y, cameraBounds.yMin, cameraBounds.yMax));
        MoveCamera(newCamPos);
    }
    void MoveCamera(Vector2 newPos) {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3 (newPos.x, newPos.y, mainCamera.transform.position.z), 0.2f);
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawIcon(new Vector3(levelBounds.center.x, levelBounds.center.y, 0), "animationkeyframe", false, Color.green);
        Gizmos.DrawLine(new Vector2(levelBounds.xMin, levelBounds.yMin), new Vector2(levelBounds.xMax, levelBounds.yMin));
        Gizmos.DrawLine(new Vector2(levelBounds.xMin, levelBounds.yMin), new Vector2(levelBounds.xMin, levelBounds.yMax));
        Gizmos.DrawLine(new Vector2(levelBounds.xMax, levelBounds.yMax), new Vector2(levelBounds.xMax, levelBounds.yMin));
        Gizmos.DrawLine(new Vector2(levelBounds.xMax, levelBounds.yMax), new Vector2(levelBounds.xMin, levelBounds.yMax));
    }
}
