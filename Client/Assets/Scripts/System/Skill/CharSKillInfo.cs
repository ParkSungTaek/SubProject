using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// ĳ���� ��ų ���� (ĳ���� Start������ ����)
    /// </summary>
    public class CharSKillInfo
    {
        private List<SkillBase> _skillList = new List<SkillBase>(); // ��ų ����Ʈ
        private CharBase _charBase; // ��ų ������

        public CharSKillInfo(CharBase charBase)
        {
            _charBase = charBase;
        }

        public void Init(List<long> skillArray)
        {
            foreach (var skillIndex in skillArray)
            {
                var _charData = DataManager.Instance.GetData<CharData>(skillIndex);
            }
        }
    }
}