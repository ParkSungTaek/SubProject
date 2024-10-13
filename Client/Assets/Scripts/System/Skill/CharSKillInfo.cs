using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// 캐릭터 스킬 정보 (캐릭터 Start시점에 생성)
    /// </summary>
    public class CharSKillInfo
    {
        private List<SkillBase> _skillList = new List<SkillBase>(); // 스킬 리스트
        private CharBase _charBase; // 스킬 시전자

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