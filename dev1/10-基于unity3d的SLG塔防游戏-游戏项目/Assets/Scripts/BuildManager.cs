using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //����ʵ�ֵ���ģʽ��ȷ��ȫ��ֻ��һ��BuildManagerʵ��
    public static BuildManager Instance { get; private set; }

    public TurretData standardTurretData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;

    public TurretData selectedTurretData;

    public TextMeshProUGUI moneyText;
    private Animator moneyTextAnim; //��ȡmoneyText����Ķ���������
    public TextMeshProUGUI enemyText;
    private Animator enemyTextAnim;//��ȡenemyText����Ķ���������
    private int waveCount = 1; //��ǰ����

    private int money = 1000;   //Ĭ�Ͻ�Ǯ

    public UpgradeUI upgradeUI;
    private MapCube upgradeCube;


    //���õ���ʵ��������ȡmoneyText����Ķ���������
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
    //�жϽ�Ǯ�Ƿ��㹻
    public bool IsEnough(int need)
    {
        if (need <= money)
        {
            return true;
        }
        else
        {
            MoneyFlicker(); //���Ž�Ǯ��˸����
            return false;
        }
    }
    //�ı�money��ֵ
    public void ChangeMoney(int value)
    {
        this.money += value;
        //����UI��ʾ
        moneyText.text = "money:��" + money.ToString();
    }
    //��Ǯ��˸����
    private void MoneyFlicker()
    {
        moneyTextAnim.SetTrigger("flicker");
    }
    //���µ��˲���
    public void ChangeWave(int value)
    {
    waveCount += value;
    //����UI��ʾ
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
