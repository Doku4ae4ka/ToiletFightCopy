using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class UIMainPlayerBtns : MonoBehaviour
{
    [SerializeField] private Button attackBtn;
    [SerializeField] private EventTrigger shieldEventTrigger;

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        InitButtons();
    }

    private void InitButtons()
    {

        attackBtn.onClick.AddListener(_player.playerAttacker.PerformAttack);

        EventTrigger.Entry pointerDownEvent = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerDown
        };
        pointerDownEvent.callback.AddListener(_player.playerAttacker.StartBlock);
        shieldEventTrigger.triggers.Add(pointerDownEvent);

        EventTrigger.Entry pointerUpEvent = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerUp
        };
        pointerUpEvent.callback.AddListener(_player.playerAttacker.EndBlock);
        shieldEventTrigger.triggers.Add(pointerUpEvent);
    }

}
