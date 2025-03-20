using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//管理敌人的生成
public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public Transform startPoint;//起始位置
    public List<Wave> waveList;

    private int enemyCount = 0;

    private Coroutine spawnCoroutine;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // 延迟5秒后开始生成敌人
        StartCoroutine(WaitBeforeSpawn(5.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitBeforeSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waveList)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, startPoint.position, Quaternion.identity);
                enemyCount++;
                if (i != wave.count - 1)//等待时间
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while (enemyCount > 0)
            {
                yield return 0;
            }
            // 每波敌人之间的间隔时间
            yield return new WaitForSeconds(5.0f);
            // 更新波次
            BuildManager.Instance.ChangeWave(1);
        }
        yield return null;

        while (enemyCount > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win();
    }
    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine);
    }

    public void DecreateEnemyCount()
    {
        if (enemyCount > 0)
        {
            enemyCount--;
        }
    }
}
