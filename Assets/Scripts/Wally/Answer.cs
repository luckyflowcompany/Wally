using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Answer : MonoBehaviour, IPointerClickHandler {
    public long id;
    public GameObject objCorrect;
    public GameObject objEffect;

    public void OnPointerClick(PointerEventData eventData) {
        if (MainScenePresenter.instance.playing == false)
            return;

        Common.ToggleActive(objCorrect, true);
        Common.ToggleActive(objEffect, true);

        EventManager.Notify(EventEnum.FindDragon, id);
    }
}
