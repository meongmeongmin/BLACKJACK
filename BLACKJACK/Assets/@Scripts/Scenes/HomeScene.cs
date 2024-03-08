using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScene : BaseScene
{
    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneType = Define.Scene.HomeScene;
    }

    protected override void Clear()
    {

    }
}

