using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool CanBuild;
    public GameObject TowerPrefab;
    public Color MainColor, TrueColor, FalseColor;

    private Renderer _render;
    private Cannon2 _costTower2;
    private Resources _res;
    void Start()
    {
        _render = GetComponent<Renderer>();
        _res = FindObjectOfType<Resources>();
        _costTower2 = GetComponent<Cannon2>();
    }

    private void OnMouseUp()
    {
        if (CanBuild && _res.Gold >= _res.TowerCost)
        {
            GameObject tower = Instantiate(TowerPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            // Tower tower = Instantiate(TowerPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0)).GetComponent<Tower>;
            CanBuild = false;
            _res.BuildTower();
        }
    }

    private void OnMouseOver()
    {
        if (CanBuild)
            _render.material.color = TrueColor;
        else
            _render.material.color = FalseColor;
    }
    private void OnMouseExit()
    {
        _render.material.color = MainColor;
    }

    void Update()
    {

    }
}
