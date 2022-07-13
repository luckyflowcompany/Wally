using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace GameData {
    public class UIOrderDTO {
        public string uiName;
        public long order;
        public long variant;
        public string folderName;
    }

    public class LeaderDTO {
        public long level;
        public long capacity;
        public long common;
        public long rare;
        public long epic;
        public long legendary;
    }

    public class UnitDTO {
        public long unitID;
        public long skillID;
        public long selectable;
        public long rarity;
        public long attackType;
        
        public long jobID;
        public long luckyID;
        
        public long cost;
        public long mana;
        public long startMana;
        public double fireRate;
        public double range;
        public long critical;
        public long criticalRes;
        public long evasion;
        public long manaPerAtk;
        public long vitality;
        public long attack;
        public long defense;
        public long maxLevel;
        public double incMPA;
        public double incVit;
        public double incAtk;
        public double incDef;
        public long maxMPA;
        public long maxVit;
        public long maxAtk;
        public long maxDef;
        public long creature;
    }

    public class SynergyDTO {
        public long synergyID;
        public long count;
        public long targetSide;
        public long buffTarget;
        public long effectType;
        public double effectValue;
    }

    public class SkillDTO {
        public long skillID;
        public long criteria;
        public long side;
        public long targetCount;
        public float range;
        public long effectType;
        public double effectValue;
    }

    public class BuffDTO {
        public long buffID;
        public long buffType;
        public float duration;
        public long value1;
        public long value2;
        public long buffImageID;
        public long overlap;
    }

    public class QuestDTO {
        public long group;
        public long questID;
        public long type;
        public long category;
        public long grade;
        public long rewardID;
        public long dungeonID;
        public long floorCount;
    }

    public class QuestRewardDTO {
        public long rewardID;
        public long rewardType;
        public long value;
        public long first;
        public long special;
    }

    public class DungeonDTO {
        public long dungeonID;
        public long floor;
        public long roomPresetID;
        public long levelMin;
        public long levelMax;
        public long starGradeMin;
        public long starGradeMax;
        public long bossTeamID;
        public long bossLevel;
        public long bossStarGrade;
    }

    public class RoomPresetDTO {
        public long roomPresetID;
        public long enemyPresetID;
        public long fixEnemyCount;
        public long totalEnemyCount;
        public long roomCount;
        public long battle;
        public long treasure;
        public long hero;
        public long boss;
        public long camp;
        public long shop;
    }

    public class EnemyPresetDTO {
        public long enemyPresetID;
        public long enemyTeamID;
        public int percent;
    }

    public class EnemyTeamDTO {
        public long enemyTeamID;
        public long unitID;
        public int percent;
        public long location;
        public long fix;
        public long leader;
    }

    public class EquipmentDTO {
        public long equipmentID;
        public long rarity;
        public long cost;
        public long startMana;
        public float fireRate;
        public long range;
        public long critical;
        public long criticalRes;
        public long evasion;
        public long manaPerAtk;
        public long vitality;
        public long attack;
        public long defense;
        public long buffID;
        public long atlasID;
    }
}
