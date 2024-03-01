using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public List<CardDeck> CardDecks;    // player�� 5���� ī�嵦�� ������.
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
            // CardDecks �ε����� ���� ���� �߰��� ��. �̰��� �ӽ������� �׽�Ʈ��
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
