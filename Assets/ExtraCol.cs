using UnityEngine;
using System.Collections;

public class ExtraCol : MonoBehaviour {

	private PlatformerCharacter2D playerChar;
	private GameObject player;

	public float moveSpeed;
	public GameObject[] reds;
	// Use this for initialization
	void Start () {
		reds = GameObject.FindGameObjectsWithTag("Red");
		playerChar = GetComponent<PlatformerCharacter2D> ();
		player = GameObject.Find ("Player");
		
		transform.position = Vector3.zero;

		//player.rigidbody2D.AddForce (new Vector3(-100, 0, 0), 0);
		player.rigidbody2D.velocity = new Vector3(100, 0, 0);

	}
	void Update (){

	}

	void Blow(){
		Debug.Log("Blow");
		float x = transform.position.x;
		float y = transform.position.y;
		//player.rigidbody2D.AddForce (new Vector3(-10, 0, 0), 0);


		float goal = x - 5;
		while (transform.position.x > goal) {
			player.rigidbody2D.velocity = new Vector3(-3, 0, 0);
		}


	}
	
	// Update is called once per frame
	/*void Update () {
		float h = Input.GetAxis ("Horizontal") * moveSpeed;
		transform.Translate (Vector2.right * h * Time.deltaTime);
	}*/
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Red") {
			transform.position = new Vector3(1,1,0);
			Blow ();
			Debug.Log("Jazz"); 
		}
		if (col.gameObject.name == "SpinningRedThing") {
			//float crrPos = 
			Blow ();
			//transform.position = new Vector3(transform.position.x-3,1,0);
			Debug.Log("Jazz2"); 
		}
	}
}
