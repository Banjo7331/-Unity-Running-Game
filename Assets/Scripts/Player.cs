using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float speed;
    public Rigidbody rigidBodyComponent;
    public BoxCollider boxColiderToBeShrinked;

    Vector3 target;

    bool jumped;
    private bool isGrounded;
    private bool hasChangedCrowl;

    private float horizontalInput;
    private float verticalInput;
    

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        target = transform.position;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.A) && target.x > -2)
        {
            //rigidBodyComponent.AddForce(Vector3.left*5);
            target += new Vector3(-3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && target.x < 2)
        {
            //rigidBodyComponent.AddForce(Vector3.right * 5);
            target += new Vector3(3, 0, 0);
        }
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsCrowling", true);
        }
        else
        {
            animator.SetBool("IsCrowling", false);
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;  
        }

        if(verticalInput < 0 )
        {
            jumped = false;
            Vector3 newSize2 = boxColiderToBeShrinked.center;
            newSize2.z = 0.00047784f;
            boxColiderToBeShrinked.center = newSize2;
            Vector3 newSize = boxColiderToBeShrinked.size;
            newSize.z = 0.02f;
            boxColiderToBeShrinked.size = newSize;
            animator.SetBool("IsCrowling", true);

        }
        else
        {
            Vector3 newSize2 = boxColiderToBeShrinked.center;
            newSize2.z = 0.00087784f;
            boxColiderToBeShrinked.center = newSize2;
            Vector3 newSize = boxColiderToBeShrinked.size;
            newSize.z = 0.04f;
            boxColiderToBeShrinked.size = newSize;
            animator.SetBool("IsCrowling", false);

        }

        //if(target.y <0.5)
        //transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
        if(collision.gameObject.tag != "InvisibleWal")
            isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "InvisibleWal")
            isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            scoreCounter.AddScore();
        }
    }
    private void FixedUpdate()
    {

        rigidBodyComponent.velocity = new Vector3(horizontalInput * 10, rigidBodyComponent.velocity.y, 0);
        if (!isGrounded)
        {
            return;
        }
        if(jumped == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * 8, ForceMode.VelocityChange);
            jumped = false;
        }
    }
}
