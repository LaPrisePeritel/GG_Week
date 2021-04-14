using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject[] trapArray;

    // Start is called before the first frame update
    void Start()
    {
        CheckTraps();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckTraps();
            foreach (GameObject item in trapArray)
            {
                item.GetComponent<Trap>().ChangeTrapState();
            }
        }
    }

    public void CheckTraps()
    {
        trapArray = GameObject.FindGameObjectsWithTag("Trap");
    }
}
