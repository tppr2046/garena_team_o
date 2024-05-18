using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementTest : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    [SerializeField] Settlement settlement;

    void Start()
    {
        battleManager.EndEvent += settlement.Run;
    }
}
