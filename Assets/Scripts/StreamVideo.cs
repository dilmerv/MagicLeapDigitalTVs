using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(RawImage))]
public class StreamVideo : MonoBehaviour
{
    [SerializeField]
    private float waitToPlayForSeconds = 1.0f;

    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private RawImage rawImage;

    private void Start() => StartVideo();

    public void StartVideo() => StartCoroutine(PlayVideo());

    public void StopVideo() => Debug.Log("Not Implemented");

    private IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(waitToPlayForSeconds);

        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}
