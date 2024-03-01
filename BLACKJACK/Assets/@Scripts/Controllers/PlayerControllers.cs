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
    public PlayerInfo playerInfo = new PlayerInfo();

    public void SelectCardDeck()
    {

    }

    public void Bet(Chip chip)
    {
        Debug.Log("Bet");
        int chipValue = (int)chip;
        if (playerInfo.Gold >= chipValue)
        {
            playerInfo.Gold -= chipValue;
            // CardDecks 인덱스에 대한 로직 추가할 것. 이것은 임시적으로 테스트용
            playerInfo.CardDecks[0].Bet = chipValue/1000;
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
