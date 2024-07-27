using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Physics
    public float moveSpeed = 5f;
    public float jump = 6f;
    Rigidbody2D rg2;
    Animator animator;
    private bool isGrounded;
    //Source
    public AudioSource Die;
    public AudioSource jumpMusic;
    public AudioSource Land;
    //Score
    private float Score;
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        rg2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("Run");
        Land.Play();
        animator.SetBool("Die", false);
    }

    // Update is called once per frame
    void Update()
    {
        rg2.velocity = new Vector2(moveSpeed, rg2.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rg2.velocity = new Vector2(rg2.velocity.x, jump);
            jumpMusic.Play();
        }
        // tính điểm
        Score += Time.deltaTime * moveSpeed;
        ScoreText.text = "Score: " + Score;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check chạm nền
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        //gameover
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("Die", true);
            GameManager.instance.GameOver();
            Die.Play();
            Land.Pause();
        }
        // win
        else if (collision.gameObject.CompareTag("Win"))
        {
            GameManager.instance.GameWin();
            Land.Pause();
        }
    }
    // check thoát chạm nền
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    public float GetScore()
    {
        return Score;
    }
}
