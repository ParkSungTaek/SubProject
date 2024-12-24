using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Client.AnimationDefine;
using static Client.SystemEnum;
using static Client.InputManager;
using Client;
using UnityEngine.AI;

namespace Client
{
    public class CharAnim : MonoBehaviour
    {
        [SerializeField] protected AnimationClip[] _Idle;          // 네비 메쉬 에이전트
        [SerializeField] protected AnimationClip[] _Move;          // 네비 메쉬 에이전트
        [SerializeField] protected AnimationClip[] _Damage;          // 네비 메쉬 에이전트
        [SerializeField] protected AnimationClip[] _Death;          // 네비 메쉬 에이전트
        [SerializeField] protected AnimationClip[] _Other;          // 네비 메쉬 에이전트

    }
}