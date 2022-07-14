using System;

namespace LuckyFlow.EnumDefine {
    //효과음 목록
    [Serializable]
    public enum SOUND_CLIP_EFFECT { //파일명 추가
        NONE = 0,
        click,
        found,
    }

    //BGM 목록
    [Serializable]
    public enum SOUND_CLIP_BGM {   //파일명 추가
        NONE = 0,
        BGM01,
    }

    //언어
    public enum LANGUAGE {
        none = 0,
        kor = 1,
        eng = 2,
    }

    public enum USER_DATA_KEY {
        TABLE_VERSION_INFO = 0,
    }

    public enum SCENE_LOADING_PROGRESS {
        NONE = 0,
        PREPROCESSING = 5,
        CLEAR_BEFORE_SCENE = 10,
        LOAD_NEXT_SCENE_ASYNC = 70,
        INIT_NEXT_SCENE = 99,
        DONE = 100,
    }

    public enum COMPARING_OPERATOR {
        EQUAL = 0,
        GREATER_OR_EQUAL = 1,
        LESS_OR_EQUAL = 2,
        GREATER = 3,
        LESS = 4,
        NOT_EQUAL = 5,
    }

    public enum CANVAS_ORDER {
        PAGE = 10,
        MENU_20 = 20,
        DECO_30 = 30,
        POPUP_40 = 40,
        POPUP_DECO_45 = 45,
        TUTORIAL_50 = 50,
        LOADING_60 = 60,
        WARNING_70 = 70,
    }

    public enum UI_VARIANT {
        NOT_USE = 0,
        USE = 1,
    }

    public enum QUEST_TYPE {
        MAIN = 1,
        SUB = 2,
    }

    public enum QUEST_CATEGORY {
        EXPLORE = 1,
    }

    public enum GRADE {
        F = 1,
        E = 2,
        D = 3,
        C = 4,
        B = 5,
        A = 6,
        S = 7,
    }

    public enum ATLAS_CATEGORY {
        QUEST_GRADE,
        GOODS,
        SYNERGY,
        UNIT,
        STAT,
        EQUIP,
        TILE,
    }

    public enum QUEST_REWARD_TYPE {
        COIN = 1,
        GEM = 2,
    }

    public enum GOODS_TYPE {
        COIN = 1,
        GEM = 2,
    }

    public enum SYNERGY_TYPE {
        JOB = 0,
        LUCKY = 1,
    }

    public enum ATTACK_TYPE {
        NONE = 0,
        MELEE = 1,
        HIT_SCAN = 2,
        PROJECTILE = 3,
    }

    public enum SYNERGY_ID {
        RACE_START,

        HUMAN = 1001,
        ROBOT = 1002,
        DEVIL = 1003,
        FAIRY = 1004,
        DOLL = 1005,
        PLANTY = 1006,
        GREENS = 1007,
        ELEMENTAL = 1008,

        RACE_END,
        JOB_START,

        ARCHER = 2001,
        ASSASSIN = 2002,
        WIZARD = 2003,
        EXPLORER = 2004,
        HEALER = 2005,
        SUMMONER = 2006,
        FIGHTER = 2007,
        ASSAULT = 2008,

        JOB_END,
        SPECIAL_START,

        LOVER = 3001,
        SPECIAL_END,
    }

    public enum TARGET_SIDE {
        OWN_SIDE = 1,
        ENEMY_SIDE = 2,
    }

    public enum BUFF_TARGET {
        SAME_RACE = 1,
        SAME_JOB = 2,
        SAME_SPECIAL = 3,
        ALL = 4,
        TARGET = 5,
        SUMMON = 6,
    }

    public enum EFFECT_TYPE {
        ADD_BUFF = 1,
        SUMMON = 2,

        ATK = 100,
        ATK_INC_VALUE = 101,
        ATK_INC_RATIO = 102,

        EVA = 200,
        EVA_INC_VALUE = 201,
        EVA_INC_RATIO = 202,

        DEF = 300,
        DEF_INC_VALUE = 301,
        DEF_INC_RATIO = 302,

        SKILL_DAMAGE_INC_VALUE = 401,
        SKILL_DAMAGE_INC_RATIO = 402,

        SKILL_DAMAGE_TAKEN_INC_VALUE = 501,
        SKILL_DAMAGE_TAKEN_INC_RATIO = 502,

        FIRE_RATE = 600,
        FIRE_RATE_INC_VALUE = 601,
        FIRE_RATE_INC_RATIO = 602,

        DEBUFF_TAKEN_INC_RATIO = 702,

        HEAL_TAKEN_INC_VALUE = 801,
        HEAL_TAKEN_INC_RATIO = 802,

        HP = 900,
        HP_INC_VALUE = 901,
        HP_INC_RATIO = 902,

        MANA_PER_ATK = 1000,
        MANA_PER_ATK_INC_VALUE = 1001,
        MANA_PER_ATK_INC_RATIO = 1002,

        SKILL_DAMAGE = 1101,
        SKILL_HEAL = 1201,

        HUMAN_BUFF = 10001,
    }

    public enum BUFF_TYPE {
        GET_GOLD = 101,
        GET_MANA_PER_CYCLE = 201,
        ROBOT = 301,
        MAKE_DOLL = 401,
        DOLL = 402,
        STEALTH = 501,
        STAT = 600,
        FORCE_TARGET = 701,
        DESTROY_SELF = 801,
    }

    public enum SKILL_CRITERIA {
        OWN = 1,
        NEAREST = 2,
        MOST_FAR = 3,
        HIGHEST_ATTACK = 4,
        LEAST_CURRENT_HP = 5,
        RANDOM = 6,
    }

    public enum STAT_TYPE {
        ATTACK,
        DEFENSE,
        RANGE,
        MANA_PER_ATTACK,
        FIRE_RATE,
        CRITICAL,
        CRITICAL_RES,
        EVASION,
    }

    public enum ROOM_TYPE {
        UNKNOWN = 0,
        NORMAL = 1,
        HERO_SELECT = 2,
        BATTLE = 3,
        TREASURE = 4,
        CAMP = 5,
        BOSS = 6,
        NEXTFLOOR = 7,
        SHOP = 8,
    }

    public enum ROOM_DIRECTION {
        TOP = 0,   
        BOTTOM = 1,
        LEFT = 2,
        RIGHT = 3,
    }

    public enum RARITY {
        COMMON = 1,
        RARE = 2,
        EPIC = 3,
        LEGENDARY = 4,
    }

    public enum DUNGEON_STATE { 
        NORMAL = 1,
        BATTLE = 2,
        MANAGE_PARTY = 3,
    }

    public enum EQUIPMENT_RARITY {
        COMMON = 1,
        ADVANCED = 2,
        RARE = 3,
    }
}


