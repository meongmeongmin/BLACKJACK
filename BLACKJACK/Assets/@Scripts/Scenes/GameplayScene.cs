using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneType = Define.Scene.GameplayScene;
        Managers.UI.ShowSceneUI<UI_GameplayScene>();
    }

    public override void Clear()
    {

    }
}
