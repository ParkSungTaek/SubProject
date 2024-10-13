using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;

namespace Client
{
    /// <summary>
    /// 스킬용 플레이어블 에셋
    /// </summary>
    public class SkillTimeLinePlayableAsset : PlayableAsset
    {

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return new Playable();
        }
    }
}