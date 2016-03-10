using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class instrction : MonoBehaviour {

	// Use this for initialization
	public GameObject next = null;// click to see the next page
	public GameObject previous = null;// click to see the previous page
	public Text pagenumber = null;
	private Text ui;
	int CurrentPagenummber= 1;
	void Start () 
	{
		ui = GetComponent<Text> ();
		pagenumber.GetComponent< Text > ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			Application.LoadLevel("MainMenu");	
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			CurrentPagenummber++; 
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			CurrentPagenummber--; 
		}
		if (CurrentPagenummber == 1) {
			ui.text = "Press the  right  and left arrow to move  jumpman right to left on the screen.";

			pagenumber.text = " Pages 1/4";



		}
		if (CurrentPagenummber == 2) {
			ui.text = " Press the up and down arrows to move Jumpman on ladders.";

			pagenumber.text = "Pages 2/4  ";
		}
		if (CurrentPagenummber== 3) {
			ui.text = " Press the space bar to jump. ";

			pagenumber.text = "Pages 3/4  ";
		}
		if (CurrentPagenummber == 4) {
			ui.text = " Avoid  the barrels and fire guys because they will kill you. Use the hamemer to destory your enemies. You can find on them screen. Your goal is to rescue the laday from donky kong ";

			pagenumber.text = " Pages 4/4 ";
		}

		if (CurrentPagenummber >4) 
		{
			CurrentPagenummber= 4;
		}
		if (CurrentPagenummber < 1) 
		{
			CurrentPagenummber=1;
		}
	}



	}





