using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public List<CardDeck> CardDecks;    // player은 5개의 카드덱을 가진다.
}

public class PlayerControllers
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
        Debug.Log(_currentCardDeckIdx);
        if (chip == Chip.None)
        {
            Debug.Log("Clear");
            PlayerInfo.Gold += PlayerInfo.CardDecks[_currentCardDeckIdx].Bet * 1000;
            PlayerInfo.CardDecks[_currentCardDeckIdx].Bet = 0;
            return;
        }

        Debug.Log("Bet");
        if (PlayerInfo.Gold >= (int)chip)
        {
            PlayerInfo.Gold -= (int)chip;
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

    public void Surrender()
    {

    }
}
