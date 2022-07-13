using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using GameData;
using LuckyFlow.EnumDefine;
using System.Collections;

public class GameDataModel : MonoBehaviour {
    public static GameDataModel instance;

    public List<UIOrderDTO> uiOrders;
    
    void Awake() {
        instance = this;

        LoadGameData();
    }

    private void OnDestroy() {
        instance = null;
    }

    private void LoadGameData() {
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>("Datas/");
        for (int i = 0; i < textAssets.Length; i++) {
            TextAsset asset = textAssets[i];
            
            if (asset.name == "UIOrder") 
                uiOrders = JsonConvert.DeserializeObject<List<UIOrderDTO>>(asset.text);
        }
    }

    public UIOrderDTO GetUIOrderData(UI_NAME uiName) {
        if (IsNullOrEmpty(uiOrders))
            return null;

        foreach (UIOrderDTO uiOrderData in uiOrders) {
            if (uiOrderData.uiName == uiName.ToString())
                return uiOrderData;
        }

        return null;
    }

    private bool IsNullOrEmpty(IList gameDatas) {
        if (gameDatas == null || gameDatas.Count == 0) 
            return true;
        return false;
    }
}