using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //用于实现单例模式，确保全局只有一个BuildManager实例
    public static BuildManager Instance { get; private set; }

    public TurretData standardTurretData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;

    public TurretData selectedTurretData;

    public TextMeshProUGUI moneyText;
    private Animator moneyTextAnim; //获取moneyText组件的动画控制器
    public TextMeshProUGUI enemyText;
    private Animator enemyTextAnim;//获取enemyText组件的动画控制器
    private int waveCount = 1; //当前波次

    private int money = 1000;   //默认金钱

    public UpgradeUI upgradeUI;
    private MapCube upgradeCube;


    //设置单例实例，并获取moneyText组件的动画控制器
    private void Awake()
    {
        Instance = this;
        moneyTextAnim = moneyText.GetComponent<Animator>();
        enemyTextAnim = enemyText.GetComponent<Animator>();
    }


    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }
    //判断金钱是否足够
    public bool IsEnough(int need)
    {
        if (need <= money)
        {
            return true;
        }
        else
        {
            MoneyFlicker(); //播放金钱闪烁动画
            return false;
        }
    }
    //改变money的值
    public void ChangeMoney(int value)
    {
        this.money += value;
        //更新UI显示
        moneyText.text = "money:￥" + money.ToString();
    }
    //金钱闪烁动画
    private void MoneyFlicker()
    {
        moneyTextAnim.SetTrigger("flicker");
    }
    //更新敌人波次
    public void ChangeWave(int value)
    {
    waveCount += value;
    //更新UI显示
    enemyText.text = "Enemy Wave: " + waveCount.ToString()+"/4";
    }

    public void ShowUpgradeUI(MapCube cube, Vector3 position,bool isDisableUpgrade)
    {
        upgradeCube = cube;
        upgradeUI.Show(position, isDisableUpgrade);
    }
    public void HideUpgradeUI()
    {
        upgradeUI.Hide();
    }

    public void OnTurretUpgrade()
    {
        upgradeCube?.OnTurretUpgrade();
        HideUpgradeUI();
    }
    public void OnTurretDestroy()
    {
        upgradeCube?.OnTurretDestroy();
        HideUpgradeUI();
    }
}
