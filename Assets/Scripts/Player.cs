using System.IO;
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
    private float speedHor = 10;


    private const string Shoppt = "Shoop.txt";
    private bool modell1;
    private bool modell2;
    private int whichOne;

    Vector3 target;

    bool jumped;
    private bool isGrounded;
    private bool hasChangedCrowl;

    private float horizontalInput;
    private float verticalInput;
    private class Shop
    {
        public int Coins;
        public bool[] model1;
        public bool[] model2;
    }

    private Animator animator;
    private void Start()
    {
        if (File.Exists(Shoppt))
        {
            var jsonString = File.ReadAllText(Shoppt);
            var shoop = JsonUtility.FromJson<Shop>(jsonString);
            if (shoop != null)
            {

                modell1 = shoop.model1[0];
                modell2 = shoop.model2[0];

            }
            if (modell1)
            {
                whichOne = 1;
            }
            else
            {
                whichOne = 2;
            }
        }
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
            if(whichOne == 2)
            {
                Vector3 newSize3 = boxColiderToBeShrinked.size;
                newSize3.y = 5.79032f;
                boxColiderToBeShrinked.size = newSize3;
            }
            animator.SetBool("IsCrowling", true);
            speedHor = 4;

        }
        else
        {
            Vector3 newSize2 = boxColiderToBeShrinked.center;
            newSize2.z = 0.00087784f;
            boxColiderToBeShrinked.center = newSize2;
            Vector3 newSize = boxColiderToBeShrinked.size;
            newSize.z = 0.04f;
            boxColiderToBeShrinked.size = newSize;
            if (whichOne == 2)
            {
                Vector3 newSize3 = boxColiderToBeShrinked.size;
                newSize3.y = 10.79032f;
                boxColiderToBeShrinked.size = newSize3;
            }
            animator.SetBool("IsCrowling", false);
            speedHor = 10;
           

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
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

        rigidBodyComponent.velocity = new Vector3(horizontalInput * speedHor, rigidBodyComponent.velocity.y, 0);
        if (!isGrounded)
        {
            return;
        }
        if(jumped == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumped = false;
        }
    }
    public void SetText(ScoreCounter scoreC, TextMeshProUGUI scoreT)
    {
        scoreCounter = scoreC;
        scoreText = scoreT;
    }
    

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    

}
