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
        Chip10 = 10,
        Chip50 = 50,
        Chip100 = 100,
        Chip500 = 500,
    }

    public enum CardType
    {
        Spade,
        Heart,
        Diamond,
        Clover,
    }
}
