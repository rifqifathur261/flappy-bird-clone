using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce;

    public GameObject loseScreenUI;

    public int score, hiscore;
    public Text scoreText, hiscoreText;
    string HISCORE = "HISCORE";

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hiscore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        playerJump();
    }
    
    void playerJump(){
        if(Input.GetMouseButtonDown(0)){
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void playerLose(){
        AudioManager.singleton.PlaySound(1);
        if(score > hiscore){
            hiscore = score;
            PlayerPrefs.SetInt(HISCORE, hiscore);
        }
        hiscoreText.text = "hiscore: " + hiscore.ToString();

        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void restartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void addScore(){
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreText.text = "score: "+score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("obstacle")){
            playerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("score")){
            addScore();
        }
    }
}
