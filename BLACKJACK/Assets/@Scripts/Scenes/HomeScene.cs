using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        Screen.orientation = ScreenOrientation.Portrait;
        SceneType = Define.Scene.HomeScene;
    }

    public override void Clear()
    {

    }
}

