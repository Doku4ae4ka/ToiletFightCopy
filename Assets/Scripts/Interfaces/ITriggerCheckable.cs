using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsChasing { get; set; }

    bool IsBattle { get; set; }

    void SetChasingStatus(bool isChasing, BasicSkibidi target);
    void SetBattleStatus(bool isBattle, BasicSkibidi target);
    void AddEnemyToBattle(BasicSkibidi target);
}
