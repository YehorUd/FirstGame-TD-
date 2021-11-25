using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public int Gold, TowerCost, EnemyCost;
    public Text GoldText;
    public GameObject OneLive, TwoLive, ThreeLive;
    private int _index;
    void Start()
    {
        _index = 0;
    }

    void Update()
    {
        GoldText.text = "" + Gold;

    }

    public void BuildTower()
    {
        Gold -= TowerCost;
    }
    public void MissEnemy()
    {
        if (_index == 1)
            TwoLive.gameObject.SetActive(false);
        ThreeLive.gameObject.SetActive(false);
        _index++;


    }
    public void EnemyKill()
    {
        Gold += EnemyCost;
    }
}
