using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;

namespace Client
{
    public class SkillBase : MonoBehaviour
    {
        private PlayableDirector playableDirector;

        private void Awake()
        {
            playableDirector = GetComponent<PlayableDirector>();
            if (playableDirector == null)
            {
                Debug.LogError($"{transform.name} PlayableDirector is Null");
            }
            //playableDirector.SetGenericBinding()
        }



    }
}