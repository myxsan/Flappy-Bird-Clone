using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    Bird bird;
    public GameObject pipePreafab;
    [SerializeField] float height;
    [SerializeField] float interval = 1.0f;
    void Awake()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    void Start()
    {
        StartCoroutine(SpawnPipe());
    }
    public IEnumerator SpawnPipe()
    {
        while(!bird.isDeath)
        {
            Instantiate(pipePreafab, new Vector3(3, Random.Range(-height, height), 0.0f), Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}
