using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StageManager : MonoBehaviour
{
    public TMP_Text countDownText;
    public int remainTime = 3;
    public AudioSource audioSource;
    public AudioClip countDownClip;
    public AudioClip startClip;
    public AudioClip earlyStartClip;
    public KartMove kartMove;
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
            //yield return new WaitForSeconds(1); // 위와 같은 의미.
        }

        countDownText.text = "Start!";
        kartMove.enabled = true;
        audioSource.PlayOneShot(startClip);
    }

    float nextEnableTime;
    private void Update()
    {
        if (kartMove.enabled)
            return;

        if (nextEnableTime > Time.time)
            return;

        if (Input.GetAxis("Vertical") > 0)
        {
            audioSource.PlayOneShot(earlyStartClip);
            nextEnableTime += 2;
        }
    }
}
