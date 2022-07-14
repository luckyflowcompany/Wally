using LuckyFlow.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Answer : MonoBehaviour, IPointerClickHandler {
    public long id;
    public GameObject objCorrect;
    public GameObject objEffect;

    public GameObject objFocus;

    private void OnEnable() {
        EventManager.Register(EventEnum.DragonSlotClick, OnDragonSlotClick);
    }

    private void OnDragonSlotClick(object[] data) {
        long inputID = (long)data[0];
        if (inputID != id)
            return;

        //이미 찾았으면 리턴
        if (UserDataModel.instance.listFindID.Contains(id) == false)
            return;

        objFocus.SetActive(true);
    }

    private void OnDisable() {
        EventManager.Remove(EventEnum.DragonSlotClick, OnDragonSlotClick);
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (MainScenePresenter.instance.playing == false)
            return;

        if (objFocus.activeSelf)
            objFocus.SetActive(false);

        if (UserDataModel.instance.listFindID.Contains(id)) {
            return;
        }

        SoundManager.instance.PlayEffect(LuckyFlow.EnumDefine.SOUND_CLIP_EFFECT.found);

        Common.ToggleActive(objCorrect, true);
        Common.ToggleActive(objEffect, true);

        EventManager.Notify(EventEnum.FindDragon, id);
    }
}
