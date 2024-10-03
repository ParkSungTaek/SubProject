using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Client.SystemEnum;

namespace Client
{
    public class ExecutionInfo
    {
        private Dictionary<eExecutionGroupType, List<ExecutionBase>> _executionBaseDic = new Dictionary<eExecutionGroupType, List<ExecutionBase>>(); // ±â´É 
        public Dictionary<eExecutionGroupType, List<ExecutionBase>> ExecutionBaseDic => _executionBaseDic;

        public void Init()
        {
            for (eExecutionGroupType i = 0; i < eExecutionGroupType.MaxCount; i++)
            {
                _executionBaseDic[i] = new List<ExecutionBase>();
            }
        }
        
    }
}