using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<EnemyClass> enemies = new List<EnemyClass>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    private Vector3 screenBounds;


    public int waveDuration;

    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    private bool randbool;

    
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        randbool = Random.value < 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer<= 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                //Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                
                if (randbool)
                {
                    spawnLocation.position = new Vector3(screenBounds.x * randPos(), Random.Range(-screenBounds.y, screenBounds.y), 0);
                    randbool = Random.value < 0.5f;
                }
                else
                {
                    spawnLocation.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * randPos(), 0);
                    randbool = Random.value < 0.5f;
                }             

                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    
    }

    public static float randPos()
     {
        float x = Random.Range(1.1f,1.5f);
        int sign = Random.Range(0,2);
        if(sign == 1)
        {
            x = -x;
        }
        else
        {
            x = +x;
        }
        return x;
     }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval= waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}
    [System.Serializable]
public class EnemyClass
{
    public GameObject enemyPrefab;
    public int cost;

}