using Scenes;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingView : MonoBehaviour, ISceneProgressHandler
{
    private ProgressBar _progressBar;
    private void OnEnable()
    {
        _progressBar = GetComponent<UIDocument>().rootVisualElement.Q<ProgressBar>();
        _progressBar.lowValue = 0;
        _progressBar.highValue = 1;
    }

    public void OnProgressChanged(float progress)
    {
        _progressBar.value = progress;
    }
}
