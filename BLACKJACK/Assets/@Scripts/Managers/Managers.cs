using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }
    static bool s_init = false;

    #region Contents
    GameManager _game = new GameManager();
    CardManager _card = new CardManager();
    public static GameManager Game { get { return Instance?._game; } }
    public static CardManager Card { get { return Instance?._card; } }
    #endregion

    #region Core
    SceneManagerEX _scene = new SceneManagerEX();
    UIManager _ui = new UIManager();
    ResourceManager _resource = new ResourceManager();
    public static SceneManagerEX Scene { get { return Instance?._scene; } }
    public static UIManager UI { get { return Instance?._ui; } }
    public static ResourceManager Resource { get { return Instance?._resource; } }
    #endregion

    public static void Init()
    {
        if (!s_init)
        {
            s_init = true;

            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject() { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }

    public static void Clear()
    {
        UI.Clear();
        Scene.Clear();
    }
}
