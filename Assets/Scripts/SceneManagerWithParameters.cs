using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Globals;

public static class SceneManagerWithParameters {

    private static Dictionary<string, string> parameters;
 
    public static string GetActiveSceneName() {
        return SceneManager.GetActiveScene().name;
    }

    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void Load(string sceneName, string paramKey, string paramValue)
    {
        SetParam(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public static void Load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void Load(int sceneIndex, string paramKey, string paramValue)
    {
        SetParam(paramKey, paramValue);
        SceneManager.LoadScene(sceneIndex);
    }

    public static Dictionary<string, string> GetSceneParameters()
    {
        return parameters;
    }

    public static string GetParam(string paramKey)
    {
        if (parameters == null || !parameters.ContainsKey(paramKey)) {
            return "NONE";
        }
        return parameters[paramKey];
    }

    public static void SetParam(string paramKey, string paramValue)
    {
        if (parameters == null) {
            parameters = new Dictionary<string, string>();
        }
        if (parameters.ContainsKey(paramKey)) {
            parameters.Remove(paramKey);
        }
        parameters.Add(paramKey, paramValue);
    }
}
