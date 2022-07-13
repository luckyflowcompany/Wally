using LuckyFlow.EnumDefine;
using LuckyFlow.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour {
    [Serializable]
    public class BgmInfo {
        public SOUND_CLIP_BGM name;
        public SoundManager.SOUND_PRESET preset = SoundManager.SOUND_PRESET.DEFAULT;
    }

    public enum SCENE_NAME {
        Intro,
        Title,
        Main,
        Dungeon,
    }

    public static App instance;

    public List<BgmInfo> mainBGM;

    private bool keepUI = false;
    private SCENE_NAME beforeSceneName;

    private Queue<BgmInfo> matchBlocksBGMQueue = new Queue<BgmInfo>();
    private Queue<BgmInfo> mainBGMQueue = new Queue<BgmInfo>();
    private bool changeSceneInProgress = false;

    private bool showQuest;

    public bool ChangeSceneInProgress {
        set {
            changeSceneInProgress = value;
        }
        get {
            return changeSceneInProgress;
        }
    }

    private void Awake() {
        instance = this;
    }

    private void OnEnable() {
        EventManager.Register(EventEnum.FinishedBGM, OnFinishedBGM);
    }

    private void OnFinishedBGM(object[] args) {
        PlayNextBGM();
    }

    private void OnDisable() {
        EventManager.Remove(EventEnum.FinishedBGM, OnFinishedBGM);
    }

    public void PlayMainBGM() {
        matchBlocksBGMQueue.Clear();
        mainBGMQueue.Clear();
        for (int i = 0; i < mainBGM.Count; i++) {
            int index = UnityEngine.Random.Range(0, mainBGM.Count);
            while (mainBGMQueue.Contains(mainBGM[index])) {
                index = UnityEngine.Random.Range(0, mainBGM.Count);
            }
            mainBGMQueue.Enqueue(mainBGM[index]);
        }

        PlayNextBGM();
    }

    private void PlayNextBGM() {
        Queue<BgmInfo> bgmQueue;
        //SCENE_NAME sceneName = GetSceneName();
        //if (sceneName == SCENE_NAME.MatchBlocks)
        //bgmQueue = matchBlocksBGMQueue;
        //else
        bgmQueue = mainBGMQueue;

        if (bgmQueue.Count == 0)
            return;

        BgmInfo bgmInfo = bgmQueue.Dequeue();
        SoundManager.instance.PlayBGM(bgmInfo.name, bgmInfo.preset);
        bgmQueue.Enqueue(bgmInfo);
    }

    private void OnDestroy() {
        instance = null;
    }

    public void ChangeScene(SCENE_NAME scene, bool keepUI = false, bool showQuest = false) {
        this.keepUI = keepUI;
        this.showQuest = showQuest;

        ShowLog("ChangeScene Start");
        StopAllCoroutines();
        StartCoroutine(JobChangeScene(scene));
        ShowLog("ChangeScene End");
    }

    private IEnumerator JobChangeScene(SCENE_NAME scene) {
        changeSceneInProgress = true;

        EventManager.Notify(EventEnum.SceneLoadingProgressChanged, SCENE_LOADING_PROGRESS.PREPROCESSING);
        ShowLog("JobChangeScene Start");
        //씬전환 준비가 끝날때까지 대기
        beforeSceneName = GetSceneName();
        yield return StartCoroutine(JobPreprocessing(scene));   //0 ~ 10

        EventManager.Notify(EventEnum.SceneLoadingProgressChanged, SCENE_LOADING_PROGRESS.CLEAR_BEFORE_SCENE);
        //전환하기 전 현재 씬을 정리
        yield return StartCoroutine(JobClearBeforeScene());     //10 ~ 20

        string sceneName = scene.ToString();
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        EventManager.Notify(EventEnum.SceneLoadingProgressChanged, SCENE_LOADING_PROGRESS.LOAD_NEXT_SCENE_ASYNC, async);
        //씬전환이 끝날때까지 대기
        yield return new WaitUntil(() => async.isDone);         //20 ~ 80
        ShowLog(sceneName + " 전환 완료");

        EventManager.Notify(EventEnum.SceneLoadingProgressChanged, SCENE_LOADING_PROGRESS.INIT_NEXT_SCENE);
        yield return StartCoroutine(JobInitScene(scene));       //80 ~ 100 
        ShowLog(sceneName + " 초기화 완료");

        EventManager.Notify(EventEnum.SceneLoadingProgressChanged, SCENE_LOADING_PROGRESS.DONE);
        changeSceneInProgress = false;

    }

    private T ToEnum<T>(string value) {
        if (Enum.IsDefined(typeof(T), value) == false)
            return default(T);

        return (T)Enum.Parse(typeof(T), value, true);
    }

    private IEnumerator JobInitScene(SCENE_NAME scene) {
        switch (scene) {
            case SCENE_NAME.Main:
                break;

            case SCENE_NAME.Dungeon:
                break;

            default:
                break;
        }

        yield return new WaitForEndOfFrame();
    }

    private IEnumerator JobClearBeforeScene() {
        switch (beforeSceneName) {
            default:
                break;
        }

        yield return new WaitForEndOfFrame();
    }

    private IEnumerator JobPreprocessing(SCENE_NAME scene) {
        switch (scene) {
            
            default:
                if (keepUI == false)
                    UIManager.instance.HideSceneUIs();
                break;
        }

        yield return new WaitForEndOfFrame();
    }

    public SCENE_NAME GetSceneName() {
        return ToEnum<SCENE_NAME>(SceneManager.GetActiveScene().name);
    }

    private void ShowLog(string message) {
        if (Constant.APP_LOG == false)
            return;

        Debug.Log(message);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            /*
            UIBase topUI = UIManager.instance.GetTopUI();
            if (topUI != null)
                topUI.Hide();
            */
        }
    }
}
