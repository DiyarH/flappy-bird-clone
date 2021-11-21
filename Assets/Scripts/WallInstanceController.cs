using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInstanceController : MonoBehaviour
{
    public EventManager eventManager;
    // Start is called before the first frame update
    void Start()
    {
        eventManager.OnPlayerCollideWithWall.AddListener(() => Destroy(this.gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -10)
            Destroy(this.gameObject);
    }
}
