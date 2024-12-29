
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using Client;
using static Client.InputManager;

namespace Client
{
    public class UI_GameScene : UI_Scene
    {
        enum GameObjects
        {
            joystickBG,
            joystickHandle,
        }
        enum Buttons
        {
            AttackBtn,
            SkillBtn,
            ItemBtn,
        }
        enum Texts
        {
            MoneyTxt,
            ScoreTxt
        }

        public override void Init()
        {
            base.Init();
            Bind<GameObject>(typeof(GameObjects));
            Bind<Button>(typeof(Buttons));
            Bind<TMP_Text>(typeof(Texts));

            ButtonBind();
            JoystickBind();


        }



        #region Buttons
        void ButtonBind()
        {
            BindEvent(GetButton((int)Buttons.AttackBtn).gameObject, Btn_Attack);
        }
        private void Btn_Attack(PointerEventData data)
        {
            InputParameter parameter = new(); // TODO 마우스 키보드 등 정보
            GameManager.Instance.MyCharPlayer.CharSKillInfo.PlaySkill(eInputSystem.Skill1, parameter);
        }

        #endregion Buttons


        #region Joystick
        /// <summary>
        /// joystick handle 기본 위치
        /// </summary>
        Vector2 _joystickPivotPos;

        /// <summary>
        /// joystick 최대 이동 거리
        /// </summary>
        float _joystickLimit;
        /// <summary>
        /// joystick handle
        /// </summary>
        GameObject _joystickHandle;
        GameObject joystickBG;
        /// <summary>
        /// joystick 방향 벡터
        /// </summary>
        Vector2 _directionVector = Vector2.zero;

        void JoystickBind()
        {
            joystickBG = Get<GameObject>((int)GameObjects.joystickBG);
            _joystickHandle = Get<GameObject>((int)GameObjects.joystickHandle);

            //기본 위치와 최대 이동 거리 계산
            _joystickLimit = ((joystickBG.transform as RectTransform).rect.width - (_joystickHandle.transform as RectTransform).rect.width) / 2f;

            //이벤트 bind
            BindEvent(_joystickHandle, JoystickDrag, SystemEnum.eUIEvent.Drag);
            BindEvent(_joystickHandle, JoystickDragEnd, SystemEnum.eUIEvent.DragEnd);
        }

        /// <summary>
        /// 조이스틱 드래그 GameManager 의 JoystickDirection 으로 전달
        /// </summary>
        /// <param name="evt"></param>
        void JoystickDrag(PointerEventData evt)
        {
            _joystickPivotPos = joystickBG.transform.position;
            _directionVector = (evt.position - _joystickPivotPos).normalized;
            GameManager.Instance.JoystickDirection = _directionVector;
            _joystickHandle.transform.position = _joystickPivotPos + _directionVector * Mathf.Min((evt.position - _joystickPivotPos).magnitude, 50);

            // _directionVector 를 사용해서 

        }

        /// <summary>
        /// 조이스틱 드래그 종료
        /// </summary>
        /// <param name="evt"></param>
        void JoystickDragEnd(PointerEventData evt)
        {
            _directionVector = Vector2.zero;
            _joystickHandle.transform.position = _joystickPivotPos;
            GameManager.Instance.JoystickDirection = Vector2.zero;
            // Player.StopWalk() 라던가 
        }
        #endregion Joystick

    }
}