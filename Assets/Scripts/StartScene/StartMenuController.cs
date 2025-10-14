using Scenes;
using UnityEngine;
using UnityEngine.UIElements;

namespace StartScene
{
    public class StartMenuController : MonoBehaviour
    {
        [SerializeField] private LoadingView _loadingView;

        private Button _startButton;
        private Button _quitButton;

        private void OnEnable()
        {
            _startButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("StartButton");
            _quitButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("QuitButton");
            _startButton.clicked += StartGame;
            _quitButton.clicked += QuitGame;
        }

        private void OnDisable()
        {
            _startButton.clicked -= StartGame;
            _quitButton.clicked -= QuitGame;
        }

        public void StartGame()
        {
            _loadingView.gameObject.SetActive(true);
            SceneLoadManager.LoadScene("Game", _loadingView);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
#else
            Application.Quit();
#endif
        }
    }
}
