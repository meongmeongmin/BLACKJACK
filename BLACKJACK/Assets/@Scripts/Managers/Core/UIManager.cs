using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 0;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>(); 

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

    T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        Managers.Resource.Instantiate($"{name}");

        return null;
    }

    public void ClosePopupUI(GameObject go)
    {
        go.SetActive(false);
    }
}
