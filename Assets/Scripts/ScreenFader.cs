using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration = 0.5f;
    [SerializeField] CinemachineCamera vcam;

    //CinemachinePositionComposer positionComposer;
    //Vector3 originalDamping;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        //transposer = vcam.GetCinemachineComponent<CinemachinePositionComposer>();
        //originalDamping = new Vector3(transpose.xdamping, transposer.ydamping, transposer.zdamping);
    }

    async Task Fade(float targetTransparency) 
    {
        float start = canvasGroup.alpha, t = 0;
        while (t < fadeDuration) 
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, targetTransparency, t / fadeDuration);
            await Task.Yield();
        }
        canvasGroup.alpha = targetTransparency;
    }

    public async Task FadeOut() 
    {
        await Fade(1); //Fade to black
    }

    public async Task FadeIn()
    {
        await Fade(0); //Fade to transparent
    }
}
