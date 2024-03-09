using System.Collections;
using System.Collections.Generic;
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

    private PlayerControllers _player;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        _player = new PlayerControllers();
        _player.Init();

        #region 바인딩
        BindObejct(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindToggle(typeof(Toggles));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        BindEvent(Get<Button>((int)Buttons.HomeButton).gameObject, OnHomeButtonClick);
        BindEvent(Get<Button>((int)Buttons.MenuButton).gameObject, OnMenuButtonClick);
        // SetBetting의 버튼
        BindEvent(Get<Button>((int)Buttons.Chip10Button).gameObject, () => { OnChipButtonClick(Chip.Chip10); });
        BindEvent(Get<Button>((int)Buttons.Chip50Button).gameObject, () => { OnChipButtonClick(Chip.Chip50); });
        BindEvent(Get<Button>((int)Buttons.Chip100Button).gameObject, () => { OnChipButtonClick(Chip.Chip100); });
        BindEvent(Get<Button>((int)Buttons.Chip500Button).gameObject, () => { OnChipButtonClick(Chip.Chip500); });
        BindEvent(Get<Button>((int)Buttons.ClearChipButton).gameObject, () => { OnChipButtonClick(Chip.None); });
        BindEvent(Get<Button>((int)Buttons.PlayButton).gameObject, OnPlayButtonClick);
        // 카드덱 토글
        BindEvent(Get<Toggle>((int)Toggles.CardDeckToggle_1).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_1); });
        BindEvent(Get<Toggle>((int)Toggles.CardDeckToggle_2).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_2); });
        BindEvent(Get<Toggle>((int)Toggles.CardDeckToggle_3).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_3); });
        BindEvent(Get<Toggle>((int)Toggles.CardDeckToggle_4).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_4); });
        BindEvent(Get<Toggle>((int)Toggles.CardDeckToggle_5).gameObject, () => { OnCardDeckToggleClick(Toggles.CardDeckToggle_5); });
        #endregion

        // 수정 필요, 아무것도 선택을 안 했을 때(처음 화면), 0번째 인덱스 카드덱을 자동으로 선택하고 SelectCardDeckIconImage_1 애니메이션을 활성화
        _player.SelectCardDeck(0);

        Refresh();
    }

    private void Refresh()
    {
        GetText((int)Texts.GoldText).text = _player.PlayerInfo.Gold.ToString();
        GetText((int)Texts.BetText_1).text = _player.PlayerInfo.CardDecks[0].Bet.ToString();
        GetText((int)Texts.BetText_2).text = _player.PlayerInfo.CardDecks[1].Bet.ToString();
        GetText((int)Texts.BetText_3).text = _player.PlayerInfo.CardDecks[2].Bet.ToString();
        GetText((int)Texts.BetText_4).text = _player.PlayerInfo.CardDecks[3].Bet.ToString();
        GetText((int)Texts.BetText_5).text = _player.PlayerInfo.CardDecks[4].Bet.ToString();
    }

    #region 버튼 클릭 이벤트
    private void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Scene.HomeScene);
    }

    private void OnMenuButtonClick()
    {
        Managers.UI.ShowPopupUI<UI_MenuPopup>();
    }

    private void OnChipButtonClick(Chip chip)
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

    private void OnPlayButtonClick()
    {
        GetObejct((int)GameObjects.SetBetting).SetActive(false);
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
