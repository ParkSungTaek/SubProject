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
        public static KeySetPrefab[]        keySets = new KeySetPrefab[InputManager.Instance.SKILL_NUM];

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
        }
        
        private void OnDestroy()
        {
            keySets[(int)_input - 1] = null;
        }

        public void SetBindInfo(InputManager.eInputSystem skillName, KeyCode keycode)
        {
            Debug.Log($"{skillName}, �� ���� �� �κ� ä������~");
            _input = skillName;
            nowKey = keycode;

            GetText((int)Texts.BindSkillName).text = _input.ToString();
            GetText((int)Texts.KeyCode).text = nowKey.ToString();           
        }

        /// <summary>
        /// �ܺο��� ����â�� ������ �ؽ�Ʈ�� �������ֱ� ���� �뵵. 
        /// ��ų �̸��� �����̹Ƿ�, ���� �Ұ��ϰ� ������.
        /// </summary>
        /// <param name="idx">KeySetPrefab �迭�� ���ٿ� �ε���</param>
        /// <param name="keycode">���ε��� ���ο� Ű</param>
        public static void SetBindFromOutside(int idx, KeyCode keycode)
        {
            if (!(keySets[idx] == null))
                keySets[idx].SetBindInfo(keySets[idx]._input, keycode);
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
    }
}