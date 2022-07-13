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

}
