using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EventManager eventManager;
    [Range(0.0f, 20.0f)]
    public float jumpPower;
    [Range(0.0f, 10.0f)]
    public float gravity;
    public int score;
    public int highscore;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gravity;
        rigidbody.simulated = false;
        score = 0;
        highscore = PlayerPrefs.GetInt("High Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rigidbody.simulated == false)
            {
                rigidbody.simulated = true;
                eventManager.OnFirstJump.Invoke();
            }
            rigidbody.velocity = new Vector2(0, jumpPower);
        }
        if (transform.position.y <= -5.0)
        {
            if (score > highscore)
            {
                highscore = score;
            }
            PlayerPrefs.SetInt("High Score", highscore);
            eventManager.OnPlayerCollideWithWall.Invoke();
            gameObject.SetActive(false);
        }
        //GetComponent<SpriteRenderer>().transform.eulerAngles = new Vector3(0, 0, rigidbody.velocity.y * 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (score > highscore)
            {
                highscore = score;
            }
            PlayerPrefs.SetInt("High Score", highscore);
            eventManager.OnPlayerCollideWithWall.Invoke();
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Gap")
        {
            score++;
            eventManager.OnPlayerGoThroughGap.Invoke();
        }
    }
}
