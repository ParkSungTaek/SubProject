using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Client
{
    public class UI_InputTestScene : UI_Scene
    {
        enum Buttons
        {
            OpenButton,
        }

        public override void Init()
        {
            base.Init();
            Bind<Button>(typeof(Buttons));
            BindButton();
        }

        void BindButton()
        {
            BindEvent(GetButton((int)Buttons.OpenButton).gameObject, OnClickOpenButton);
        }

        void OnClickOpenButton(PointerEventData evt)
        {
            UIManager.Instance.ShowPopupUI<KeySettingPopup>();
        }
    }
}