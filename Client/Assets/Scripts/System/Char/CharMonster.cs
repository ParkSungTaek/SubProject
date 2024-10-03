using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class CharMonster : CharBase
    {
        protected override SystemEnum.eCharType CharType => SystemEnum.eCharType.Monster;
        protected override void CharInit()
        {
            CharManager.Instance.SetChar<CharMonster>(this);
        }
    }
}