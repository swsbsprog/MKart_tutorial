using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StageManager : MonoBehaviour
{
    public TMP_Text countDownText;
    public TMP_Text playTimeText;
    public int remainTime = 3;
    public AudioSource audioSource;
    public AudioClip countDownClip;
    public AudioClip startClip;
    public AudioClip earlyStartClip;
    public KartMove kartMove;
    public MeshRenderer[] trafficLight;
    public Color trafficLightStartColor = Color.green;
    private IEnumerator Start()
    {
        var waitTime = new WaitForSeconds(1);
        kartMove.enabled = false;
        while (remainTime > 0)
        {
            countDownText.text = remainTime.ToString(); // 3
            remainTime--;
            audioSource.PlayOneShot(countDownClip);
            yield return waitTime; 
            //yield return new WaitForSeconds(1); // 같은 의미.
        }
        countDownText.text = "Start!";
        kartMove.enabled = true;
        audioSource.PlayOneShot(startClip);
        startTime = Time.time;
        isStart = true;
        foreach (var light in trafficLight)
            light.material.color = trafficLightStartColor;

        yield return waitTime;
        countDownText.gameObject.SetActive(false);
    }

    float nextEnableTime;
    private float startTime;
    public bool isStart; 

    private void Update()
    {
        // 스타하고 난 다음 표시.
        if(isStart)
            playTimeText.text = (Time.time - startTime).ToString("F3"); //진행된 시간

        // 스타트 하고 나면 아래로 진행 안됨.
        if (isStart) return;

        if (nextEnableTime > Time.time) return;

        if (Input.GetAxis("Vertical") > 0)
        {
            audioSource.PlayOneShot(earlyStartClip);
            nextEnableTime += 2;
        }
    }
}
