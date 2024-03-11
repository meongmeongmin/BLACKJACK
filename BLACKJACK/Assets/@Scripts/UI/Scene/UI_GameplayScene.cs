using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        ScoreImage_1,
        ScoreImage_2,
        ScoreImage_3,
        ScoreImage_4,
        ScoreImage_5,
    }
    #endregion

    private PlayerController _player;
    private DealerInfo _dealer;

    private void Start()
    {
        Debug.Log($"Test: {MethodBase.GetCurrentMethod().Name}");
        Init();
        Refresh();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _player = new PlayerController();
        _dealer = new DealerInfo();
        _player.Init();

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

        // 수정 필요, 아무것도 선택을 안 했을 때(처음 화면), 0번째 인덱스 카드덱을 자동으로 선택하고 SelectCardDeckIconImage_1 애니메이션을 활성화
        _player.SelectCardDeck(0);
        GetObejct((int)GameObjects.SetBetting).gameObject.SetActive(true);
        GetObejct((int)GameObjects.SetPlaying).gameObject.SetActive(false);
        GetImage((int)Images.ScoreImage_1).gameObject.SetActive(false);
        GetImage((int)Images.ScoreImage_2).gameObject.SetActive(false);
        GetImage((int)Images.ScoreImage_3).gameObject.SetActive(false);
        GetImage((int)Images.ScoreImage_4).gameObject.SetActive(false);
        GetImage((int)Images.ScoreImage_5).gameObject.SetActive(false);

        return true;
    }

    private void Refresh()
    {
        // 골드 텍스트
        GetText((int)Texts.GoldText).text = _player.PlayerInfo.Gold.ToString();
        // 배팅 텍스트
        GetText((int)Texts.BetText_1).text = _player.PlayerInfo.CardDecks[0].Bet.ToString();
        GetText((int)Texts.BetText_2).text = _player.PlayerInfo.CardDecks[1].Bet.ToString();
        GetText((int)Texts.BetText_3).text = _player.PlayerInfo.CardDecks[2].Bet.ToString();
        GetText((int)Texts.BetText_4).text = _player.PlayerInfo.CardDecks[3].Bet.ToString();
        GetText((int)Texts.BetText_5).text = _player.PlayerInfo.CardDecks[4].Bet.ToString();
        // 점수 텍스트
        GetText((int)Texts.ScoreText_1).text = _player.PlayerInfo.CardDecks[0].Score.ToString();
        GetText((int)Texts.ScoreText_2).text = _player.PlayerInfo.CardDecks[1].Score.ToString();
        GetText((int)Texts.ScoreText_3).text = _player.PlayerInfo.CardDecks[2].Score.ToString();
        GetText((int)Texts.ScoreText_4).text = _player.PlayerInfo.CardDecks[3].Score.ToString();
        GetText((int)Texts.ScoreText_5).text = _player.PlayerInfo.CardDecks[4].Score.ToString();
        GetText((int)Texts.DealerScoreText).text = _dealer.Score.ToString();
        // Chip 버튼
        GetButton((int)Buttons.Chip10Button).interactable = _player.PlayerInfo.Gold >= (int)Chip.Chip10;
        GetButton((int)Buttons.Chip50Button).interactable = _player.PlayerInfo.Gold >= (int)Chip.Chip50;
        GetButton((int)Buttons.Chip100Button).interactable = _player.PlayerInfo.Gold >= (int)Chip.Chip100;
        GetButton((int)Buttons.Chip500Button).interactable = _player.PlayerInfo.Gold >= (int)Chip.Chip500;
        // Play 버튼
        GetButton((int)Buttons.PlayButton).interactable = _player.PlayerInfo.TotalBet > 0;
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
                _player.Bet(chip);
                break;
            case Chip.Chip10:
                _player.Bet(chip);
                break;
            case Chip.Chip50:
                _player.Bet(chip);
                break;
            case Chip.Chip100:
                _player.Bet(chip);
                break;
            case Chip.Chip500:
                _player.Bet(chip);
                break;
        }

        Refresh();
    }

    private void OnClickPlayButton()
    {
        if (_player.PlayerInfo.TotalBet > 0)
        {
            GetObejct((int)GameObjects.SetBetting).SetActive(false);
            GetObejct((int)GameObjects.SetPlaying).gameObject.SetActive(true);
            GetImage((int)Images.ScoreImage_1).gameObject.SetActive(true);
            GetImage((int)Images.ScoreImage_2).gameObject.SetActive(true);
            GetImage((int)Images.ScoreImage_3).gameObject.SetActive(true);
            GetImage((int)Images.ScoreImage_4).gameObject.SetActive(true);
            GetImage((int)Images.ScoreImage_5).gameObject.SetActive(true);
        }
    }

    private void OnClickHitButton()
    {
        _player.Hit();
    }

    private void OnClickStandButton()
    {
        _player.Stand();
    }

    private void OnClickDoubledownButton()
    {
        _player.DoubleDown();
    }

    private void OnClickSplitButton()
    {
        _player.Split();
    }

    private void OnClickSurrenderButton()
    {
        _player.Surrender();
    }
    #endregion

    #region 토글 클릭 이벤트
    private void OnCardDeckToggleClick(Toggles toggle)
    {
        switch (toggle)
        {
            case Toggles.CardDeckToggle_1:
                _player.SelectCardDeck(0);
                break;
            case Toggles.CardDeckToggle_2:
                _player.SelectCardDeck(1);
                break;
            case Toggles.CardDeckToggle_3:
                _player.SelectCardDeck(2);
                break;
            case Toggles.CardDeckToggle_4:
                _player.SelectCardDeck(3);
                break;
            case Toggles.CardDeckToggle_5:
                _player.SelectCardDeck(4);
                break;
        }
    }
    #endregion
}
