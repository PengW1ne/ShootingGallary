using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int speed;
    private Vector3 lastPos;
    public GameObject decal;
    
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            print(hit.transform.name);
            GameObject d = Instantiate<GameObject>(decal);
            d.transform.position = hit.point + hit.normal * 0.001f;
            d.transform.rotation = Quaternion.LookRotation(-hit.normal);
            Destroy(d,10);
        }
        lastPos = transform.position;
    }
}
