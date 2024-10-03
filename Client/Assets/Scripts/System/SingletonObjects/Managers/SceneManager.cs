
namespace Client
{
    /// <summary>
    /// Scene Load 등
    /// </summary>
    public class SceneManager : Singleton<SceneManager>
    {
        private SceneManager() { }
        /// <summary> Enum으로 정의한 씬 전환 (동기)</summary>
        public static void LoadScene(SystemEnum.eScenes scene, bool cacheClear = false)
        {
            //ui popup 초기화
            UIManager.Instance.Clear();
            //ResourceManager 초기화
            if (cacheClear)
            {
                ObjectManager.Instance.Clear();
                AudioManager.Instance.Clear();
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        }
    }
}