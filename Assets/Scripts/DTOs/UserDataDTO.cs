using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuckyFlow.EnumDefine;
using System;

namespace UserData {
    
    public class UserProfileDTO {
        public string nickname;

        public UserProfileDTO() {
            nickname = "LuckyFlow";
        }
    }

    public class GameOptionDTO {
        public double effectVolumeRatio;
        public double bgmVolumeRatio;
        public bool vibrate;
        public long language;

        public GameOptionDTO() {
            effectVolumeRatio = 1.0f;
            bgmVolumeRatio = 1.0f;
            vibrate = true;
        }
    }
}
