using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Client.SystemEnum;

namespace Client
{
    // �⺻ ���� ���� ������ 
    public struct BuffParameter
    {
        public eExecutionType eExecutionType;
        public CharBase TargetChar;
        public CharBase CastChar;
        public long ExecutionIndex;
    }
}