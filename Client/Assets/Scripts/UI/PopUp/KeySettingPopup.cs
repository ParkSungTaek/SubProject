using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Client
{
    public class KeySettingPopup : UI_Popup
    {
        enum GameObjects
        {
            VerticalPanel,
        }

        enum Buttons
        {
            CloseBtn,
        }
 
        public override void Init()
        {
            base.Init();
            Bind<GameObject>(typeof(GameObjects));
            Bind<Button>(typeof(Buttons));

            BindButton();
            ShowBindingSlots();
        }

        void BindButton()
        {
            BindEvent(GetButton((int)Buttons.CloseBtn).gameObject, OnClickCloseBtn);
        }

        void ShowBindingSlots()
        {
            GameObject verticalPanel = GetGameObject((int)GameObjects.VerticalPanel);
            foreach (Transform child in verticalPanel.transform)
                Destroy(child.gameObject);

            // [TODO: ljeehee] �� SKILL_NUM�� ���߿� �����Ϳ��� ������簡 �ϴ°� �°ڴ�.
            for (int i = 0; i < InputManager.Instance.SKILL_NUM; i++)
            {
                GameObject bindPrefab = ObjectManager.Instance.Instantiate(
                    "UI/Scene/KeySetPrefab", verticalPanel.transform);
                KeySetPrefab keySet = bindPrefab.GetComponent<KeySetPrefab>();
                // ������. ���߿� ������ ���ؼ� �޾ƿ����� �ؾ���.
                keySet.SetBindInfo($"{i}");
            }

        }

        void OnClickCloseBtn(PointerEventData evt)
        {
            UIManager.Instance.ClosePopupUI();
        }


    }
}