using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(Camera))]
public class CameraEffects : MonoBehaviour {

    public static CameraEffects instance;

    Camera cam;

    void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        cam = GetComponent<Camera>();
    }

    public void chromatic_vignette()
    {
        StartCoroutine(doChrom());
    }

    IEnumerator doChrom()
    {
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 5;
        yield return new WaitForSeconds(0.5f);
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 3;
        yield return new WaitForSeconds(0.5f);
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 1;
        yield return new WaitForSeconds(0.5f);
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 3;
        yield return new WaitForSeconds(0.5f);
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 5;
        yield return new WaitForSeconds(0.5f);
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 3;
        yield return new WaitForSeconds(0.5f);
        cam.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = 0;
    }
}
