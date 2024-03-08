using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScene : BaseScene
{
    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneType = Define.Scene.GameplayScene;
        Managers.UI.ShowSceneUI<UI_GameplayScene>();
    }

    protected override void Clear()
    {

    }
}
