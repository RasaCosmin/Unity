using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public Text countText;
	public Text WinText;

	private Rigidbody rigidBody;
	private int count;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		WinText.text = "";
	}

	void FixedUpdate ()
	{
		Vector3 movement;

		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		} else {
			movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.z);
		}
		rigidBody.AddForce (movement * speed);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("pickUp")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			WinText.text = "you win!";
		}
	}
}
