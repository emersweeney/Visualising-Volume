using System.Collections;
using UnityEngine;

/** FADER SCRIPT FOR INSTRUCTION TEXT - ADD TO MAIN CAMERA **/
public class UIFader : MonoBehaviour
{
    public void fadeIn(CanvasGroup canvasGroup){
        StartCoroutine(fade(canvasGroup, canvasGroup.alpha, 1));
    }

    public void fadeOut(CanvasGroup canvasGroup){
        StartCoroutine(fade(canvasGroup, canvasGroup.alpha, 0));
    }
    private IEnumerator fade(CanvasGroup canvasGroup, float start, float end, float lerpTime = 0.5f){
        float lerpStartTime = Time.time;
        float passedTime = Time.time - lerpStartTime;
        float percentComplete = passedTime/lerpTime;

        while (true){
            passedTime = Time.time - lerpStartTime;
            percentComplete = passedTime/lerpTime;
            float currentAlpha = Mathf.Lerp(start, end, percentComplete);
            canvasGroup.alpha = currentAlpha;
            if (percentComplete >= 1) break;
            yield return new WaitForEndOfFrame();
        }
    }
}
