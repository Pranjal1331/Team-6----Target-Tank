using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public GameObject Enemy;
    public float xPosmax, xPosmin;
    public float zPosmax, zPosmin;
    public int enemyCount;
    public int enemies_in_scene;
    float xPos, zPos;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Spawn");
            StartCoroutine(EnemyDrop());
        }
            
    }

    IEnumerator EnemyDrop()
    {   
        while (enemyCount < enemies_in_scene)
        {
          
            xPos = Random.Range(xPosmin, xPosmax);
            zPos = Random.Range(zPosmin, zPosmax);
            Instantiate(Enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            enemyCount += 1;
        }
    }
}
