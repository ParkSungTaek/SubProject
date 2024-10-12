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
        /// 안드로이드 플랫폼에 있는 버튼들에 대해, 버튼마다의 스킬을 바인딩해준다.
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

        void OnClickSkillButtons(PointerEventData evt, int id)
        {
            InputManager.Instance.ThrowSkill(id);
        }
    }
}