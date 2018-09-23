using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This is the Editor base; it's used for most if not all of the Dialogue Editor application
/// </summary>
public class EditorBase : MonoBehaviour {
	[Header ("=== [ Runtime ] ====")]
	public LineObject ActiveLine;
	public DialogueFile.DialogueLine aLine;
	public InputField ActiveLineDialogue;
	public Transform DialogueEntryList, EventList;

	[Space]
	[Header ("=== [ Setup ] ===")]
	public Text ErrorMessage;
	public Button DialogueEntryBtn;
	DialogueFile dFile;
	// Use this for initialization
	void Start () {

	}

	public void LoadJSON (string json) {
		try { JsonUtility.FromJsonOverwrite (json, dFile); } catch (System.Exception ex) {
			Debug.LogException (ex);
			ShowError (ex.Message);
		}
		if (dFile != null) {

		}

	}

	public void ResetEntryList () {
		for (int i = 0; i < DialogueEntryList.childCount; i++) {
			Destroy (DialogueEntryList.GetChild (i).gameObject);
		}
	}

	public void SaveLine () {
		ActiveLine.Line.dialogue = ActiveLineDialogue.text;
		ActiveLine.Line.userData = "";
	}

	public void ShowError (string err) {
		ErrorMessage.text = err;
		ErrorMessage.transform.parent.gameObject.SetActive (true);
	}

}