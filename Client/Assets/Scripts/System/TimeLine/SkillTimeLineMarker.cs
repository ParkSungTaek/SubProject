using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace Client
{
    /// <summary>
    /// ��ų Ÿ�Ӷ��ο� ��Ŀ
    /// </summary>
    public class SkillTimeLineMarker : Marker, INotificationReceiver
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
    
    

}