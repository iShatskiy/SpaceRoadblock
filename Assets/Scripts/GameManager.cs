using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject looseScreen;

    public SoldierShop ss;
    public SoldierUpgrader su;
    public ButtonChecker checker;
    public HpBarScript hpScript;
    public int startCountAmanith;
    public int startCountHp;
    private int playerHp;
    public int PlayerHp {
        get {
            return playerHp;
        }
        set {
            playerHp = value;
            if (playerHp <= 0)
            {
                Lose();
            }
        }
    }

    private int countEnemies;
    public int CountEnemies {
        get {
            return countEnemies;
        }
        set {
            countEnemies = value;
            if (value == 0)
            {
                Win();
            }
        }
    }
    public int countAmanith;


    public bool skill_1_release;

    void Awake() {
        instance = this;
        ss = FindObjectOfType<SoldierShop>();
        su = FindObjectOfType<SoldierUpgrader>();
        checker = FindObjectOfType<ButtonChecker>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeAmanith(startCountAmanith);
        ChangeHp(startCountHp);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        Debug.Log("ПОБЕДА!!!");
        var soldiers = FindObjectsOfType<SoldierBase>();
        foreach (var item in soldiers)
        {
            item.prepared = false;
        }
        winScreen.SetActive(true);
    }

    public void Lose()
    {
        looseScreen.SetActive(true);
    }

    public void ChangeAmanith(int cnt)
    {
        countAmanith += cnt;
        FindAnyObjectByType<AmanithCounter>().GetComponent<TMP_Text>().text = countAmanith.ToString();
        checker.RefreshButtons();
    }

    public void ChangeHp(int cnt)
    {
        PlayerHp += cnt;
        hpScript.UpdateHp(PlayerHp);
        //FindAnyObjectByType<HpCounter>().GetComponent<TMP_Text>().text = "HP: " + PlayerHp.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
