using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;

namespace Client
{
    /// <summary>
    /// ��ų�� �÷��̾�� ����
    /// </summary>
    public class SkillTimeLinePlayableAsset : PlayableAsset
    {

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return new Playable();
        }
    }
}