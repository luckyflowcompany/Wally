using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : UIBase {
    public Slider sldBGM;
    public Slider sldEffect;

    public override void SetData() {
        sldBGM.SetValueWithoutNotify((float)UserDataModel.instance.gameOptions.bgmVolumeRatio);
        sldEffect.SetValueWithoutNotify((float)UserDataModel.instance.gameOptions.effectVolumeRatio);
    }

    public void OnBtnBackClick() {
        Hide();
    }

    public void OnBtnQuitClick() {
        App.instance.ChangeScene(App.SCENE_NAME.Main);
    }

    public void OnEffectVolumeChanged() {
        EventManager.Notify(EventEnum.EffectVolumeChanged, sldEffect.value);
        Debug.Log($"ChangeEffectVolume::{sldEffect.value}");
    }

    public void OnBGMVolumeChanged() {
        EventManager.Notify(EventEnum.BGMVolumeChanged, sldBGM.value);
    }
}
