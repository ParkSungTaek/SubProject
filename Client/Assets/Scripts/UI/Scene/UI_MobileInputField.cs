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
        /// �ȵ���̵� �÷����� �ִ� ��ư�鿡 ����, ��ư������ ��ų�� ���ε����ش�.
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
                    tempID = id; // Ŭ���������� �̻��ϰ� ���ε��Ǵ� ���� ����
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