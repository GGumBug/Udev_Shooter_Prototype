using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region
    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    private float _spawnTime = 2.0f;
    public int gold;

    public void Spawn()
    {
        StartCoroutine("IESpawnDelay");
    }

    private IEnumerator IESpawnDelay()
    {
        Vector3 pos = new Vector3(9, Random.Range(-4.0f, 4.0f), 0);
        int check = Random.Range(0, 2);

        if (check == 0)
        {
            GameObject go = Resources.Load<GameObject>("Prefabs/Objects/Asteroid");
            Instantiate(go, pos, Quaternion.identity);
        }
        else
        {
            int randIndex = Random.Range(0, 3);
            GameObject go = Resources.Load<GameObject>($"Prefabs/Enemy/Enemies_{randIndex}");
            Instantiate(go, pos, Quaternion.identity);
        }
        
        
        yield return new WaitForSeconds(_spawnTime);

        StartCoroutine("IESpawnDelay");
    }
}
