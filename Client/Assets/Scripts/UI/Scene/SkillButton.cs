using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// 버튼 ID 부여용도의 클래스. 초기화 시 버튼들에 이 컴포넌트를 부착하는 식으로만 사용 예정.
    /// [TODO] 이렇게 밖으로 빼서 할 수밖에 없는지 다시 한번 생각해볼 것.
    /// </summary>
    public class SkillButton : MonoBehaviour
    {
        private int buttonID;
        public int ButtonID { get { return buttonID; } set { buttonID = value; } }
    }
}