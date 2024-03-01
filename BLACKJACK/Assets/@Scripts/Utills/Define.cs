using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum UIEvent
    {
        Click,
        Pressed,
    }

    public enum Scene
    {
        Unknown,
        HomeScene,
        GameplayScene,
    }

    public enum GameState
    {
        Ready,
        PlayerTurn,
        DealerTurn,
        Ended,
    }

    public enum Chip
    {
        None,
        Chip10 = 10000,
        Chip50 = 50000,
        Chip100 = 100000,
        Chip500 = 500000,
    }

    public enum CardSuit
    {
        Spade,
        Heart,
        Diamond,
        Clover,
    }
}
