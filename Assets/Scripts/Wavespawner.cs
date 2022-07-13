using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavespawner : MonoBehaviour
{
    [System.Serializable]
    public class enemys
    {
        public Transform enemypos;
    }
        public Transform enemy;
        //public int count;
        public float rate;
        //public float xPosmin, xPosmax;
        //public float zPosmin, zPosmax;
        int enemies = 0;
        //float xPos, zPos;

    public enemys[] pos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            StartCoroutine(EnemyDrop());
            gameObject.GetComponent<BoxCollider>().enabled = false;  
        }
        
    }
    int i = 0;
    IEnumerator EnemyDrop()
    {
        while (enemies < pos.Length)
        {

            //xPos = Random.Range(xPosmin, xPosmax);
            //zPos = Random.Range(zPosmin, zPosmax);
            Instantiate(enemy, pos[i].enemypos.position, Quaternion.identity);
            Debug.Log("Spawn");
            yield return new WaitForSeconds(rate);
            enemies += 1;
            i++;
        }
        yield break;
        
    }
}
