using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Client
{
    public class KeySetPrefab : UI_Base
    {
        // 전체 Prefab에 대해서 상호작용 허가 / 불허
        public static bool                  _interactable = true;

        private InputManager.eInputSystem   _input = InputManager.eInputSystem.None;
        private KeyCode                     nowKey = KeyCode.None;

        enum Texts
        {
            BindSkillName,
            KeyCode,
        }

        enum Images
        {
            InputBindSpace,
        }

        public override void Init()
        {
            base.Init();
            Bind<TMP_Text>(typeof(Texts));
            Bind<Image>(typeof(Images));

            BindPanel();
            InputManager.Instance.BindAction -= SetBind;
            InputManager.Instance.BindAction += SetBind;
        }
        
        private void OnDestroy()
        {
            InputManager.Instance.BindAction -= SetBind;
        }

        public void SetBindInfo(InputManager.eInputSystem skillName, KeyCode keycode)
        {
            Debug.Log($"{skillName}, 자 이제 이 부분 채워보자~");
            _input = skillName;
            nowKey = keycode;

            GetText((int)Texts.BindSkillName).text = _input.ToString();
            GetText((int)Texts.KeyCode).text = nowKey.ToString();           
        }

        void BindPanel()
        {
            BindEvent(GetImage((int)Images.InputBindSpace).gameObject, OnClickPanel);
        }

        void OnClickPanel(PointerEventData evt)
        {
            Debug.Log("이 상호작용 빼고 건드릴 수 없는 상태가 되어야함. 버튼 눌림.");
            if (!_interactable) { return; }
            _interactable = false;

            StartCoroutine(nameof(WaitforInputChange));
        }

        /// <summary>
        /// 어떤 키 입력으로 바꾸고 싶은 지 입력 대기함.
        /// 키코드 감지할 방법이 이거뿐이라 비효율 감수해야 할 듯함.
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitforInputChange()
        {
            while(true)
            {
                if (Input.anyKeyDown)
                {
                    foreach(KeyCode key in Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            InputManager.Instance.SetKeyBinds(nowKey, key, _input);
                            _interactable = true;
                            
                            yield break;
                        }
                    }
                }
                yield return null;
            }
        }

        void SetBind()
        {
            if (!InputManager.Instance.CheckKeyValidity(nowKey))
            {
                KeyCode newKey = InputManager.Instance.SearchNewKeyCode(_input);
                SetBindInfo(_input, newKey);
            }
            else
            {
                if(!InputManager.Instance.CheckPrefabPairValidity(nowKey, _input))
                {
                    SetBindInfo(_input, KeyCode.None);
                }
            }
        }
    }
}