using LuckyFlow.EnumDefine;
using LuckyFlow.Event;
using System.Collections.Generic;
using UnityEngine;
using UserData;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using Random = UnityEngine.Random;

public class UserDataModel : MonoBehaviour {
    public static UserDataModel instance;

    public UserProfileDTO userProfile = new UserProfileDTO();
    public GameOptionDTO gameOptions = new GameOptionDTO();

    public List<long> listFindID = new List<long>();

    private void Awake() {
        instance = this;
    }

    public void AddFindID(long findID) {
        if (listFindID.Contains(findID))
            return;

        listFindID.Add(findID);
    }
}
