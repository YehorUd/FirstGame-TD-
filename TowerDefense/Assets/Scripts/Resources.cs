using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public int Gold, TowerCost, EnemyCost;
    public Text GoldText;

    public GameObject _oneLive, _twoLive, _threeLive;
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
            _twoLive.gameObject.SetActive(false);
        _threeLive.gameObject.SetActive(false);
        _index++;


    }
    public void EnemyKill()
    {
        Gold += EnemyCost;
    }
}
