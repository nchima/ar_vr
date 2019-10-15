using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VButton : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject model, model1, model2, vbutton, vbutton1, vbutton2;
	// private bool play = false;
	// private bool play1 = false;
	// private bool play2 = false;

	private GameObject themeMusic, raphMusic, donMusic;
	private AudioSource theme, raph, don;
	// Use this for initialization
	void Start () {

		// model = GameObject.Find ("Ninjas");
		vbutton.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbutton1.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbutton2.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		themeMusic = GameObject.Find ("MySound1");
		raphMusic = GameObject.Find ("MySound2");
		donMusic = GameObject.Find ("MySound3");

		theme = themeMusic.GetComponent (typeof (AudioSource)) as AudioSource;
		raph = raphMusic.GetComponent (typeof (AudioSource)) as AudioSource;
		don = donMusic.GetComponent (typeof (AudioSource)) as AudioSource;

		// // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
		// VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		// for (int i = 0; i < vbs.Length; ++i) {
		// 	// Register with the virtual buttons TrackableBehaviour
		// 	vbs[i].RegisterEventHandler (this);
		// }

		model.SetActive (false);
		model1.SetActive (false);
		model2.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
	public void OnButtonPressed (VirtualButtonBehaviour vb) {

		Debug.Log ("Button pressed");
		// play = !play;
		switch (vb.VirtualButtonName) {
			case "VirtualButton ":
				model.GetComponent<ModelInstruction> ().setStatus ();
				model.SetActive (true);
				model1.SetActive (false);
				model2.SetActive (false);
				if (!theme.isPlaying) {
					theme.Play (0);
				}
				don.Stop ();
				raph.Stop ();
				break;
			case "VirtualButton2":
				model1.GetComponent<ModelInstruction> ().setStatus ();
				model.SetActive (false);
				model1.SetActive (true);
				model2.SetActive (false);
				if (!raph.isPlaying) {
					raph.Play (0);
				}
				don.Stop ();
				theme.Stop ();
				break;
			case "VirtualButton1":
				model2.GetComponent<ModelInstruction> ().setStatus ();
				model.SetActive (false);
				model1.SetActive (false);
				model2.SetActive (true);
				if (!don.isPlaying) {
					don.Play (0);
				}
				theme.Stop ();
				raph.Stop ();
				break;
		}
	}

	public void OnButtonReleased (VirtualButtonBehaviour vb) {

	}

}