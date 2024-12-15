using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using BehaviorDesigner.Runtime.Tasks;

namespace Client
{

    public class SkillTimeLine : MonoBehaviour, INotificationReceiver
    {
        Animator animator;
        private void Awake()
        {

        }

        public void OnNotify(Playable origin, INotification notification, object context)
        {
            SkillMarker Skill = notification as SkillMarker;
            Debug.Log("HelloWorld!asdfasdfasdf");
        }
    }

}