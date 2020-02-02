using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text lifeText;

    private Rigidbody2D rb2d;
    private int pickupCount;
    private int count;
    private int life;

    void Start() {
        rb2d = GetComponent<Rigidbody2D> ();
        pickupCount = 0;
        count = 0;
        life = 3;

        winText.text = "";
        SetCountText();
        SetLifeText();
    }

    void FixedUpdate(){

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

       

    }


    void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.CompareTag("PickUp")){

            other.gameObject.SetActive(false);

            count = count + 1;
            pickupCount = pickupCount + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {

            other.gameObject.SetActive(false);

            count = count - 1;
            life = life - 1;

            SetCountText();
            SetLifeText();
        }


    }

    void SetCountText() {

        countText.text = "Count: " + count.ToString();



        if (pickupCount == 12){
            transform.position = new Vector2(60, 0);
        }

        if (pickupCount == 20){
            winText.text = "You win! Game created by Graci Baker.";
        }

    }

    void SetLifeText()
    {
        lifeText.text = "Life: " + life.ToString();

        if (life == 0){
            
            winText.text = "Game Over.  Game created by Graci Baker.";
            Destroy(this); //this destroys current controller -> destroys escape button input!! >:(

        }

    }

}

