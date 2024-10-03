using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Client
{
    public class CharProjectal : CharBase
    {
        protected override SystemEnum.eCharType CharType => SystemEnum.eCharType.Projectal;
        protected override void CharInit()
        {
            CharManager.Instance.SetChar<CharProjectal>(this);
        }
    }
}