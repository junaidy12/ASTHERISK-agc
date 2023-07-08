using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        On,
        Off,
        Blink
    }

    [SerializeField] Collider ball;
    [SerializeField] MaterialSetter material;

    [SerializeField] Color onMaterial;
    [SerializeField] Color offMaterial;

    private SwitchState state;
    

    private void Start()
    {
        material.Setup(gameObject);
        state = SwitchState.Off;
        SetMaterial(false);
    }
    void SetMaterial(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            material.SetAllRenderersColor(onMaterial, true, 1.5f);
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            material.SetAllRenderersColor(offMaterial, false, 0);
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    void Toggle()
    {
        if(state == SwitchState.On)
        {
            SetMaterial(false);
        }
        else
        {
            SetMaterial(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == ball)
        {
            Toggle();
        }
    }

    IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        for (int i = 0; i < times; i++)
        {
            material.SetAllRenderersColor(onMaterial, true, 1.5f);
            yield return new WaitForSeconds(.5f);
            material.SetAllRenderersColor(offMaterial, false, 0);
            yield return new WaitForSeconds(.5f);
        }
        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }
    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
