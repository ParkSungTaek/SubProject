using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class Equipment : ItemBase
    {
        enum eEquipType
        {
            None,
            Weapon,
            Head,
            Body,
            Gloves,
            Shoes
        }

        public Equipment(ItemParameter param) : base(param)
        {

        }

        private eEquipType equipType;

        public override void UseItem()
        {      
            // Âø¿ë
            _CharBase.CharItemInfo.EquipItem(_ItemData.index, this);
        }



    }
}