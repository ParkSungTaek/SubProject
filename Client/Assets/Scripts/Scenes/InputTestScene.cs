using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class InputTestScene : MonoBehaviour
    {
        private void Awake()
        {
            GameManager instance = GameManager.Instance;
        }

        private void Start()
        {
            UIManager.Instance.ShowSceneUI<UI_InputTestScene>();
        }
    }
}