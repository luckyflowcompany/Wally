using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : UIBase {
    public Text lblElapsedTime;

    public void SetData(float elapsedTime) {
        lblElapsedTime.text = Common.GetTimerFormat(elapsedTime);
    }

    public void OnBtnRestartClick() {
        App.instance.RestartGame();
    }

    public void OnBtnHomeClick() {
        App.instance.ChangeScene(App.SCENE_NAME.Main);
    }
}
