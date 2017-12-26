using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float jumpForce = 9f;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Color blue, yellow, pink, purple;
    public Text scoreText;
    public GameObject colorChanger, circle1, circle2;

    private string currentColor;
    private int score = 0;
    private bool createdBigObject = false;

    public void Start () {
        setRandomColor();
		
	}

	public void Update () {

        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);

        if (position.y <= 0) {
            score = 0;
            scoreText.text = "Score: " + score;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == "Points") {
            Destroy(collider.gameObject);
            generateRandomObject();
            score += 5;
            scoreText.text = "Score: " + score;
            return;
        }

        if (collider.tag == "Color Changer") {
            setRandomColor();
            Destroy(collider.gameObject);
            return;
        }

        if (collider.tag != currentColor) {
            //Debug.Log("You Died!");
            score = 0;
            scoreText.text = "Score: " + score;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void setRandomColor() {
        int rand = Random.Range(0, 4);

        switch (rand) {
            case 0:
                currentColor = "Blue";
                spriteRenderer.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                spriteRenderer.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                spriteRenderer.color = purple;
                break;
        }

    }

    private void generateRandomObject() {
        int rand = Random.Range(0, 2);
        int rand2 = Random.Range(0, 2);

        switch (rand) {
            case 0:

                if (rand2 == 1) {

                    if (createdBigObject == true) {
                        Instantiate(colorChanger, new Vector3(0, transform.position.y + 6f, 0), Quaternion.identity);
                        Instantiate(circle1, new Vector3(0, transform.position.y + 10f, 0), Quaternion.identity);
                    } else {
                        Instantiate(colorChanger, new Vector3(0, transform.position.y + 4f, 0), Quaternion.identity);
                        Instantiate(circle1, new Vector3(0, transform.position.y + 8f, 0), Quaternion.identity);
                    }

                    
                } else {
                    Instantiate(circle1, new Vector3(0, transform.position.y + 8f, 0), Quaternion.identity);
                }

                createdBigObject = false;

                break;
            case 1:

                if (rand2 == 1) {

                    if (createdBigObject == true) {
                        Instantiate(colorChanger, new Vector3(0, transform.position.y + 6f, 0), Quaternion.identity);
                        Instantiate(circle2, new Vector3(0, transform.position.y + 11f, 0), Quaternion.identity);
                    } else {
                        Instantiate(colorChanger, new Vector3(0, transform.position.y + 4f, 0), Quaternion.identity);
                        Instantiate(circle2, new Vector3(0, transform.position.y + 9f, 0), Quaternion.identity);
                    }

                } else {

                    if (createdBigObject == true) {
                        Instantiate(circle2, new Vector3(0, transform.position.y + 10f, 0), Quaternion.identity);
                    } else {
                        Instantiate(circle2, new Vector3(0, transform.position.y + 8f, 0), Quaternion.identity);
                    }
                }

                createdBigObject = true;

                break;
        }
    }
}
