using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UI_GameplayScene : UI_Base
{
    // ��ư
    public Button HomeButton;
    public Button MenuButton;
    public Button Chip10Button;
    public Button Chip50Button;
    public Button Chip100Button;
    public Button Chip500Button;
    public Button ClearChipButton;
    public Button PlayButton;
    public List<Button> CardDeckButton;
    // �ؽ�Ʈ
    public TextMeshPro GoldText;
    // ���� ������Ʈ
    public GameObject SetBetting;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        // �ʹ� �ϵ��ڵ��ؼ� ����ȭ�ϰ� ����.
        #region ����Ƽ �����Ϳ��� ����
        // ��� �޴�
        HomeButton = GameObject.Find("HomeButton").GetComponent<Button>();
        MenuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        // CardDeck
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_1").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_2").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_3").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_4").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_5").GetComponentInChildren<Button>());
        // Gold
        GoldText = GameObject.Find("GoldText").GetComponent<TextMeshPro>();
        // Set Betting
        SetBetting = GameObject.Find("SetrBetting");   // ���߿� UIManager�� ������ ��.
        // Chip
        Chip10Button = GameObject.Find("Chip10Button").GetComponent<Button>();
        Chip50Button = GameObject.Find("Chip50Button").GetComponent<Button>();
        Chip100Button = GameObject.Find("Chip100Button").GetComponent<Button>();
        Chip500Button = GameObject.Find("Chip500Button").GetComponent<Button>();
        Chip500Button = GameObject.Find("Chip500Button").GetComponent<Button>();
        ClearChipButton = GameObject.Find("ClearChipButton").GetComponent<Button>();
        // Play
        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
        #endregion

        // Ŀ�ǵ� ����
        var chip10Command = new ChipCommand(Chip.Chip10);
        var chip50Command = new ChipCommand(Chip.Chip50);
        var chip100Command = new ChipCommand(Chip.Chip100);
        var chip500Command = new ChipCommand(Chip.Chip500);

        // ��ư Ŭ�� ������ ���
        Chip10Button?.onClick.AddListener(chip10Command.Execute);
        Chip50Button?.onClick.AddListener(chip50Command.Execute);
        Chip100Button?.onClick.AddListener(chip100Command.Execute);
        Chip500Button?.onClick.AddListener(chip500Command.Execute);
        HomeButton?.onClick.AddListener(OnHomeButtonClick);
    }

    public void UpdateGoldText(float text)
    {
        GoldText.text = text.ToString();
    }

    public void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Define.Scene.HomeScene);
    }
}
