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
        QuestSlotSelected,
        BattleStart,
        BattleUnitAttack,
        PushDamageText,
        PopDamageText,
        BattleBuffGetGold,
        BattleEnd,
        RemoveCreature,
        BattleStartButtonClick,
        BattleBuffAdd,
        BattleUnitClick,
        ChangeUnitSide,
        UpdateHUD,
        RemoveUnit,
        HeroSelectPopupCardClick,
        MoveToBattleRoom,
        MoveToHeroSelectRoom,
        MoveToCamp,
        ManageParty,
        UpdateUnitState,
        HeroDeployed,
        UpdateGoods,
        ChangeRoom,
        ManagePartyComplete,
        HideBattleResult,
        ChestClick,
        GameOver,
        UnitLevelUp,
        TitleClick,
        MoveWalk,
        MoveIdle,
        HeroSelectComplete,
        SynergyUpdate,
        ShowHeroToolTip,
        ShowSynergyToolTip,

        MoveClick,
        ReadyToBattle,
        UpdateDungeonItems,
    }
}