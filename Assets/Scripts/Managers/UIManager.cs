using LuckyFlow.EnumDefine;
using LuckyFlow.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UI_NAME {
    NONE = -1,
    DEFAULT = 0,

    Title,
    GamePlay,
    Option,
    GameResult,

    GET_UI_END,
}

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public List<Transform> canvasTransforms;

    private Dictionary<string, GameObject> dicUIPrefabs = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> dicUIInstances = new Dictionary<string, GameObject>();

    private List<UI_NAME> globalUIs = new List<UI_NAME>() {
    };

    private List<UI_NAME> loadingUIs = new List<UI_NAME>() {
    };

    private long skinID;

    private void Awake() {
        instance = this;
    }

    private void ResetUIs() {
        dicUIPrefabs.Clear();
        Resources.UnloadUnusedAssets();

        List<string> instanceKeys = new List<string>();
        foreach (KeyValuePair<string, GameObject> pair in dicUIInstances) {
            instanceKeys.Add(pair.Key);
        }

        Dictionary<string, GameObject> oldInstanceDic = new Dictionary<string, GameObject>();

        for (int i = 0; i < instanceKeys.Count; i++) {
            string key = instanceKeys[i];

            oldInstanceDic.Add(key, dicUIInstances[key]);
        }
        dicUIInstances.Clear();

        foreach (KeyValuePair<string, GameObject> pair in oldInstanceDic) {
            UI_NAME uiName = Common.ToEnum<UI_NAME>(pair.Key);

            UIBase oldUI = pair.Value.GetComponent<UIBase>();
            if (oldUI.gameObject.activeSelf == false)
                continue;

            UIBase newUI = GetUI<UIBase>(uiName);
            newUI.OnCopy(oldUI.GetCopyDatas());
            newUI.Show();
        }

        for (int i = 0; i < instanceKeys.Count; i++) {
            string key = instanceKeys[i];

            Destroy(oldInstanceDic[key]);
        }
    }

    public static bool IsNotch() {
        if ((float)Screen.height / Screen.width < 2)
            return false;
        return true;
    }

    private void OnDestroy() {
        instance = null;
    }

    public T GetUI<T>(UI_NAME uiName, bool forceLoad = true) where T : UIBase {
        string key = uiName.ToString();
        //이미 생성된 UI가 있으면 불러온다.
        if (dicUIInstances.ContainsKey(key) && dicUIInstances[key] != null)
            return dicUIInstances[key].GetComponent<T>();

        if (forceLoad == false)
            return null;

        GameObject prefab;

        string path = "";
        //생성된 UI가 없으면 Instantiate
        if (dicUIPrefabs.ContainsKey(key) == false) {
            path = GetUIPath(uiName);

            prefab = Resources.Load<GameObject>(path);
            dicUIPrefabs.Add(key, prefab);
        }
        else
            prefab = dicUIPrefabs[key];

        if (prefab == null) {
            Debug.LogError("UI 프리팹 없음::"+ path.ToString());
            return null;
        }

        Transform canvasTransform = GetCanvasTransform(prefab);
        GameObject uiInstance = Instantiate(prefab, canvasTransform);
           
        uiInstance.name = key;
        uiInstance.SetActive(false);
        dicUIInstances.Add(key, uiInstance);
        return uiInstance.GetComponent<T>();
    }

    private Transform GetCanvasTransform(GameObject prefab) {
        CanvasOrder canvasOrder = prefab.GetComponent<CanvasOrder>();
        CANVAS_ORDER order = CANVAS_ORDER.PAGE;
        if (canvasOrder != null)
            order = canvasOrder.order;
        else {
            UI_NAME uiName = Common.ToEnum<UI_NAME>(prefab.name);
            GameData.UIOrderDTO uiOrderData = GameDataModel.instance.GetUIOrderData(uiName);
            if (uiOrderData != null)
                order = (CANVAS_ORDER)uiOrderData.order;
        }

        return GetCanvasTransform(order);
    }

    public Transform GetCanvasTransform(CANVAS_ORDER order) {
        switch (order) {
            case CANVAS_ORDER.PAGE:
                return canvasTransforms[0];

            case CANVAS_ORDER.MENU_20:
                return canvasTransforms[1];

            case CANVAS_ORDER.DECO_30:
                return canvasTransforms[2];

            case CANVAS_ORDER.POPUP_40:
                return canvasTransforms[3];

            case CANVAS_ORDER.POPUP_DECO_45:
                return canvasTransforms[4];

            case CANVAS_ORDER.TUTORIAL_50:
                return canvasTransforms[5];

            case CANVAS_ORDER.LOADING_60:
                return canvasTransforms[6];

            case CANVAS_ORDER.WARNING_70:
                return canvasTransforms[7];
        }

        return canvasTransforms[0];
    }

    private string GetUIPath(UI_NAME uiName) {
        GameData.UIOrderDTO uiOrderData = GameDataModel.instance.GetUIOrderData(uiName);

        if (uiOrderData.variant == (long)UI_VARIANT.NOT_USE) {
            string pathFormat = "Prefabs/UI/{0}/{1}";
            string folder = GetUIFolderName(uiOrderData);
            string path = string.Format(pathFormat, folder, uiName.ToString());
            return path;
        }
        else {
            string pathFormat = "Prefabs/UI/{0:D4}/{1}/{2}";
            string folder = GetUIFolderName(uiOrderData);
            string path = string.Format(pathFormat, skinID, folder, uiName.ToString());
            return path;
        }
    }

    private string GetUIFolderName(GameData.UIOrderDTO uiOrderData) {
        string folderPath = "";
        if (string.IsNullOrEmpty(uiOrderData.folderName) == false)
            folderPath = $"/{uiOrderData.folderName}";

        switch ((CANVAS_ORDER)uiOrderData.order) {
            case CANVAS_ORDER.MENU_20:
                return $"Menus{folderPath}";
            case CANVAS_ORDER.PAGE:
                return $"Pages{folderPath}";

            case CANVAS_ORDER.DECO_30:
                return $"Deco{folderPath}";

            case CANVAS_ORDER.POPUP_40:
                return $"Popups{folderPath}";
        }
        return $"Pages{folderPath}";
    }

    public void HideSceneUIs() {
        UIBase[] uis = GetComponentsInChildren<UIBase>();
        for (int i = 0; i < uis.Length; i++) {
            UI_NAME uiName = Common.ToEnum<UI_NAME>(uis[i].name);
            if (IsLoadingUI(uiName) || IsGlobalUI(uiName))
                continue;
            uis[i].Hide();
        }
    }

    private bool IsGlobalUI(UI_NAME uiName) {
        if (globalUIs.Contains(uiName))
            return true;
        return false;
    }

    private bool IsLoadingUI(UI_NAME uiName) {
        if (loadingUIs.Contains(uiName))
            return true;
        return false;
    }

    public void HideGlobalUIs() {
        UIBase[] uis = GetComponentsInChildren<UIBase>();
        for (int i = 0; i < uis.Length; i++) {
            UI_NAME uiName = Common.ToEnum<UI_NAME>(uis[i].name);
            if (IsLoadingUI(uiName) || IsGlobalUI(uiName) == false)
                continue;
            uis[i].Hide();
        }
    }

    public void DestroyUI(UI_NAME uiName) {
        string key = uiName.ToString();
        //이미 생성된 UI가 있으면 불러온다.
        if (dicUIInstances.ContainsKey(key)) {
            Destroy(dicUIInstances[key]);
            dicUIInstances.Remove(key);
        }
    }


    public UIBase GetTopUI() {
        List<CANVAS_ORDER> canvasOrders = new List<CANVAS_ORDER>() {
            CANVAS_ORDER.WARNING_70,
            CANVAS_ORDER.POPUP_40,
        };
        
        foreach (CANVAS_ORDER canvasOrder in canvasOrders) {
            Transform canvasTransform = GetCanvasTransform(canvasOrder);
            UIBase[] canvasUIs = canvasTransform.GetComponentsInChildren<UIBase>(false);
            if (canvasUIs == null || canvasUIs.Length == 0)
                continue;
            return canvasUIs[canvasUIs.Length - 1];
        }

        return null;
    }
}
