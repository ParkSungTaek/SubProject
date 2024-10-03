using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Client
{
    /// <summary>
    /// 게임에 필요한 Enum
    /// </summary>
    public class SystemEnum
    {
        public enum eSounds
        {
            BGM,
            SFX,
            MaxCount
        }
        public enum eBGM
        {

            MaxCount
        }
        public enum eSFX
        {
            MaxCount
        }
        public enum eState
        {
            None,
            HP, // 기본 HP
            NHP, // 현재 HP
            NMHP, // 현재 최고 HP

            Defence, // 기본 방어력
            NDefence, // 현재 방어력

            SP, // 기본 SP
            NSP, // 현재 SP
            NMSP, // 현재 최고 SP

            Speed, // 기본 스피드 
            NSpeed, // 현재 Speed

            Attack, // 공격력
            NAttack, // 현재 공격력

            MaxCount
        }

        public enum eTag
        {
            MaxCount
        }

        /// <summary>
        /// UI Event 종류 지정
        /// </summary>
        public enum eUIEvent
        {
            Click,
            Drag,
            DragEnd,

            MaxCount
        }

        public enum eScenes
        {
            Title,
            Loby,
            Game,

            MaxCount
        }
        public enum eCharType
        {
            None,
            Player,
            PlayerSide,
            Monster,
            NPC,
            Projectal,

            MaxCount
        }

        public enum eExecutionGroupType
        { 
            None,
            Buff,
            Debuff,
            Create,
            Action,

            MaxCount,
        }

        public enum eExecutionType
        {
            None,
            Avoidance, // 무적
            StateBuff, // 상수값 버프 증감 
            StateBuffPer, // 기본State 버프 퍼센트 증감
            StateBuffNPer, // 현재State 버프 퍼센트 증감
            Parrying, // 방향 패링
            DotDamage, // 도트 데미지

            MaxCount
        }


        public enum eExecutionCondition
        { 
            None,
            ParryingSuccess,

            MaxCount
        }
        public enum eSkillType
        {
            None,
            Dash,
            Parrying,
            Attack,
            Buff,


            MaxCount
        }
    }
}