using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bird : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float timeBetweenJumps;

    private Rigidbody2D _rb;
    private bool _canJump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _canJump = true;
    }

    private void Update()
    {
        if (transform.position.y < -5.5f)
            Death();

        if (!Input.GetKeyDown(KeyCode.Space)) return;

        Jump();
    }

    private void Jump()
    {
        if (gameObject.transform.position.y > 4 || !_canJump) return;


        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(speed * 10, jumpHeight * 10));
        
        StartCoroutine(StartJumpTimer());
    }

    private IEnumerator StartJumpTimer()
    {
        _canJump = false;
        yield return new WaitForSeconds(timeBetweenJumps);
        _canJump = true;
    }

    private void Death()
    {
        Debug.Log("DEAD");
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Pipe>() != null)
            Death();
    }
}