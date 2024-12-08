using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HpBarScript : MonoBehaviour
{

    private int curPlayerHp;
    public List<GameObject> visual;

    // Start is called before the first frame update
    void Start()
    {
        curPlayerHp = GameManager.instance.PlayerHp;    
    }

    // Update is called once per frame
    public void UpdateHp(int hp)
    {
        foreach (GameObject go in visual) {
            if (hp > 0)
            {
                go.SetActive(true);
                
                hp--;
            }
            else {
                //go.SetActive(false);
                go.GetComponent<hpSlotScript>().TakeDamage();
            }
        }
    }
}
