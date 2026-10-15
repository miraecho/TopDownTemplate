using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration = 0.5f;
    [SerializeField] CinemachineCamera vcam;

    CinemachinePositionComposer transposer;
    Vector3 originalDamping;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (vcam != null) 
        {
            transposer = vcam.GetComponent<CinemachinePositionComposer>();
            if (transposer != null) 
            {
                originalDamping = new Vector3(transposer.Damping.x, transposer.Damping.y, transposer.Damping.z);
            }
        }

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
        vcam.PreviousStateIsValid = false;

    }

    public async Task FadeIn()
    {
        await Fade(0); //Fade to transparent
    }

    void SetDamping(Vector3 d) 
    {
        if (!transposer) return;
        transposer.Damping.x = d.x;
        transposer.Damping.y = d.y;
        transposer.Damping.z = d.z;
    }
}
