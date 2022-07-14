using LuckyFlow.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePresenter : MonoBehaviour {
    public static MainScenePresenter instance;

    public bool playing;

    private void Awake() {
        instance = this;
        playing = false;
    }

    private void Start() {
        SetData();
    }

    private void OnEnable() {
        EventManager.Register(EventEnum.PlayGame, OnPlayGame);
        playing = true;
    }

    private void OnPlayGame(object[] data) {
        ToggleUI<Title>(UI_NAME.Title, false);
        ToggleUI<GamePlay>(UI_NAME.GamePlay, true);

        UserDataModel.instance.listFindID.Clear();
    }

    private void OnDisable() {
        EventManager.Remove(EventEnum.PlayGame, OnPlayGame);
    }

    public void SetData() {
        ToggleUI<Title>(UI_NAME.Title, true);
    }

    public void ToggleUI<T>(UI_NAME uiName, bool show) where T : UIBase {
        T ui = UIManager.instance.GetUI<T>(uiName);
        if (show) {
            ui.SetData();
            ui.Show();
        }
        else
            ui.Hide();
    }
}
