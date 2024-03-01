using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ChipCommand : ICommand
{
    private Chip _chip;
    private PlayerControllers _player;

    public ChipCommand(Chip chip)
    {
        _chip = chip;
        _player = Managers.Game.Player;
    }

    public void Execute()
    {
        _player.Bet(_chip);
    }
}
