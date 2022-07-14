using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : UIBase {
    public override void SetData() {

    }

    public void OnBtnPlayClick() {
        EventManager.Notify(EventEnum.PlayGame);
    }
}
