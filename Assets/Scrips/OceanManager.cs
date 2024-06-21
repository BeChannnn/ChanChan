using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : SingleTon<OceanManager>
{

    [SerializeField] private GameObject ocean;
    [SerializeField] private float wavePower = 2f;

    private Material _oceanMat;
    private Texture2D _oceanText;


    // Start is called before the first frame update
    void Start()
    {
        SetValue();
    }
    private void SetValue()
    {
        _oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        _oceanText = (Texture2D)_oceanMat.GetTexture("_mainText");
    }

    private void OnValidate()
    {
        if (!Application.isPlaying) return;
        if (ocean != null)
        {
            SetValue();
        }
        _oceanMat.SetFloat("_wavePower", wavePower);
    }

    public float GetWaveHeight(Vector3 point)
    {
        float waveHeight = _oceanText.GetPixelBilinear(point.x, point.z * Time.deltaTime).g * wavePower;
        return waveHeight;
    }
    // Update is called once per frame
    void Update()
    {

    }
}