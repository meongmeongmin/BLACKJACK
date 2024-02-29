using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public void OpenPopupUI(GameObject go)
    {
        go.SetActive(true);
    }

    public void ClosePopupUI(GameObject go)
    {
        go.SetActive(false);
    }
}
