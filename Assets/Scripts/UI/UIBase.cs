using LuckyFlow.EnumDefine;
using LuckyFlow.Event;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour {
    public bool standAlone = false;
    private CanvasOrder canvasOrder;

    public bool IsActive {
        get {
            return gameObject.activeSelf;
        }
    }

    protected void Start() {
        if (standAlone)
            SetOnStanadAlone();

        canvasOrder = GetComponent<CanvasOrder>();
    }

    public virtual void Show() {
        Common.ToggleActive(gameObject, true);
    }

    public virtual void Hide() {
        Common.ToggleActive(gameObject, false);
    }

    protected virtual void SetOnStanadAlone() {

    }

    public CANVAS_ORDER GetCanvasOrder() {
        if (canvasOrder == null ||
            canvasOrder.order < CANVAS_ORDER.PAGE)
            return CANVAS_ORDER.PAGE;
        return canvasOrder.order;
    }

    public virtual void OnCopy(List<object> datas) {
        Debug.LogError($"{gameObject.name} OnCopy 구현안됨");
    }

    public virtual List<object> GetCopyDatas() {
        Debug.LogError($"{gameObject.name} GetCopyDatas 구현안됨");
        return null;
    }

    public void SetInFrontInCanvas() {
        UIBase[] uis = transform.parent.GetComponentsInChildren<UIBase>(true);
        transform.SetSiblingIndex(uis.Length - 1);
    }

    public virtual void SetData() {

    }
}
