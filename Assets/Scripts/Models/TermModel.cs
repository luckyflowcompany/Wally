using Newtonsoft.Json;
using LuckyFlow.EnumDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TermModel : MonoBehaviour {
    public static TermModel instance;

    private Dictionary<string, TermDTO> dicTerm = new Dictionary<string, TermDTO>();

    private void Awake() {
        instance = this;
        LoadTermData();
    }

    private void OnDestroy() {
        instance = null;
    }

    private void LoadTermData() {
        TextAsset textAsset = Resources.Load<TextAsset>("Datas/Term");
        List<TermDTO> termList = JsonConvert.DeserializeObject<List<TermDTO>>(textAsset.text);
        for (int i = 0; i < termList.Count; i++) {
            
            dicTerm.Add(termList[i].code, termList[i]);
        }
    }

    public string GetTerm(string code, string[] paramValues = null) {
        if (dicTerm.ContainsKey(code) == false) {
            Debug.LogError("텀 없음::" + code);
            return code;
        }

        LANGUAGE language = (LANGUAGE)UserDataModel.instance.gameOptions.language;
        string result = string.Empty;

        if (language == LANGUAGE.kor)
            result = dicTerm[code].kor;
        else
            result = dicTerm[code].eng;

        result = result.Replace("\\n", "\n");

        if (paramValues == null)
            return result;

        for (int i = 0; i < paramValues.Length; i++) {
            result = string.Format(result, paramValues);
        }

        return result;
    }
}
