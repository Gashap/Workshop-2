using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class NewBehaviourScript : MonoBehaviour
{

	public AudioClip GoodSpeak;
	public AudioClip NormalSpeak;
	public AudioClip BadSpeak;
	private AudioSource selectAudio;
    private Dictionary<string, int> dataSet = new Dictionary<string, int>();
    private bool statusStart = false;
	private int i = 1;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(GoogleSheets());
	}

	// Update is called once per frame
	void Update()
	{
        if (i > dataSet.Count) return;

        if (dataSet["Res_" + i.ToString()] >= 100 & statusStart == false & i <= dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioGood());
            Debug.Log(dataSet["Res_" + i.ToString()]);
        }

        if (dataSet["Res_" + i.ToString()] >= 0 & dataSet["Res_" + i.ToString()] < 100 & statusStart == false & i <= dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioNormal());
            Debug.Log(dataSet["Res_" + i.ToString()]);
        }

        if (dataSet["Res_" + i.ToString()] < 0 & statusStart == false & i <= dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioBad());
            Debug.Log(dataSet["Res_" + i.ToString()]);
        }
    }

    IEnumerator GoogleSheets()
	{
		UnityWebRequest curentResp = UnityWebRequest.Get(
            //"https://sheets.googleapis.com/v4/spreadsheets/1TX5qwuxVwlZBbL9ujdgSjbye4QM2V0DlaSoI5HjsSSc/values/Лист1?key=AIzaSyAuwi0ETN-WvBC6MgMrkhvN6evM4p6UMYM");
            "https://sheets.googleapis.com/v4/spreadsheets/1v71SE_Vm_f_ZZyP7X1RBMFwWsIxJbkU6vHCb_LhmTzU/values/Лист1?key=AIzaSyBeYkHUGwGQx-g7E_1TUtERUr6tEGPcw9w");
        yield return curentResp.SendWebRequest();
        string rawResp = curentResp.downloadHandler.text;
        var rawJson = JSON.Parse(rawResp);
        foreach (var itemRawJson in rawJson["values"])
        {
            var parseJson = JSON.Parse(itemRawJson.ToString());
            var selectRow = parseJson[0].AsStringList;
            dataSet.Add(("Res_" + selectRow[0]), int.Parse(selectRow[3]));
        }
    }

	IEnumerator PlaySelectAudioGood()
	{
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
		selectAudio.clip = GoodSpeak;
		selectAudio.Play();
		yield return new WaitForSeconds(3);
		statusStart = false;
		i++;
	}

	IEnumerator PlaySelectAudioNormal()
	{
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
		selectAudio.clip = NormalSpeak;
		selectAudio.Play();
		yield return new WaitForSeconds(3);
		statusStart = false;
		i++;
	}

	IEnumerator PlaySelectAudioBad()
	{
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
		selectAudio.clip = BadSpeak;
		selectAudio.Play();
		yield return new WaitForSeconds(4);
		statusStart = false;
		i++;
	}
}
