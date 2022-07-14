using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayDragonSlot : MonoBehaviour {
    public long id;
    public GameObject goClear;

    public void SetData() {
        if (UserDataModel.instance.listFindID.Contains(id)) {
            Common.ToggleActive(goClear, true);
        }
        else {
            Common.ToggleActive(goClear, false);
        }
    }

    public void OnBtnDragonSlotClick() {
        EventManager.Notify(EventEnum.DragonSlotClick, id);
    }
}
