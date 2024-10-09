using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Client
{
    public class InputManager : Singleton<InputManager>
    {
        public readonly int SKILL_NUM = (int)eInputSystem.MaxValue;

        #region Singleton
        private InputManager()
        { }
        #endregion

        private Dictionary<eInputSystem, Tuple<KeyCode, int>> skillBindDict;


        /// <summary>
        /// Input system���� �Է°� ���ε��� ��ų�� �������� ��Ÿ���ϴ�.
        /// �� Input ���� enum ���� �ϵ��ϰ� ���Ҽ��� ���� ������?
        /// </summary>
        enum eInputSystem
        {
            Skill1,
            Skill2,
            Skill3,
            Skill4,
            MaxValue
        }

        public Action InputAction;

        public override void Init()
        {
            base.Init();
            GameManager.Instance.AddOnUpdate(OnUpdate);

            #region ��ǲ ��ųʸ� ���� �ϵ��ڵ�(�ʱ갪�� �����Ϳ��� ���� ���� �ȴٸ� �ݵ�� ������ ��.) 
            skillBindDict = new Dictionary<eInputSystem, Tuple<KeyCode, int>>();
            #endregion
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
        /// ����â���� Ű ������ �� �� Ű�ڵ带 �޾Ƽ� ��ųʸ��� ����
        /// </summary>
        /// <param name="setKey"></param>
        public void SetKeyBinds(KeyCode setKey)
        {

        }

    }
}