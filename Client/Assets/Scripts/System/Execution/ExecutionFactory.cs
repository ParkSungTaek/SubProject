using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Client.SystemEnum;

namespace Client
{
    public static class ExecutionFactory
    {
        public static ExecutionBase ExecutionGenerate(BuffParameter buffParam)
        {
            switch (buffParam.eExecutionType)
            {
                case eExecutionType.Avoidance: return new Avoidance(buffParam);
                case eExecutionType.StateBuff: return new StateBuff(buffParam);
                case eExecutionType.StateBuffPer: return new StateBuffPer(buffParam);
                case eExecutionType.StateBuffNPer: return new StateBuffNPer(buffParam);
                case eExecutionType.Parrying : return new Parrying(buffParam);
                case eExecutionType.DotDamage : return new DotDamage(buffParam);

            }

            return null;
        }

    }
}