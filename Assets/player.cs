using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float SpawnTime;
    public int Score;
    public UnityEngine.UI.Text ScoreText;
    public GameObject[] prefabs;

    float spawnTime;
    
	void Update () {
		if(spawnTime <= 0)
        {
            spawnTime = SpawnTime;
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(Random.Range(-5, 5), 5), Quaternion.identity, null);
        }
        spawnTime -= Time.deltaTime;

        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ScoreText.text = Score.ToString();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            Score++;
        }
    }
}
