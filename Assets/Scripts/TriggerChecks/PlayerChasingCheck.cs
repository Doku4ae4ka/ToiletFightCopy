using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChasingCheck : MonoBehaviour
{
    [SerializeField] private Player player;
    private bool isChasing;

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Enemy" && !isChasing)
        {
            BasicSkibidi currentTarget = target.gameObject.GetComponent<BasicSkibidi>();
            player.SetChasingStatus(true, currentTarget);
            isChasing = true;
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Enemy" && isChasing)
        {
            BasicSkibidi currentTarget = target.gameObject.GetComponent<BasicSkibidi>();
            player.SetChasingStatus(false, currentTarget);
            isChasing = false;
        }
    }
}
