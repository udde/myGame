using UnityEngine;
using System.Collections;

public class ExtraCol : MonoBehaviour {

	public float moveSpeed;
	public GameObject[] reds = GameObject.FindGameObjectsWithTag("Red");
	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("horizontal") * moveSpeed;
		transform.Translate (Vector2.right * h * Time.deltaTime);
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Red") {
			transform.position = new Vector3(20,1,0);
		}
	}
}
