using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Client
{
    public class KeySetPrefab : UI_Base
    {
        enum Texts
        {
            BindSkillName,
            KeyCode,
        }

        enum Images
        {
            ChangePanel,
        }

        public override void Init()
        {
            base.Init();
            Bind<TMP_Text>(typeof(Texts));
            Bind<Image>(typeof(Images));

            BindPanel();
        }

        public void SetBindInfo(string skillName, string KeyCode = null)
        {
            Debug.Log($"{skillName}, 자 이제 이 부분 채워보자~");
        }

        void BindPanel()
        {
            BindEvent(GetImage((int)Images.ChangePanel).gameObject, OnClickPanel);
        }

        void OnClickPanel(PointerEventData evt)
        {
            Debug.Log("이 상호작용 빼고 건드릴 수 없는 상태가 되어야함. 버튼 눌림.");
        }
    }
}