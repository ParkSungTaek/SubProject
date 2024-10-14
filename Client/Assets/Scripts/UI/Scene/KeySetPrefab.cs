using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Client
{
    public class KeySetPrefab : UI_Base
    {
        // 전체 Prefab에 대해서 상호작용 허가 / 불허
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

        //[TODO : leejhee] 이 부분부터 구현 필요
        void OnClickPanel(PointerEventData evt)
        {
            Debug.Log("이 상호작용 빼고 건드릴 수 없는 상태가 되어야함. 버튼 눌림.");
            if (!_interactable) { return; }
            _interactable = false;


        }
    }
}