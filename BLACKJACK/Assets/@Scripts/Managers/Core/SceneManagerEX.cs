using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        switch (CurrentScene.SceneType)
        {
            case Define.Scene.HomeScene:
                Managers.Clear();
                SceneManager.LoadScene(GetSceneName(type));
                break;
            case Define.Scene.GameplayScene:
                Managers.Clear();
                SceneManager.LoadScene(GetSceneName(type));
                break;
        }
    }

    string GetSceneName(Define.Scene type) 
    {
        // string name = type.ToString();
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
