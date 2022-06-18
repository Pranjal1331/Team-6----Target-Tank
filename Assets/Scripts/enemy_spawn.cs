using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public GameObject Enemy;
    public float xPos;
    public float zPos;
    public int enemyCount;
    public int enemies_in_scene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < enemies_in_scene)
        {
            xPos = Random.Range(470, 510);
            zPos = Random.Range(60, 100);
            Instantiate(Enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            enemyCount += 1;
        }
    }
}
