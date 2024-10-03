using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class DotDamage : ExecutionBase
    {
        public DotDamage(BuffParameter buffParam) : base(buffParam)
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