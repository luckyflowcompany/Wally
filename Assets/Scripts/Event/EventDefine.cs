using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LuckyFlow.Event {
    public enum EventEnum {
        EffectVolumeChanged,
        BGMVolumeChanged,
        EffectMute,
        BGMMute,

        FinishedBGM,
        LoadTitle,
        UpdateVolume,
        SceneLoadingProgressChanged,
        
        PlayGame,
        Zoom,
        FindDragon,
        DragonSlotClick,
    }
}