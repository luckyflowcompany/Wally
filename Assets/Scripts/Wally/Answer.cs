using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour {
    public GameObject objCorrect;

    private void Awake() {
        objCorrect.SetActive(true);
    }

    void OnMouseDown() {
        Debug.Log("MouseDown!!");
        objCorrect.SetActive(false);
    }
}
