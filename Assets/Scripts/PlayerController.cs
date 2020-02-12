using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animation animation;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
        respawn();
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);

        rigidbody.velocity = movement * 0.7f;

        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if (x != 0 || y != 0)
        {
            animation.Play("Run");
            FindObjectOfType<AudioManager>().Play("Walk");
        } else
        {
            animation.Play("Idle");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            print("Hit!");
            respawn();
        }
    }

    public void OnTriggerEnter (Collider collider)
    {
        if (collider.transform.tag == "Finish")
        {
            print("Finish");
            GameManager.NextScene();
        }
    }

    public void respawn()
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
    }

}
