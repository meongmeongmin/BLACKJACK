using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_GameplayScene : UI_Scene
{
    #region enum
    enum GameObjects
    {
        SetBetting,
        SetPlaying,
    }

    enum Buttons
    {
        HomeButton,
        MenuButton,
        Chip10Button,
        Chip50Button,
        Chip100Button,
        Chip500Button,
        ClearChipButton,
        PlayButton,
        HitButton,
        StandButton,
        DoubledownButton,
        SplitButton,
        SurrenderButton,
    }

    enum Toggles
    {
        CardDeckToggle_1,
        CardDeckToggle_2,
        CardDeckToggle_3,
        CardDeckToggle_4,
        CardDeckToggle_5,
    }

    enum Texts
    {
        GoldText,
        BetText_1,
        BetText_2,
        BetText_3,
        BetText_4,
        BetText_5,
        ScoreText_1,
        ScoreText_2,
        ScoreText_3,
        ScoreText_4,
        ScoreText_5,
        DealerScoreText,
    }

    enum Images
    {
        SelectCardDeckIconImage_1,
        SelectCardDeckIconImage_2,
        SelectCardDeckIconImage_3,
        SelectCardDeckIconImage_4,
        SelectCardDeckIconImage_5,
    }
    #endregion

    private PlayController _play;

    public override bool Init()
    {
        if (!base.Init())
            return false;

        _play = new PlayController();
        _play.Init();

        #region 바인딩
        BindObejct(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindToggle(typeof(Toggles));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        BindEvent(GetButton((int)Buttons.HomeButton).gameObject, OnClickHomeButton);
        BindEvent(GetButton((int)Buttons.MenuButton).gameObject, OnClickMenuButton);
        // SetBetting의 버튼
        BindEvent(GetButton((int)Buttons.Chip10Button).gameObject, () => { OnClickChipButton(Chip.Chip10); });
        BindEvent(GetButton((int)Buttons.Chip50Button).gameObject, () => { OnClickChipButton(Chip.Chip50); });
        BindEvent(GetButton((int)Buttons.Chip100Button).gameObject, () => { OnClickChipButton(Chip.Chip100); });
        BindEvent(GetButton((int)Buttons.Chip500Button).gameObject, () => { OnClickChipButton(Chip.Chip500); });
        BindEvent(GetButton((int)Buttons.ClearChipButton).gameObject, () => { OnClickChipButton(Chip.None); });
        BindEvent(GetButton((int)Buttons.PlayButton).gameObject, OnClickPlayButton);
        // SetPlaying의 버튼
        BindEvent(GetButton((int)Buttons.HitButton).gameObject, OnClickHitButton);
        BindEvent(GetButton((int)Buttons.StandButton).gameObject, OnClickStandButton);
        BindEvent(GetButton((int)Buttons.DoubledownButton).gameObject, OnClickDoubledownButton);
        BindEvent(GetButton((int)Buttons.SplitButton).gameObject, OnClickSplitButton);
        BindEvent(GetButton((int)Buttons.SurrenderButton).gameObject, OnClickSurrenderButton);
        // 카드덱 토글
        BindEvent(GetToggle((int)Toggles.CardDeckToggle_1).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_1); });
        BindEvent(GetToggle((int)Toggles.CardDeckToggle_2).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_2); });
        BindEvent(GetToggle((int)Toggles.CardDeckToggle_3).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_3); });
        BindEvent(GetToggle((int)Toggles.CardDeckToggle_4).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_4); });
        BindEvent(GetToggle((int)Toggles.CardDeckToggle_5).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_5); });
        #endregion

        // 수정 필요, SelectCardDeckIconImage_1 애니메이션 활성화
        OnCardDeckToggleClick(Toggles.CardDeckToggle_1);
        SetBetting();
        Refresh();

        return true;
    }

    private void Refresh()
    {
        // 플레이어의 골드 정보 업데이트
        GetText((int)Texts.GoldText).text = _play.PlayerInfo.Gold.ToString();
        // 플레이어의 모든 카드 덱을 순회하며 각 덱의 배팅 금액과 점수를 업데이트
        for (int i = 0; i < _play.PlayerInfo.CardDecks.Count; i++) 
        {
            GetText((int)Texts.BetText_1 + i).text = _play.PlayerInfo.CardDecks[i].Bet.ToString();
            GetText((int)Texts.ScoreText_1 + i).text = _play.PlayerInfo.CardDecks[i].Score.ToString();
        }
        // Dealer 점수 업데이트
        GetText((int)Texts.DealerScoreText).text = _play.DealerInfo.Score.ToString();
        
        // 수정 필요, 배팅 상태일 때만 업데이트 하도록
        // 각 Chip 버튼의 활성 상태를 업데이트
        GetButton((int)Buttons.Chip10Button).interactable = _play.PlayerInfo.Gold >= (int)Chip.Chip10;
        GetButton((int)Buttons.Chip50Button).interactable = _play.PlayerInfo.Gold >= (int)Chip.Chip50;
        GetButton((int)Buttons.Chip100Button).interactable = _play.PlayerInfo.Gold >= (int)Chip.Chip100;
        GetButton((int)Buttons.Chip500Button).interactable = _play.PlayerInfo.Gold >= (int)Chip.Chip500;
        // Play 버튼의 활성 상태를 업데이트
        GetButton((int)Buttons.PlayButton).interactable = _play.PlayerInfo.TotalBet > 0;
    }

    private void SetBetting()
    {
        GetObejct((int)GameObjects.SetBetting).gameObject.SetActive(true);
        GetObejct((int)GameObjects.SetPlaying).gameObject.SetActive(false);
        for (int i = 0; i < _play.PlayerInfo.CardDecks.Count; i++)
        {
            GetText((int)Texts.ScoreText_1 + i).transform.parent.gameObject.SetActive(false);
        }
    }

    private void SetPlay()
    {
        GetObejct((int)GameObjects.SetBetting).SetActive(false);
        GetObejct((int)GameObjects.SetPlaying).gameObject.SetActive(true);

        // 플레이어의 모든 카드 덱을 순회
        bool firstBetDeckFound = false;
        for (int i = 0; i < _play.PlayerInfo.CardDecks.Count; i++)
        {
            // BetImage, ScoreImage의 활성화 상태 설정
            bool isBet = _play.PlayerInfo.CardDecks[i].Bet > 0;
            GetText((int)Texts.BetText_1 + i).transform.parent.gameObject.SetActive(isBet);
            GetText((int)Texts.ScoreText_1 + i).transform.parent.gameObject.SetActive(isBet);

            // 토글 활성화 상태 설정
            if (!firstBetDeckFound && isBet) 
            {
                firstBetDeckFound = true;
                OnCardDeckToggleClick(Toggles.CardDeckToggle_1 + i);
                GetToggle((int)Toggles.CardDeckToggle_1 + i).interactable = true;
                GetToggle((int)Toggles.CardDeckToggle_1 + i).isOn = true;
            }
            else
            {
                GetToggle((int)Toggles.CardDeckToggle_1 + i).interactable = false;
                GetToggle((int)Toggles.CardDeckToggle_1 + i).isOn = false;
            }
        }
    }

    #region 버튼 클릭 이벤트
    private void OnClickHomeButton()
    {
        Managers.Scene.LoadScene(Scene.HomeScene);
    }

    private void OnClickMenuButton()
    {
        Managers.UI.ShowPopupUI<UI_MenuPopup>();
    }

    private void OnClickChipButton(Chip chip)
    {
        switch (chip)
        {
            case Chip.None:
                _play.Bet(chip);
                break;
            case Chip.Chip10:
                _play.Bet(chip);
                break;
            case Chip.Chip50:
                _play.Bet(chip);
                break;
            case Chip.Chip100:
                _play.Bet(chip);
                break;
            case Chip.Chip500:
                _play.Bet(chip);
                break;
        }

        Refresh();
    }

    private void OnClickPlayButton()
    {
        if (_play.PlayerInfo.TotalBet > 0)
        {
            SetPlay();
            _play.Play();
        }

        Refresh();
    }

    private void OnClickHitButton()
    {
        _play.Hit();
    }

    private void OnClickStandButton()
    {
        _play.Stand();
    }

    private void OnClickDoubledownButton()
    {
        _play.DoubleDown();
    }

    private void OnClickSplitButton()
    {
        _play.Split();
    }

    private void OnClickSurrenderButton()
    {
        _play.Surrender();
    }
    #endregion

    #region 토글 클릭 이벤트
    private void OnCardDeckToggleClick(Toggles toggle)
    {
        switch (toggle)
        {
            case Toggles.CardDeckToggle_1:
                _play.SelectCardDeck(0);
                break;
            case Toggles.CardDeckToggle_2:
                _play.SelectCardDeck(1);
                break;
            case Toggles.CardDeckToggle_3:
                _play.SelectCardDeck(2);
                break;
            case Toggles.CardDeckToggle_4:
                _play.SelectCardDeck(3);
                break;
            case Toggles.CardDeckToggle_5:
                _play.SelectCardDeck(4);
                break;
        }
    }
    #endregion
}
