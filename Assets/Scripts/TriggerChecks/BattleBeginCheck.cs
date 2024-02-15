using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBeginCheck : MonoBehaviour
{
    [SerializeField] private Player player;
    private bool isBattle;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Enemy" && !isBattle)
        {
            BasicSkibidi currentTarget = target.gameObject.GetComponent<BasicSkibidi>();
            player.SetBattleStatus(true, currentTarget);
            isBattle = true;
        }
        else if(target.tag == "Enemy" && isBattle)
        {
            BasicSkibidi currentTarget = target.gameObject.GetComponent<BasicSkibidi>();
            player.AddEnemyToBattle(currentTarget);
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Enemy" && isBattle)
        {
            BasicSkibidi currentTarget = target.gameObject.GetComponent<BasicSkibidi>();
            player.SetBattleStatus(false, currentTarget);
            isBattle = false;
        }
    }
}
