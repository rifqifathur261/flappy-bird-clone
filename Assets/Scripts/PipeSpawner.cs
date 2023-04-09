using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float yPosMin, yPosMax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPipeCoroutine(){
        yield return new WaitForSeconds(spawnTime);
        GameObject obstacle = Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
        
        Destroy(obstacle, 6.0f);

        StartCoroutine(SpawnPipeCoroutine());
    }
}
