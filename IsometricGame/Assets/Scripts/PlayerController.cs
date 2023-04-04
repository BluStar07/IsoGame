using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 4f;

    Vector3 forward, right;
    private float moveSpeed;

    [SerializeField] private Animator _animator = null;

    private Vector3 _startPos;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;

        forward.y = 0;
        forward = Vector3.Normalize(forward);

        // -45 degrees from the world x axis
        right = Quaternion.Euler(new Vector3(0, 135, 0)) * forward;
        forward = Quaternion.Euler(new Vector3(0, 45, 0)) * forward;

        // Initial speed
        moveSpeed = walkSpeed;

        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetAxis("Horizontal") > .1 || Input.GetAxis("Horizontal") < -.1 || Input.GetAxis("Vertical") > .1 || Input.GetAxis("Vertical") < -.1)
        {
            Move();
        }
        else
        {
            _animator.SetBool("Move", false);
        }
    }

    void Move()
    {
        // Animation
        _animator.SetBool("Move", true);

        // Movement speed
        Vector3 rightMovement = right * moveSpeed * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Input.GetAxis("Vertical");

        // Calculate what is forward
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Set new position
        Vector3 newPosition = transform.position;
        newPosition += rightMovement;
        newPosition += upMovement;

        // Smoothly move the new position
        transform.forward = heading;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }

    public void Respawn()
    {
        transform.position = _startPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            GameManager.Instance.Restart();
        }

    }

    public void Reset()
    {
        StartCoroutine(DeathCountdown());
    }

    public IEnumerator DeathCountdown()
    {
        yield return new WaitForSeconds(1f);
        Respawn();
    }
}

