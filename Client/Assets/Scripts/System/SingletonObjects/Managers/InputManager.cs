using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

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
            skillBindDict = new Dictionary<eInputSystem, Tuple<KeyCode, int>>()
            {
                {eInputSystem.Skill1, new Tuple<KeyCode, int>(KeyCode.Q, 0)},
                {eInputSystem.Skill2, new Tuple<KeyCode, int>(KeyCode.W, 1)},
                {eInputSystem.Skill3, new Tuple<KeyCode, int>(KeyCode.E, 2)},
                {eInputSystem.Skill4, new Tuple<KeyCode, int>(KeyCode.R, 3)},
            };
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

        /// <summary>
        /// ��ư�� ������ �� Input Manager���� ��ųʸ� ���� ��~ �̰� �����±���! �ϰ� ���� ���ش�.
        /// [TODO : leejhee] Linq ���� ����Ʈ���� 0�̶�, ��ȿ���� �ʴ�. �ذ�����.
        /// </summary>
        /// <param name="skillIndex"></param>
        public void ThrowSkill(int skillIndex)
        {
            eInputSystem targetSkill = skillBindDict.FirstOrDefault(x => x.Value.Item2 == skillIndex).Key;
            if (skillBindDict.ContainsKey(targetSkill))
            {
                Debug.Log($"���� {targetSkill} ��ų�̳� �Ծ��~");
            }            
        }
    }
}