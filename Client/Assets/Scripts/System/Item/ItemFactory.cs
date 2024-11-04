using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Client.SystemEnum;

namespace Client
{
    public static class ItemFactory
    {
        public static ItemBase ItemGenerate(ItemParameter itemParam)
        {
            switch (itemParam.itemData.itemType)
            {
                case eItemType.Equipment: return new Equipment(itemParam);
                case eItemType.Consumable: return new Consumable(itemParam);
                case eItemType.ETC: return new ETCItem(itemParam);
            }

            return null;
        }
    }
}