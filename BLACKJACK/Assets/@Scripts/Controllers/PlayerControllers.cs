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

    public void Bet(Chip chip)
    {
        if (chip == Chip.None)
        {
            Debug.Log("Clear");
            // CardDecks �ε����� ���� ���� �߰��� ��. �̰��� �ӽ������� �׽�Ʈ��
            //playerInfo.Gold += playerInfo.CardDecks[0].Bet * 1000;
            //playerInfo.CardDecks[0].Bet = 0;
            return;
        }

        Debug.Log("Bet");
        if (playerInfo.Gold >= (int)chip)
        {
            playerInfo.Gold -= (int)chip;
            // CardDecks �ε����� ���� ���� �߰��� ��. �̰��� �ӽ������� �׽�Ʈ��
            //playerInfo.CardDecks[0].Bet = (int)chip / 1000;
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
