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
        [SerializeField] protected AnimationClip[] _Idle;          // �׺� �޽� ������Ʈ
        [SerializeField] protected AnimationClip[] _Move;          // �׺� �޽� ������Ʈ
        [SerializeField] protected AnimationClip[] _Damage;          // �׺� �޽� ������Ʈ
        [SerializeField] protected AnimationClip[] _Death;          // �׺� �޽� ������Ʈ
        [SerializeField] protected AnimationClip[] _Other;          // �׺� �޽� ������Ʈ

    }
}