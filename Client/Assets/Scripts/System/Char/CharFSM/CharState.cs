using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Client
{

    public enum CharAction
    {
        Idle,
        Attack,
        Move,
        Execution,
        Hit,
        CC,
        Death,
    }

    public struct FSMParameter
    {
        //�ൿ Idle / Attack / Move / CC <- ������ �þ / Death 
        public CharAction charAction;
        public int priority;
        public Action<FSMParameter> actionFSMParameter;
        public Action action;
    }
    
    public struct CreateFSMParameter
    {
        public PlayerState PlayerState;
        public CharBase CharBase;
        public CharFSMInfo CharFSMInfo;

    }

    public static class FSMFactory
    {
        public static CharState CreateFSM(CreateFSMParameter parameter)
        {
            switch (parameter.PlayerState)
            {
                case PlayerState.IDLE:    return new CharIDLE(parameter);
                case PlayerState.MOVE:    return new CharMOVE(parameter);
                case PlayerState.ATTACK:  return new CharATTACK(parameter);
                case PlayerState.DAMAGED: return new CharDAMAGED(parameter);
                case PlayerState.DEBUFF:  return new CharDEBUFF(parameter);
                case PlayerState.DEATH:   return new CharDEATH(parameter);
            }
            return new CharIDLE(parameter);
        }


    }

    public abstract class CharState
    {
        public CharBase charBase { get; set; } // ĳ���� ����
        public CharFSMInfo charFSMInfo { get; set; } // ĳ���� FSMInfo 
        public CharState NextCharFSM { get; set; } // ���� State ����
        public bool IsAction { get; set; } = false; // ���� �ൿ��
        public CharState(CreateFSMParameter parameter) 
        {
            charBase = parameter.CharBase;
            charFSMInfo = parameter.CharFSMInfo;
        }
        
        public abstract PlayerState NowPlayerState();

        public abstract CharState CharAction(FSMParameter parameter);

        public virtual void ActionInvoke(FSMParameter parameter)
        {
            parameter.action?.Invoke();
            parameter.actionFSMParameter?.Invoke(parameter);
        }
        public virtual void AnimPlay(bool play = true)
        {
            if (play)
            { 
                charBase.PlayStateAnimation(NowPlayerState()); 
            }    
                
        }
    }
}