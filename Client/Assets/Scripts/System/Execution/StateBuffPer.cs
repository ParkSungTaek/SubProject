using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class StateBuffPer : ExecutionBase
    {
        public StateBuffPer(BuffParameter buffParam) : base(buffParam)
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