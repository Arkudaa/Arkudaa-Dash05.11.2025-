using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed;
    public float jumpspeed;
    private bool isJumping=false;
    public Transform GroundDetector;
    public LayerMask groundMask;
    public float groundRadius;
    public AudioClip jumpSound;
    public AudioClip collectSound;
    public AudioClip dangerSound;
    public AudioSource sounds;
    public int wallet;
    public Text walletText;
    public GameObject coinSparkles;



 


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        walletText.text = "My Score: " + wallet;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            
            Jump();
           
        }

    }

    private void FixedUpdate()
    {
        //rig.velocity = new Vector2(speed,rig.velocity.y);
        Vector2 velocity = rig.velocity;
        velocity.x = speed;
        if (isJumping)
        {
            sounds.PlayOneShot(jumpSound);
            velocity.y = jumpspeed;
            isJumping = false;
        }
       
        rig.velocity = velocity;

        

    }
     
    public void Jump()
    {   if(isGrounded())
        isJumping = true;
    }


    


    public bool isGrounded()
    {
         Collider2D ground=Physics2D.OverlapCircle(GroundDetector.position, groundRadius, groundMask);
        return ground != null;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "danger")
        {
            GetComponent<TrailRenderer>().enabled = false;
           StartCoroutine(RestartLevel());
            //gameObject.SetActive(false);
        }

        else if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            Instantiate(coinSparkles, collision.transform.position, Quaternion.identity);
            wallet++;
            walletText.text = "My Score: " + wallet;
            sounds.PlayOneShot(collectSound);


        }

    }


   IEnumerator RestartLevel()

    {
       
        Time.timeScale = 0;
        sounds.ignoreListenerPause = true;
        //sounds.PlayOneShot(dangerSound);
      
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log("Working");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }



}
