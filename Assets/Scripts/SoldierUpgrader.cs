using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUpgrader : MonoBehaviour
{
    public LvlAttack[] upgradesAttackShooter;
    public LvlSpeed[] upgradesSpeedShooter;

    public void UpgradeAttack(int position)
    {
        int lvl = GameManager.instance.ss.curSoldiers[position].GetComponent<SoldierBase>().curLevelAttack;
        GameManager.instance.ss.curSoldiers[position].GetComponent<SoldierBase>().UpgradeAttack(upgradesAttackShooter[lvl].value);
        GameManager.instance.ChangeAmanith(-upgradesAttackShooter[lvl].price);
    }

    public void UpgradeSpeed(int position)
    {
        int lvl = GameManager.instance.ss.curSoldiers[position].GetComponent<SoldierBase>().curLevelSpeed;
        GameManager.instance.ss.curSoldiers[position].GetComponent<SoldierBase>().UpgradeSpeed(upgradesSpeedShooter[lvl].value);
        GameManager.instance.ChangeAmanith(-upgradesSpeedShooter[lvl].price);
    }

}
