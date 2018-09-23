using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour {
	public GameObject MainMenu;
	public Button SingleBtn;
	public Text SingleText;
	public Button MultiBtn;
	public Text MultiText;
	public Button AwardBtn;
	public Text AwardText;
	public Button SettingBtn;
	public Text SettingText;
	public Button GroupBtn;
	public Text GroupText;
	// Use this for initialization
	void Start () {
		//SingleBtn = MainMenu.transform.Find ("SingleBtn");
		SingleBtn.GetComponent<Button>().onClick.AddListener(delegate() {
			Debug.Log (SingleText.text);
		});
		//MultiBtn = MainMenu.transform.Find ("MultiBtn");
		MultiBtn.GetComponent<Button>().onClick.AddListener(delegate() {
			Debug.Log (MultiText.text);
		});
		AwardBtn.GetComponent<Button>().onClick.AddListener(delegate {
			Debug.Log (AwardText.text);
		});
		SettingBtn.GetComponent<Button>().onClick.AddListener(delegate() {
			Debug.Log (SettingText.text);
		});
		GroupBtn.GetComponent<Button>().onClick.AddListener(delegate() {
			Debug.Log (GroupText.text);
		});
	}
	
	// Update is called once per frame

}
