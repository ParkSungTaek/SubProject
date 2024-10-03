using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class CharDEATH: CharState
    {
        public CharDEATH(CreateFSMParameter parameter) : base(parameter)
        { }

        public override CharState CharAction(FSMParameter parameter)
        {
            switch (parameter.charAction)
            {
                case Client.CharAction.Idle:
                case Client.CharAction.Attack:
                case Client.CharAction.Move:
                case Client.CharAction.Execution:
                case Client.CharAction.Hit:
                case Client.CharAction.CC:
                    {
                        return NextCharFSM;
                    }
                case Client.CharAction.Death:
                    {
                        return NextCharFSM;
                    }
            }
            Debug.LogError($"CharFSM Error {NowPlayerState()} No FSM Action : {parameter.charAction}");
            return charFSMInfo.CharNowState;
        }

        public override PlayerState NowPlayerState() => PlayerState.DEATH;

    }
}