using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Client.SystemEnum;

namespace Client
{
    public struct ItemParameter
    {
        public long ItemIndex;
        public CharBase CharBase;
        public eItemType eItemType;
    }

    public abstract class ItemBase
    {
        protected CharItemData _ItemData = null;
        protected CharBase _CharBase = null;
        protected List<ExecutionBase> _Executions = null;
        protected long _ItemID;
        protected int _count;

        public ItemBase(ItemParameter param)
        {
            _ItemData = DataManager.Instance.GetData<CharItemData>(param.ItemIndex);
            _CharBase = param.CharBase;

            if (_ItemData == null)
            {
                Debug.LogError($"Execution : {param.ItemIndex} µ¥ÀÌÅÍ È¹µæ ½ÇÆÐ");
            }

            if(_ItemData.itemEffectExecutionList != null)
            {
                foreach (var effectIndex in _ItemData.itemEffectExecutionList)
                {
                    BuffParameter effectParam = new BuffParameter
                    {
                        eExecutionType = SystemEnum.eExecutionType.StateBuff,
                        TargetChar = _CharBase,
                        CastChar = _CharBase,
                        ExecutionIndex = effectIndex
                    };
                    _Executions.Add(ExecutionFactory.ExecutionGenerate(effectParam));
                }
            }
        }


        public virtual void UseItem()
        {
            if (_Executions != null)
            {
                foreach (var execution in _Executions)
                {
                    execution.RunExecution(true);
                }
            }
        }

        public void DiscardItem()
        {

        }
            

    }

    public class Equipment : ItemBase
    {
        public Equipment(ItemParameter param) : base(param)
        {

        }

        enum eEquipType
        {
            Weapon,
            Head,
            Body,
            Gloves,
            Shoes            
        }

        public override void UseItem()
        {
            // Âø¿ë
            // 
        }


    }


    public class Consumable : ItemBase
    {
        public Consumable(ItemParameter param) : base(param)
        {
            
        }

        public override void UseItem()
        {
            base.UseItem();
            // ¼Òºñ
            //  
        }
    }

    public class ETCItem : ItemBase
    {
        public ETCItem(ItemParameter param) : base(param)
        {

        }

        public override void UseItem()
        {
            //???
        }
    }

}