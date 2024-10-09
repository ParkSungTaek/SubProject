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
        /// Input system에서 입력과 바인딩할 스킬의 종류들을 나타냅니다.
        /// 이 Input 관련 enum 또한 하드하게 안할수도 있지 않을까?
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

            #region 인풋 딕셔너리 관련 하드코딩(초깃값을 데이터에서 갖고 오게 된다면 반드시 삭제할 것.) 
            skillBindDict = new Dictionary<eInputSystem, Tuple<KeyCode, int>>();
            #endregion
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
        /// 설정창에서 키 세팅을 할 때 키코드를 받아서 딕셔너리를 편집
        /// </summary>
        /// <param name="setKey"></param>
        public void SetKeyBinds(KeyCode setKey)
        {

        }

    }
}