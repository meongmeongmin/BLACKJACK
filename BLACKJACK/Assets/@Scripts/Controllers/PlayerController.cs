using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public float TotalBet;  // ������ �� �ݾ�
    public List<CardDeck> CardDecks;    // player�� 5���� ī�嵦�� ������.
}

[Serializable]
public class DealerInfo
{
    public List<Card> Cards;
    public int Score;
}

public class PlayerController
{
    public PlayerInfo PlayerInfo = new PlayerInfo();
    private int _currentCardDeckIdx;

    public void Init()
    {
        PlayerInfo.Gold = 100000;
        PlayerInfo.CardDecks = new List<CardDeck>();
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
    }

    public void SelectCardDeck(int cardDeckIdx)
    {
        _currentCardDeckIdx = cardDeckIdx;
    }

    public void Bet(Chip chip)
    {
        if (chip == Chip.None)
        {
            Debug.Log("Clear");
            PlayerInfo.Gold += PlayerInfo.CardDecks[_currentCardDeckIdx].Bet * 1000;
            PlayerInfo.TotalBet -= PlayerInfo.CardDecks[_currentCardDeckIdx].Bet;
            PlayerInfo.CardDecks[_currentCardDeckIdx].Bet = 0;
            return;
        }

        if (PlayerInfo.Gold >= (int)chip)
        {
            Debug.Log("Bet");
            PlayerInfo.Gold -= (int)chip;
            PlayerInfo.TotalBet += (int)chip / 1000;
            PlayerInfo.CardDecks[_currentCardDeckIdx].Bet += (int)chip / 1000;
        }
    }

    public void Hit()
    {

    }

    public void Stand()
    {

    }

    public void DoubleDown()
    {

    }

    public void Split() 
    {

    }

    public void Surrender()
    {

    }
}
