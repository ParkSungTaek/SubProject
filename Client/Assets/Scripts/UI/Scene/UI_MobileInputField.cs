using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

namespace Client
{
    public class UI_MobileInputField : UI_Scene
    {
        enum Buttons
        {
            SkillBtn1,
            SkillBtn2,
            SkillBtn3,
            SkillBtn4,
        }

        public override void Init()
        {
            base.Init();
            Bind<Button>(typeof(Buttons));

            BindButtons();
        }

        /// <summary>
        /// 눈 딱 감고 object 한번만 씁시다.
        /// </summary>
        void BindButtons()
        {
            int maxID = Enum.GetValues(typeof(Buttons)).Length;
            for (int id = 0; id < maxID; id++)
            {
                Button targetButton = GetButton(id);
                if (targetButton != null)
                {
                    int tempID = targetButton.GetOrAddComponent<SkillButton>().ButtonID;
                    tempID = id; // 클로저떄문에 이상하게 바인딩되는 사태 방지
                    BindEvent(targetButton.gameObject,
                        (PointerEventData e, object ID) => OnClickSkillButtons(e, tempID), tempID);
                }
            }
        }

        void OnClickSkillButtons(PointerEventData evt, object ID)
        {
            int id = (int)ID;
            InputManager.Instance.ThrowSkill(id);
        }
    }
}