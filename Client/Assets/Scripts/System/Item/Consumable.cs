using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class Consumable : ItemBase
    {
        public Consumable(ItemParameter param) : base(param)
        {

        }

        public override void UseItem()
        {
            base.UseItem();
            // 소비
            // 개수 -1 
        }
    }
}