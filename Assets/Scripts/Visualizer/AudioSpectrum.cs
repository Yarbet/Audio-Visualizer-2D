using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSpectrum : MonoBehaviour {

	private void Update()
    {
        // obtener los datos
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming);

        // asignar valor de espectro
        // verifiar si nuestro dato tiene algo(spectrumValue)
        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValue = m_audioSpectrum[0] * 100;
        }
    }

    private void Start()
    {
        /// inicializar el búfer
        m_audioSpectrum = new float[128];
    }

    // Este valor sirvió a AudioSyncer para la extracción de beats
    public static float spectrumValue {get; private set;}

    // La unidad llena esto para nosotros
    private float[] m_audioSpectrum;

}
