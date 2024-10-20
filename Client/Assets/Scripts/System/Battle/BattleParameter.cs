using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public enum DamageType
    { 
        None,
        NormalDamage,
        DotDamage,
        MaxCount

    }

    public struct DamageParameter
    {
        public DamageType DamageType;
        public CharBase Caster;
        public CharBase Target;
        public SkillBase SkillBase;

        public DamageParameter
        (
            CharBase caster,
            CharBase target,
            SkillBase skillBase,
            DamageType damageType = DamageType.NormalDamage
        )
        {
            DamageType = damageType;
            Caster = caster;
            Target = target;
            SkillBase = skillBase;
        }


    }


}