using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UI_HomeScene : UI_Scene
{
    enum Buttons
    {
        NewGameButton,
        ContinueButton,
        RankingsAndChallengesButton,
        SettingButton,
    }

    bool isPreload = false;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));

        BindEvent(GetButton((int)Buttons.NewGameButton).gameObject, OnNewGameButtonClick);
        BindEvent(GetButton((int)Buttons.ContinueButton).gameObject, OnContinueButtonClick);
        BindEvent(GetButton((int)Buttons.RankingsAndChallengesButton).gameObject, OnRankingsAndChallengesButtonClick);
        BindEvent(GetButton((int)Buttons.SettingButton).gameObject, OnSettingButtonClick);
        
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            if (count == totalCount) 
            {
                isPreload = true;
            }
        });
    }

    private void OnNewGameButtonClick()
    {
        Managers.Scene.LoadScene(Scene.GameplayScene);
    }

    private void OnContinueButtonClick()
    {
        // 게임 데이터 불러오기
        Managers.Scene.LoadScene(Scene.GameplayScene);
    }

    private void OnRankingsAndChallengesButtonClick()
    {

    }

    private void OnSettingButtonClick() 
    {

    }
}
