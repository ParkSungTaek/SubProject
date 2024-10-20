using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Client.SystemEnum;

namespace Client
{
    public class AttackCollider : MonoBehaviour
    {
        private eIsAttack IsAttack;
        // 스킬 캐스터 
        private CharBase _caster;
        // 스킬 데이터
        private SkillBase _skillBase;

        public CharBase Caster => _caster;
        private SkillBase SkillBase => _skillBase;
        public void SetData(CharBase caster, SkillBase skillBase)
        {
            _caster = caster;
            _skillBase = skillBase;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CharBase target = collision.GetComponent<CharBase>();
            if (target == null || _skillBase == null)
                return;

            DamageParameter damage = new DamageParameter(_caster, target, _skillBase, DamageType.NormalDamage);




        }

    }
}