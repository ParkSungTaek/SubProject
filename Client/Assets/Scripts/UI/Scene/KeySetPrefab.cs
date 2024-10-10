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
            Debug.Log($"{skillName}, �� ���� �� �κ� ä������~");
        }

        void BindPanel()
        {
            BindEvent(GetImage((int)Images.ChangePanel).gameObject, OnClickPanel);
        }

        void OnClickPanel(PointerEventData evt)
        {
            Debug.Log("�� ��ȣ�ۿ� ���� �ǵ帱 �� ���� ���°� �Ǿ����. ��ư ����.");
        }
    }
}