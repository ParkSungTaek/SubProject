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
        private Dictionary<long, SkillBase> _dicSkill = new Dictionary<long, SkillBase>(); // ��ų ����Ʈ
        private CharBase _charBase; // ��ų ������
        private Transform _SkillRoot; // ��ų ��Ʈ 

        public Dictionary<long, SkillBase> DicSkill => _dicSkill; // ��ų ����Ʈ
        public CharSKillInfo(CharBase charBase)
        {
            _charBase = charBase;
        }

        /// <summary>
        /// Char Start ����
        /// </summary>
        /// <param name="skillArray"></param>
        public void Init(List<long> skillArray)
        {
            // ��ų ��Ʈ ������Ʈ ����
            string SkillRoot = "SkillRoot";
            GameObject skillRoot = Util.FindChild(_charBase.gameObject, SkillRoot, false);
            if (skillRoot == null)
            {
                skillRoot = new GameObject(SkillRoot);
            }
            _SkillRoot = skillRoot.transform;

            // ��ų �߰�
            foreach (var skillIndex in skillArray)
            {
                AddSkill(skillIndex);
                //var _skillData = SkillCreator.CreateSkill(skillIndex);
                //if (_skillData)
                //    continue;
                //
                //_dicSkill.Add(skillIndex, _skillData);
            }
        }

        public void DeleteSkill(long skillIndex)
        {
            if (_dicSkill == null)
                return;

            if(_dicSkill.ContainsKey(skillIndex))
            {
                _dicSkill.Remove(skillIndex);
            }
        }
        public void AddSkill(long skillIndex)
        {
            if (_dicSkill == null)
                return;

            if (!_dicSkill.ContainsKey(skillIndex))
            {
                SkillBase skillBase = SkillCreator.CreateSkill(skillIndex);
                if (skillBase == null)
                    return;

                skillBase.SetCharBase(_charBase);
                _dicSkill.Add(skillIndex, skillBase);
                skillBase.transform.parent = _SkillRoot;
            }
        }
    }
}