using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShop : MonoBehaviour
{
    public SoldierPositions positions;

    public List<GameObject> soldiers;
    public List<GameObject> curSoldiers;

    public int currentButton;
    [SerializeField] private GameObject unitSelection;

    private void Awake()
    {
        positions = GetComponentInChildren<SoldierPositions>();
    }

    public void BuyShooter()
    {
        GameObject go = Instantiate(soldiers[0], positions.TakePosition(currentButton - 1), Quaternion.identity);
        curSoldiers.Add(go);
        go.GetComponent<SoldierBase>().position = currentButton - 1;
        GameManager.instance.checker.SwitchUpgradeButton(currentButton - 1);
        GameManager.instance.ChangeAmanith(-soldiers[0].GetComponent<SoldierBase>().price);
    }

    public void BuyBomber()
    {
        GameObject go = Instantiate(soldiers[1], positions.TakePosition(currentButton - 1), Quaternion.identity);
        curSoldiers.Add(go);
        go.GetComponent<SoldierBase>().position = currentButton - 1;
        GameManager.instance.checker.SwitchUpgradeButton(currentButton - 1);
        GameManager.instance.ChangeAmanith(-soldiers[0].GetComponent<SoldierBase>().price);
    }

    public void SelectUnit(int value) {
        currentButton = value;
        unitSelection.SetActive(true);
    }
}
