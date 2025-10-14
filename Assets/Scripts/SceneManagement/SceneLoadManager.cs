using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public static class SceneLoadManager
    {
        public static async void LoadScene(string sceneName, ISceneProgressHandler sceneProgressHandler)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            float reportedProgress = 0;
            while(!op.isDone)
            {
                if(op.progress != reportedProgress)
                {
                    reportedProgress = op.progress;
                    sceneProgressHandler.OnProgressChanged(reportedProgress);
                }

                await Task.Yield();
            }
            Scene scene = SceneManager.GetSceneByName(sceneName);
            Scene oldScene = SceneManager.GetActiveScene();
            await SceneManager.UnloadSceneAsync(oldScene);
            SceneManager.SetActiveScene(scene);
        }
    }
}