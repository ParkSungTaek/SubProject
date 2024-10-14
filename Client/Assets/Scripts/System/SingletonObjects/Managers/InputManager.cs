using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Client
{
    public struct InputParameter
    {

    }

    public class InputManager : Singleton<InputManager>
    {
        public readonly int SKILL_NUM = (int)eInputSystem.MaxValue;
        
        /// <summary>
        /// Input system에서 입력과 바인딩할 스킬의 종류들을 나타냅니다.
        /// Skill_Num을 사용할 경우 무조건 1부터 인덱싱하기.(None 때문에)
        /// </summary>
        public enum eInputSystem
        {
            None,
            Skill1,
            Skill2,
            Skill3,
            Skill4,
            MaxValue
        }

        enum eMiddleLevel
        {
            None,
            midLevel1,
            midLevel2,
            midLevel3,
            midLevel4,
            MaxValue
        }

        #region Singleton
        private InputManager()
        { }
        #endregion
        
      
        // SkillBindDict만 추후 스킬들 가지고 있는 스크립트에서 할당 필요할 때 사용 가능
        public Dictionary<eInputSystem, Action<InputParameter>> SkillBindDict;

        private Dictionary<eMiddleLevel, eInputSystem> MidKeyBind;
        private Dictionary<KeyCode, eMiddleLevel> WinKeyBind;

        private Dictionary<int, eInputSystem> AndBtnBind;
 
        // 여기다가 키코드 인식할 함수 하나하나 다 더할거임.
        public Action InputAction;

        public override void Init()
        {
            base.Init();
            GameManager.Instance.AddOnUpdate(OnUpdate);

            #region 인풋 딕셔너리 관련 하드코딩(초깃값을 데이터에서 갖고 오게 된다면 반드시 삭제할 것.)            
            {
                AndBtnBind = new Dictionary<int, eInputSystem>()
                {
                    {0, eInputSystem.Skill1},
                    {1, eInputSystem.Skill2},
                    {2, eInputSystem.Skill3},
                    {3, eInputSystem.Skill4},
                };
                WinKeyBind = new Dictionary<KeyCode, eMiddleLevel>()
                {
                    {KeyCode.Q, eMiddleLevel.midLevel1},
                    {KeyCode.W, eMiddleLevel.midLevel2},
                    {KeyCode.E, eMiddleLevel.midLevel3},
                    {KeyCode.R, eMiddleLevel.midLevel4},
                };
                MidKeyBind = new Dictionary<eMiddleLevel, eInputSystem>()
                {
                    {eMiddleLevel.midLevel1, eInputSystem.Skill1},
                    {eMiddleLevel.midLevel2, eInputSystem.Skill2},
                    {eMiddleLevel.midLevel3, eInputSystem.Skill3},
                    {eMiddleLevel.midLevel4, eInputSystem.Skill4},
                };

                SkillBindDict = new Dictionary<eInputSystem, Action<InputParameter>>()
                {
                    {eInputSystem.Skill1 , null},
                    {eInputSystem.Skill2 , null},
                    {eInputSystem.Skill3 , null},
                    {eInputSystem.Skill4 , null}
                };
                SkillBindDict[eInputSystem.Skill1] += Skill1;
                SkillBindDict[eInputSystem.Skill2] += Skill2;
                SkillBindDict[eInputSystem.Skill3] += Skill3;
                SkillBindDict[eInputSystem.Skill4] += Skill4;
            }
            #endregion

            KeyBind();
        }

        #region 스킬 디버깅용으로 하드코딩
        void Skill1(InputParameter param)
        {
            Debug.Log("스킬1번 발사.");
        }

        void Skill2(InputParameter param)
        {
            Debug.Log("스킬2번 발사.");
        }

        void Skill3(InputParameter param)
        {
            Debug.Log("스킬3번 발사.");
        }
        void Skill4(InputParameter param)
        {
            Debug.Log("스킬4번 발사.");
        }
        #endregion


        void KeyBind()
        {
            foreach(var keycode in WinKeyBind.Keys)
            {
                InputAction -= () => ThrowSkill(keycode);
                InputAction += () => ThrowSkill(keycode);
            }
        }

        /// <summary>
        /// Update 기반으로, 키 또는 버튼의 입력을 감지하여 액션 실행
        /// </summary>
        public void OnUpdate()
        {
            if(InputAction != null)
                InputAction.Invoke();
        }

        /// <summary>
        /// 설정창에서 키 바인딩에 대한 정보를 띄우기 위해서만 사용합니다.
        /// </summary>
        /// <returns></returns>
        public Dictionary<KeyCode, eInputSystem> GetAllKeyBinds()
        {
            var DirectKeyDict = new Dictionary<KeyCode, eInputSystem>();
            foreach (var keycode in WinKeyBind.Keys)
                DirectKeyDict.Add(keycode, MidKeyBind[WinKeyBind[keycode]]);
            return DirectKeyDict;
        }

        /// <summary>
        /// 설정창에서 키 세팅을 할 때 키코드를 받아서 딕셔너리를 편집
        /// </summary>
        /// <param name="setKey"></param>
        public void SetKeyBinds(KeyCode setKey)
        {

        }

        /// <summary>
        /// 버튼을 눌렀을 때 Input Manager에서 딕셔너리 통해 아~ 이거 쓰려는구나! 하고 쓰게 해준다.
        /// InputParameter은 어떻게 받아야하는걸까...?
        /// </summary>
        /// <param name="skillIndex">
        /// 버튼 ID를 뜻함 
        /// </param>
        public void ThrowSkill(int skillIndex)
        {
            if (AndBtnBind.ContainsKey(skillIndex))
            {
                Action<InputParameter> targetAction = SkillBindDict[AndBtnBind[skillIndex]];
                if (targetAction == null)
                {
                    Debug.Log($"으잉 스킬 {AndBtnBind[skillIndex]} 바인딩된거 없는뎁쇼");
                    return;
                }

                targetAction.Invoke(new InputParameter());
                //일단 아무것도 없으니까 저렇게 넣는다.
                Debug.Log($"옛다 {targetAction} 스킬이나 먹어라~");
            }
        }

        /// <summary>
        /// 키보드 키를 눌렀을 때 Input Manager에서 딕셔너리 통해 아~ 이거 쓰려는구나! 하고 쓰게 해준다.
        /// </summary>
        /// <param name="keyCode">
        /// 입력한 키코드를 뜻함
        /// </param>
        public void ThrowSkill(KeyCode keyCode)
        {
            if (Input.GetKey(keyCode))
            {
                if (WinKeyBind.ContainsKey(keyCode))
                {
                    Action<InputParameter> targetAction = SkillBindDict[MidKeyBind[WinKeyBind[keyCode]]];
                    if (targetAction == null)
                    {
                        Debug.Log($"으잉 스킬 {keyCode}에 바인딩된거 없는뎁쇼");
                        return;
                    }

                    targetAction.Invoke(new InputParameter());
                    Debug.Log($"옛다 {targetAction} 스킬이나 먹어라~");
                }
            }            
        }
    }
}