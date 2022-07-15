using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChecker : MonoBehaviour {
    public GameObject prefabVfxClick;

    public Vector3 pos;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            pos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            Vector3 newPos = Input.mousePosition;
            if (Vector3.Distance(pos, newPos) > 0.1f)
                return;

            GameObject instance = Instantiate(prefabVfxClick, transform);
            RectTransform rectTransform = instance.GetComponent<RectTransform>();

            float xRatio = (float)1920 / Screen.width;
            float yRatio = (float)1080 / Screen.height;

            rectTransform.anchoredPosition =  new Vector2(Input.mousePosition.x * xRatio, Input.mousePosition.y * yRatio);
            Debug.Log($"{Input.mousePosition}");
            instance.SetActive(true);
            SoundManager.instance.PlayEffect(LuckyFlow.EnumDefine.SOUND_CLIP_EFFECT.click);
        }
    }
}
