using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour {
    public static UICamera instance;

    public Camera uiCamera;
    private void Awake() {
        instance = this;
    }
}
