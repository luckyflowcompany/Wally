using LuckyFlow.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    public SpriteRenderer targetSprite;

    public float zoomSpeed = 10f;

    private Camera cam;
    private void Start() {
        cam = GetComponent<Camera>();
    }

    private void OnEnable() {
        EventManager.Register(EventEnum.Zoom, OnZoom);
    }

    private void OnZoom(object[] data) {
        float t = (float)data[0];

        cam.orthographicSize = Mathf.Lerp(Constant.ORTHOGRAPHIC_SIZE_MAX, Constant.ORTHOGRAPHIC_SIZE_MIN, t);

        Camera camera = Camera.main;
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        
        float spriteWidth = targetSprite.size.x / 2;
        float spriteHeight = targetSprite.size.y / 2;

        float clampX = 0;
        if (bottomLeft.x < -spriteWidth) {
            clampX = bottomLeft.x + spriteWidth;
        }
        else if (topRight.x > spriteWidth) {
            clampX = topRight.x - spriteWidth;
        }

        float clampY = 0;
        if (bottomLeft.y < -spriteHeight) {
            clampY = bottomLeft.y + spriteHeight;
        }
        else if (topRight.y > spriteHeight) {
            clampY = topRight.y - spriteHeight;
        }

        transform.Translate(new Vector3(-clampX, -clampY, 0));
    }

    private void OnDisable() {
        EventManager.Remove(EventEnum.Zoom, OnZoom);
    }

    private void SetZoom() {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1, 7);

        Camera camera = Camera.main;
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        
        float spriteWidth = targetSprite.size.x / 2;
        float spriteHeight = targetSprite.size.y / 2;

        float clampX = 0;
        if (bottomLeft.x < -spriteWidth) {
            clampX = bottomLeft.x + spriteWidth;
            //Debug.Log($"clampX1::{clampX}");
        }
        else if (topRight.x > spriteWidth) {
            clampX = topRight.x - spriteWidth;
            //Debug.Log($"clampX2::{clampX}");
        }

        float clampY = 0;
        if (bottomLeft.y < -spriteHeight) {
            clampY = bottomLeft.y + spriteHeight;
            //Debug.Log($"clampY1::{clampY}");
        }
        else if (topRight.y > spriteHeight) {
            clampY = topRight.y - spriteHeight;
            //Debug.Log($"clampX2::{clampY}");
        }

        transform.Translate(new Vector3(-clampX, -clampY, 0));
    }
}
