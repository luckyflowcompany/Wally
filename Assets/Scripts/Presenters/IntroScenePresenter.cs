using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScenePresenter : MonoBehaviour {
    public static IntroScenePresenter instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        App.instance.ChangeScene(App.SCENE_NAME.Main);
    }
}
