using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// �⺻ ������Ʈ ���� ����
    /// </summary>
    public class StateBuff : ExecutionBase
    {
        public StateBuff(BuffParameter buffParam) : base(buffParam)
        {
        }

        public override void RunExecution(bool StartExecution)
        {
            base.RunExecution(StartExecution);
            if (StartExecution)
            {
            }
            else
            {
            }
        }
    }
}