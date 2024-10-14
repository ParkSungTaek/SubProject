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
        /// Input system���� �Է°� ���ε��� ��ų�� �������� ��Ÿ���ϴ�.
        /// Skill_Num�� ����� ��� ������ 1���� �ε����ϱ�.(None ������)
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
        
      
        // SkillBindDict�� ���� ��ų�� ������ �ִ� ��ũ��Ʈ���� �Ҵ� �ʿ��� �� ��� ����
        public Dictionary<eInputSystem, Action<InputParameter>> SkillBindDict;

        private Dictionary<eMiddleLevel, eInputSystem> MidKeyBind;
        private Dictionary<KeyCode, eMiddleLevel> WinKeyBind;

        private Dictionary<int, eInputSystem> AndBtnBind;
 
        // ����ٰ� Ű�ڵ� �ν��� �Լ� �ϳ��ϳ� �� ���Ұ���.
        public Action InputAction;

        public override void Init()
        {
            base.Init();
            GameManager.Instance.AddOnUpdate(OnUpdate);

            #region ��ǲ ��ųʸ� ���� �ϵ��ڵ�(�ʱ갪�� �����Ϳ��� ���� ���� �ȴٸ� �ݵ�� ������ ��.)            
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

        #region ��ų ���������� �ϵ��ڵ�
        void Skill1(InputParameter param)
        {
            Debug.Log("��ų1�� �߻�.");
        }

        void Skill2(InputParameter param)
        {
            Debug.Log("��ų2�� �߻�.");
        }

        void Skill3(InputParameter param)
        {
            Debug.Log("��ų3�� �߻�.");
        }
        void Skill4(InputParameter param)
        {
            Debug.Log("��ų4�� �߻�.");
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
        /// Update �������, Ű �Ǵ� ��ư�� �Է��� �����Ͽ� �׼� ����
        /// </summary>
        public void OnUpdate()
        {
            if(InputAction != null)
                InputAction.Invoke();
        }

        /// <summary>
        /// ����â���� Ű ���ε��� ���� ������ ���� ���ؼ��� ����մϴ�.
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
        /// ����â���� Ű ������ �� �� Ű�ڵ带 �޾Ƽ� ��ųʸ��� ����
        /// </summary>
        /// <param name="setKey"></param>
        public void SetKeyBinds(KeyCode setKey)
        {

        }

        /// <summary>
        /// ��ư�� ������ �� Input Manager���� ��ųʸ� ���� ��~ �̰� �����±���! �ϰ� ���� ���ش�.
        /// InputParameter�� ��� �޾ƾ��ϴ°ɱ�...?
        /// </summary>
        /// <param name="skillIndex">
        /// ��ư ID�� ���� 
        /// </param>
        public void ThrowSkill(int skillIndex)
        {
            if (AndBtnBind.ContainsKey(skillIndex))
            {
                Action<InputParameter> targetAction = SkillBindDict[AndBtnBind[skillIndex]];
                if (targetAction == null)
                {
                    Debug.Log($"���� ��ų {AndBtnBind[skillIndex]} ���ε��Ȱ� ���µ���");
                    return;
                }

                targetAction.Invoke(new InputParameter());
                //�ϴ� �ƹ��͵� �����ϱ� ������ �ִ´�.
                Debug.Log($"���� {targetAction} ��ų�̳� �Ծ��~");
            }
        }

        /// <summary>
        /// Ű���� Ű�� ������ �� Input Manager���� ��ųʸ� ���� ��~ �̰� �����±���! �ϰ� ���� ���ش�.
        /// </summary>
        /// <param name="keyCode">
        /// �Է��� Ű�ڵ带 ����
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
                        Debug.Log($"���� ��ų {keyCode}�� ���ε��Ȱ� ���µ���");
                        return;
                    }

                    targetAction.Invoke(new InputParameter());
                    Debug.Log($"���� {targetAction} ��ų�̳� �Ծ��~");
                }
            }            
        }
    }
}