using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HomeScene : UI_Base
{
    public Button NewGameButton;
    public Button ContinueButton;
    public Button RankingsAndChallengesButton;
    public Button SettingButton;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        NewGameButton = GameObject.Find("NewGameButton").GetComponent<Button>();
        ContinueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        RankingsAndChallengesButton = GameObject.Find("RankingsAndChallengesButton").GetComponent<Button>();
        SettingButton = GameObject.Find("SettingButton").GetComponent<Button>();
        
        NewGameButton.onClick.AddListener(OnClickNewGameButton);
    }

    public void OnClickNewGameButton()
    {
        Managers.Scene.LoadScene(Define.Scene.GameplayScene);
    }
}
