using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Animations;

namespace Client
{
    public class AnimationPlayableAsset: SkillTimeLinePlayableAsset
    {
        [SerializeField]
        private AnimationClip animationClip;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            if (charBase == null)
            {
                SkillBase skill = owner.GetComponent<SkillBase>();
                if (skill == null)
                    return new();

                charBase = skill.CharPlayer;
            }

            var playableBehaviour = new AnimationPlayableBehaviour();
            playableBehaviour.animator = charBase.CharAnimInfo.Animator;
            playableBehaviour.animationClip = animationClip;
            var scriptPlayable = ScriptPlayable<AnimationPlayableBehaviour>.Create(graph, playableBehaviour);

            // AnimationClipPlayable ����
            var animationPlayable = AnimationClipPlayable.Create(graph, animationClip);

            // �÷��̺��� ����
            scriptPlayable.AddInput(animationPlayable, 0, 1);

            return scriptPlayable;
        }
    }
}