using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant {

    //-->로그
    public static bool SHOW_EVENT_LOG = false;  //이벤트 로그
    public static bool APP_LOG = false; //App.cs 로그
    public static bool SHOW_TWEEN_NUMBER_LOG = false;
    //<--로그

    //-->사운드
    public const long MULTIPLE_EFFECT_PLAY_MAX = 5;
    //<--사운드

    public const int INCORRECT = -1;

    public const string SKIN_ID_PATH = "_SKIN_ID";
    public const string LANGUAGE_PATH = "_LANGUAGE";

    public const long TOTAL_DRAGON_COUNT = 6;

    public const float ORTHOGRAPHIC_SIZE_MIN = 1.5f;
    public const float ORTHOGRAPHIC_SIZE_MAX = 4.5f;

    public static bool TEST_MODE = true;
}
