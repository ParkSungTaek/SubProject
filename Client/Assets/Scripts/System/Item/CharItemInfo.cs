using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Client.SystemEnum;

namespace Client
{
    public class CharItemInfo
    {
        private Dictionary<long, ItemBase> _dicItem = new Dictionary<long, ItemBase>(); // 캐릭터가 가진 아이템
        private Dictionary<long, Equipment> _equiped = new Dictionary<long, Equipment>(); // 캐릭터가 장비한 아이템
       
        public Dictionary<long, ItemBase> DicItem => _dicItem;
        public Dictionary<long, Equipment> Equiped => _equiped;

        public void AddItem(long ItemIndex)
        {
            if (_dicItem == null) return;

            if (!_dicItem.ContainsKey(ItemIndex))
            {

            }
        }

        public void DeleteItem(long ItemIndex) 
        {
            if (_dicItem == null) return;

            if (_dicItem.ContainsKey(ItemIndex))
            {
                _dicItem.Remove(ItemIndex);
            }
        }

    }
}