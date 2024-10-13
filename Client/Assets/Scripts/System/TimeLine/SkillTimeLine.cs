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
    public class NewSkillTimeLine: Marker, INotificationReceiver
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
        public void OnNotify(Playable origin, INotification notification, object context)
        {
            NewSkillTimeLine Skill = notification as NewSkillTimeLine;
            Debug.Log("HelloWorld!asdfasdfasdf");
        }
    }
}