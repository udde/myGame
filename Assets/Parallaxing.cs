using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds; 	//array of all back- and forgrounds to be parallaxed
	private float[] parallaxScales; 	//the proportion of the cameras movement to move backgrounds by
	public float smoothing = 1;			//how smooth the parallax will be. more than 0!

	private Transform cam;			//ref to man camera
	private Vector3 previousCamPos;	//cam pos in the prev frame

	//Called before Start() - but after the game objects are setup. great fo references
	void Awake(){
		//set up cam reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		//init prev cam pos
		previousCamPos = cam.position;

		//instantiate scales-array
		parallaxScales = new float[backgrounds.Length];

		//fill array with coresponding backgorund positions
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//for each background element
		for (int i = 0; i < backgrounds.Length; i++) {
			//the parallax is the oposite of the camera movement beacouse the previous frame multiplyed by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//set target x position = current position + the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//Create a target position wich is the backgrounds current position with its target x position
			Vector3 backgroundTargetpos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//Fade between current position and target position
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetpos, smoothing * Time.deltaTime);

			}
		//set prev cam right
		previousCamPos = cam.position;
	}
}
