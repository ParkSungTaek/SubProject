using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Client
{
    public class KeySettingPopup : UI_Popup
    {
        enum GameObjects
        {
            PanelContents,
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

        /// <summary>
        /// 키 세팅용 팝업을 열었을 때, 스킬마다의 키 바인딩 정보를 보여준다.
        /// </summary>
        void ShowBindingSlots()
        {
            GameObject verticalPanel = GetGameObject((int)GameObjects.PanelContents);
            foreach (Transform child in verticalPanel.transform)
                Destroy(child.gameObject);
           
            var DirectKeyDict = InputManager.Instance.GetAllKeyBinds();
            foreach (var directPair in DirectKeyDict)
            {
                GameObject bindPrefab = ObjectManager.Instance.Instantiate(
                    "UI/Scene/KeySetPrefab", verticalPanel.transform);
                KeySetPrefab keySet = bindPrefab.GetComponent<KeySetPrefab>();
                keySet.SetBindInfo(directPair.Value, directPair.Key);
            }
        }

        #region Binding Button
        void BindButton()
        {
            BindEvent(GetButton((int)Buttons.CloseBtn).gameObject, OnClickCloseBtn);
        }

        void OnClickCloseBtn(PointerEventData evt)
        {
            UIManager.Instance.ClosePopupUI();
            KeySetPrefab._interactable = true;
        }
        #endregion

    }
}