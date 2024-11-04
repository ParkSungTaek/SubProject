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
        private CharBase _charBase;

        public Dictionary<long, ItemBase> DicItem => _dicItem;
        public Dictionary<long, Equipment> Equiped => _equiped;

        public CharItemInfo(CharBase charBase)
        {
            _charBase = charBase;
        }

        public void AddItem(long ItemIndex)
        {
            if (_dicItem == null) return;

            if (!_dicItem.ContainsKey(ItemIndex))
            {
                CharItemData itemData = DataManager.Instance.GetData<CharItemData>(ItemIndex);
                ItemParameter param = new ItemParameter { itemData = itemData, CharBase = _charBase };
                ItemBase item = ItemFactory.ItemGenerate(param);
                _dicItem.Add(ItemIndex, item);
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

        public void EquipItem(long ItemIndex, Equipment equipment)
        {
            if (_equiped == null || _dicItem == null || !_dicItem.ContainsKey(ItemIndex)) return;
            _equiped.Add(ItemIndex, equipment);
            _dicItem.Remove(ItemIndex);
        }


        public void UnEquipItem(long ItemIndex, Equipment equipment)
        {
            if (_equiped == null || _dicItem == null) return;
            _equiped.Remove(ItemIndex);
            _dicItem.Add(ItemIndex, equipment);
        }
    }
}