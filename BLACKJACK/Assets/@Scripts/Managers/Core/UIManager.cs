using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    UI_Scene _sceneUI = null;
    public UI_Scene SceneUI { get { return _sceneUI; } }

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
            {
                root = new GameObject() { name = "@UI_Root" };
            }
            return root;
        }
    }

    public void OpenPopupUI(GameObject go)
    {
        go.SetActive(true);
    }

    public void ClosePopupUI(GameObject go)
    {
        go.SetActive(false);
    }
}
