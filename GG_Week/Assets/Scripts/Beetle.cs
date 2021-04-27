using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{

    public GameObject beetleTaken;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.BeetleScore();
            Destroy(gameObject);
            GameObject beetleTakenAnim = Instantiate(beetleTaken, transform.position, Quaternion.identity);
            Destroy(beetleTakenAnim, 0.4f);
            SoundController.Instance.MakeCoinSound();
        }
    }
}
