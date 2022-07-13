using UnityEngine;

public class ViewDrag : MonoBehaviour {
    public SpriteRenderer targetSprite;

    private Vector3 dragOrigin; //Where are we moving?
    private Vector3 clickOrigin = Vector3.zero; //Where are we starting?
    private Vector3 basePos = Vector3.zero; //Where should the camera be initially?

    void Update() {
        if (Input.GetMouseButton(0)) {
            if (clickOrigin == Vector3.zero) {
                clickOrigin = Input.mousePosition;
                basePos = transform.position;
            }
            dragOrigin = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0)) {
            clickOrigin = Vector3.zero;
            return;
        }

        transform.position = new Vector3(basePos.x + ((clickOrigin.x - dragOrigin.x) * .01f), basePos.y + ((clickOrigin.y - dragOrigin.y) * .01f), -10);

        Camera camera = Camera.main;
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Debug.Log($"bottomLeft::{bottomLeft}, topRight::{topRight}");

        Debug.Log(targetSprite.size);
        float spriteWidth = targetSprite.size.x / 2;
        float spriteHeight = targetSprite.size.y / 2;

        float clampX = 0;
        if (bottomLeft.x < -spriteWidth) {
            clampX = bottomLeft.x + spriteWidth;
            Debug.Log($"clampX1::{clampX}");
        }
        else if (topRight.x > spriteWidth) {
            clampX = topRight.x - spriteWidth;
            Debug.Log($"clampX2::{clampX}");
        }

        float clampY = 0;
        if (bottomLeft.y < -spriteHeight) {
            clampY = bottomLeft.y + spriteHeight;
            Debug.Log($"clampY1::{clampY}");
        }
        else if (topRight.y > spriteHeight) {
            clampY = topRight.y - spriteHeight;
            Debug.Log($"clampX2::{clampY}");
        }

        transform.Translate(new Vector3(-clampX, -clampY, 0));
    }
}
