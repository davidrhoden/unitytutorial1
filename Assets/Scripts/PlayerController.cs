using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {







	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	public Texture myTexture;

	void Start ()
	{
		count = 0;
		setCountText();
		winText.text = "";
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText();
		}
	}

	void setCountText ()
	{
		countText.text = "Spinning cubes: " + count.ToString();
		if (count >= 8) 
		{
			winText.text = "hey hey hey";
			renderer.material.SetTexture("_MyTexture", myTexture);
		}
	}
}
