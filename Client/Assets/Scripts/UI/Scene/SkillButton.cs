using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// ��ư ID �ο��뵵�� Ŭ����. �ʱ�ȭ �� ��ư�鿡 �� ������Ʈ�� �����ϴ� �����θ� ��� ����.
    /// [TODO] �̷��� ������ ���� �� ���ۿ� ������ �ٽ� �ѹ� �����غ� ��.
    /// </summary>
    public class SkillButton : MonoBehaviour
    {
        private int buttonID;
        public int ButtonID { get { return buttonID; } set { buttonID = value; } }
    }
}