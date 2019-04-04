using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class CurvedWorld : MonoBehaviour
{
    [SerializeField]
    private float curvature = 2;

    [SerializeField]
    [Range(0, 1)]
    private float trimming = 0.3f;

    public static void SetValues(float curvature, float trimming)
    {
        Shader.SetGlobalFloat("_Curvature", curvature);
        Shader.SetGlobalFloat("_Trimming", Mathf.Clamp01(trimming));
    }

#if !UNITY_EDITOR
    // Use this for initialization
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        SetValues(curvature, trimming);
    }
#endif

#if UNITY_EDITOR
    // Update is called once per frame
    private void Update()
    {
        SetValues(curvature, trimming);
    }
#endif
}