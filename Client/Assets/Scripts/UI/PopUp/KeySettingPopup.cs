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

            // [TODO: ljeehee] 이 SKILL_NUM은 나중에 데이터에서 끌어오든가 하는게 맞겠다.
            for (int i = 0; i < InputManager.Instance.SKILL_NUM; i++)
            {
                GameObject bindPrefab = ObjectManager.Instance.Instantiate(
                    "UI/Scene/KeySetPrefab", verticalPanel.transform);
                KeySetPrefab keySet = bindPrefab.GetComponent<KeySetPrefab>();
                // 모의임. 나중에 데이터 통해서 받아오도록 해야함.
                keySet.SetBindInfo($"{i}");
            }

        }

        void OnClickCloseBtn(PointerEventData evt)
        {
            UIManager.Instance.ClosePopupUI();
        }


    }
}