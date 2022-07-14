using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : UIBase {
    public Text lblElapsedTime;

    public void SetData(float elapsedTime) {
        lblElapsedTime.text = Common.GetTimerFormat(elapsedTime);
        SoundManager.instance.PlayEnvironment(LuckyFlow.EnumDefine.SOUND_CLIP_ENVIRONMENT.victory);
    }

    public void OnBtnRestartClick() {
        App.instance.RestartGame();
    }

    public void OnBtnHomeClick() {
        App.instance.ChangeScene(App.SCENE_NAME.Main);
    }
}
