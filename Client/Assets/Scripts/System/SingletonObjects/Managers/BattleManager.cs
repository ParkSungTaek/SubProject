using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class BattleManager : Singleton<BattleManager>
    {
        #region ������
        BattleManager() { }
        #endregion

        /// <summary>
        /// �Ϲ��� ������ ����
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
                    // TODO ��Ʈ ������ ����
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