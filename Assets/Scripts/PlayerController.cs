using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text StatusText;

    private Rigidbody player;
    private int count;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        StatusText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        player.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            StatusText.text = count.ToString();
            if (count >= 12)
            {
                StatusText.gameObject.SetActive(true);
                StatusText.text = "You've won!";
            }
        }
    }
}
