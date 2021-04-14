using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackGround : MonoBehaviour
{
    public GameObject background;
    private Camera mainCamera;
    private Vector2 screenBounds;

    public float choke;
    // Start is called before the first frame update
    public void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        loadChildObjects(background);
    }

    void loadChildObjects(GameObject tilemap)
    {
        float tilemapWidth = tilemap.GetComponent<TilemapRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / tilemapWidth);
        GameObject clone = Instantiate(tilemap) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(tilemap.transform);
            c.transform.position = new Vector3(tilemapWidth * i, tilemap.transform.position.y, tilemap.transform.position.z);
            c.name = tilemap.name + i;
        }
        Destroy(clone);
        Destroy(tilemap.GetComponent<TilemapRenderer>());
    }

    void RepositionChildObjects(GameObject tilemap)
    {
        Transform[] children = tilemap.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<TilemapRenderer>().bounds.extents.x - choke;
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);

            }
            else if (transform.position.x - screenBounds.x < lastChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
    // Update is called once per frame
    public void LateUpdate()
    {
        RepositionChildObjects(background);
    }
}
