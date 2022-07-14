using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : UIBase {
    public List<GamePlayDragonSlot> listDragonSlot;
    public GameObject goBtnOpen;
    public GameObject goBtnClose;

    public Text lblFindCount;

    public Animator animator;
    public Slider sldZoom;

    public override void SetData() {
        base.SetData();

        
        Common.ToggleActive(goBtnOpen, true);
        Common.ToggleActive(goBtnClose, false);

        Common.ToggleActive(lblFindCount.gameObject, true);

        UpdateDragonSlots();
    }

    public void UpdateDragonSlots() {
        for (int i = 0; i < listDragonSlot.Count; i++) {
            listDragonSlot[i].SetData();
        }

        lblFindCount.text = $"{UserDataModel.instance.listFindID.Count} / {Constant.TOTAL_DRAGON_COUNT}";
    }

    public void OnValueChanged() {
        //0 : 전체보기
        //1 : 최대배율
        EventManager.Notify(EventEnum.Zoom, sldZoom.value);
    }

    public void OnBtnOpenClick() {
        Common.ToggleActive(goBtnOpen, false);
        Common.ToggleActive(goBtnClose, true);


        AnimationUtil.SetTrigger(animator, "Open");
        Common.ToggleActive(lblFindCount.gameObject, false);
    }

    public void OnBtnCloseClick() {
        Common.ToggleActive(goBtnOpen, true);
        Common.ToggleActive(goBtnClose, false);

        AnimationUtil.SetTrigger(animator, "Fold");
        Common.ToggleActive(lblFindCount.gameObject, true);
    }

    public void OnBtnSettingClick() {

    }
}
