using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Client
{
    public class KeySetPrefab : UI_Base
    {
        // ��ü Prefab�� ���ؼ� ��ȣ�ۿ� �㰡 / ����
        public static bool _interactable = true;
        private InputManager.eInputSystem _input = InputManager.eInputSystem.None;
        private KeyCode nowKey;

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

        //[TODO : leejhee] �� �κк��� ���� �ʿ�
        void OnClickPanel(PointerEventData evt)
        {
            Debug.Log("�� ��ȣ�ۿ� ���� �ǵ帱 �� ���� ���°� �Ǿ����. ��ư ����.");
            if (!_interactable) { return; }
            _interactable = false;


        }
    }
}