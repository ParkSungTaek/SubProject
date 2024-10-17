using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Client
{

    /// <summary>
    /// 스킬 타임라인용 마커
    /// </summary>
    public class SkillMarker: Marker, INotificationReceiver
    {
        public void OnNotify(Playable origin, INotification notification, object context)
        {
            Debug.Log("HelloWorld!");
        }

        public override void OnInitialize(TrackAsset aPent)
        {
            base.OnInitialize(aPent);
            Debug.Log("HelloWorld!123123");
        }
    }

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