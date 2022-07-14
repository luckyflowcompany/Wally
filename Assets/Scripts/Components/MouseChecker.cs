using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChecker : MonoBehaviour {
    public GameObject prefabVfxClick;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject instance = Instantiate(prefabVfxClick, transform);
            RectTransform rectTransform = instance.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Input.mousePosition;
            Debug.Log($"{Input.mousePosition}");
            instance.SetActive(true);
            SoundManager.instance.PlayEffect(LuckyFlow.EnumDefine.SOUND_CLIP_EFFECT.click);
        }
    }
}
