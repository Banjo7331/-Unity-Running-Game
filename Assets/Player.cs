using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float speed;
    //private Rigidbody rigidBodyComponent;
    Vector3 target;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        target = transform.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && target.x > -2)
        {
            target += new Vector3(-3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && target.x < 2)
        {
            target += new Vector3(3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsCrowling", true);
        }
        else
        {
            animator.SetBool("IsCrowling", false);
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBodyComponent.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
        }*/

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            scoreCounter.AddScore();
        }
    }
}
