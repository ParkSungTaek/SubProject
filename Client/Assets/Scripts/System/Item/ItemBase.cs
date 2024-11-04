using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Client.SystemEnum;

namespace Client
{
    public struct ItemParameter
    {
        public CharItemData itemData;
        public CharBase CharBase;
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
            _ItemData = param.itemData;
            _CharBase = param.CharBase;

            if (_ItemData == null)
            {
                Debug.LogError($"Execution : ������ ȹ�� ����");
            }

            if (_ItemData.itemEffectExecutionList != null)
            {
                foreach (var effectIndex in _ItemData.itemEffectExecutionList)
                {
                    BuffParameter effectParam = new BuffParameter
                    {
                        eExecutionType = eExecutionType.StateBuff,
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

        /// <summary>
        /// �巡�� �� ��� �Ǵ� Ű�ٿ����� ȣ��
        /// </summary>
        public void DiscardItem()
        {
            if (_CharBase != null)
            {
                GameObject tempParent = new GameObject("ItemParent");
                tempParent.transform.position = _CharBase.transform.position;
                ItemPrefab item = ObjectManager.Instance.Instantiate<ItemPrefab>(_ItemData.itemPrefabName, tempParent.transform);
                item.SetItemWData(_ItemData);
            }          
        }
            

    }

   


    

    

}