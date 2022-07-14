using LuckyFlow.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePresenter : MonoBehaviour {
    public static MainScenePresenter instance;

    public bool playing;

    private float startTime;
    private float elapsedTime;

    private void Awake() {
        instance = this;
        playing = false;
    }

    private void OnEnable() {
        EventManager.Register(EventEnum.PlayGame, OnPlayGame);
        EventManager.Register(EventEnum.FindDragon, OnFindDragon);
    }

    private void OnFindDragon(object[] data) {
        long id = (long)data[0];
        if (UserDataModel.instance.listFindID.Contains(id))
            return;

        UserDataModel.instance.AddFindID(id);
        GamePlay gamePlayUI = UIManager.instance.GetUI<GamePlay>(UI_NAME.GamePlay, true);
        gamePlayUI.UpdateDragonSlots();

        if (UserDataModel.instance.listFindID.Count == Constant.TOTAL_DRAGON_COUNT) {
            elapsedTime = Time.time - startTime;
            GameResult gameResultUI = UIManager.instance.GetUI<GameResult>(UI_NAME.GameResult);
            gameResultUI.SetData(elapsedTime);
            gameResultUI.Show();

            gamePlayUI.Hide();
        }
    }

    private void OnPlayGame(object[] data) {
        PlayGame();
    }

    private void PlayGame() {
        UserDataModel.instance.listFindID.Clear();

        Title title = UIManager.instance.GetUI<Title>(UI_NAME.Title, false);
        if (title != null)
            title.Hide();
        
        GamePlay gamePlay = UIManager.instance.GetUI<GamePlay>(UI_NAME.GamePlay);
        gamePlay.SetData();
        gamePlay.Show();

        playing = true;
        startTime = Time.time;
    }

    private void OnDisable() {
        EventManager.Remove(EventEnum.PlayGame, OnPlayGame);
        EventManager.Remove(EventEnum.FindDragon, OnFindDragon);
    }

    public void SetData(bool playGame = false) {
        if (playGame) {
            PlayGame();
        }
        else {
            Title title = UIManager.instance.GetUI<Title>(UI_NAME.Title);
            title.SetData();
            title.Show();
        }
    }
}