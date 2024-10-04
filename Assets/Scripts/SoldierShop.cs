using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShop : MonoBehaviour
{
    public SoldierPositions positions;

    public List<GameObject> soldiers;
    public List<GameObject> curSoldiers;
    private void Awake()
    {
        positions = GetComponentInChildren<SoldierPositions>();
    }

    public void BuySoldier(int numButton)
    {
        GameObject go = Instantiate(soldiers[0], positions.TakePosition(numButton - 1), Quaternion.identity);
        curSoldiers.Add(go);
        go.GetComponent<SoldierBase>().position = numButton - 1;
        GameManager.instance.checker.SwitchUpgradeButton(numButton - 1);
        GameManager.instance.ChangeAmanith(-soldiers[0].GetComponent<SoldierBase>().price);
    }
}
