using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class BattleManager : Singleton<BattleManager>
    {
        #region 생성자
        BattleManager() { }
        #endregion

        /// <summary>
        /// 일반적 데미지 공식
        /// </summary>
        public void OnDamage(DamageParameter damage)
        {
            if (IsAvailable(damage) == false)
                return;

            switch (damage.DamageType)
            {
                case DamageType.NormalDamage:
                    NormalDamage(damage);
                    break;
                case DamageType.DotDamage:
                    // TODO 도트 데미지 공식
                    NormalDamage(damage);
                    break;
            }
        }

        private bool IsAvailable(DamageParameter damage)
        {
            if (damage.DamageType == DamageType.None || damage.DamageType == DamageType.MaxCount)
                return false;
            if (damage.Caster == null)
                return false;
            if (damage.Target == null)
                return false;
            if (damage.SkillBase == null)
                return false;

            return true;
        }

        private void NormalDamage(DamageParameter damage)
        { 
            
        }
    }
}