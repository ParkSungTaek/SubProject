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
        // ��ü Prefab�� ���ؼ� ��ȣ�ۿ� �㰡 / ����
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
            Debug.Log($"{skillName}, �� ���� �� �κ� ä������~");
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
            Debug.Log("�� ��ȣ�ۿ� ���� �ǵ帱 �� ���� ���°� �Ǿ����. ��ư ����.");
            if (!_interactable) { return; }
            _interactable = false;

            StartCoroutine(nameof(WaitforInputChange));
        }

        /// <summary>
        /// � Ű �Է����� �ٲٰ� ���� �� �Է� �����.
        /// Ű�ڵ� ������ ����� �̰Ż��̶� ��ȿ�� �����ؾ� �� ����.
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