using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour {
    public long id;
    public GameObject objCorrect;
    public GameObject objEffect;

    private void Awake() {
        
    }

    void OnMouseDown() {
        Common.ToggleActive(objCorrect, true);
        Common.ToggleActive(objEffect, true);

        EventManager.Notify(EventEnum.FindDragon, id);
    }
}
