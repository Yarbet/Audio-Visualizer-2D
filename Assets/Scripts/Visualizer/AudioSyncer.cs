using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Clase principal responsable de extraer los latidos de..
/// ..valor de espectro dado por AudioSpectrum.cs

public class AudioSyncer : MonoBehaviour {

    
    /// Heredar esto para causar algún comportamiento en cada latido
    
    public virtual void OnBeat()
	{
		Debug.Log("beat");
		m_timer = 0;
		m_isBeat = true;
	}

    /// Hereda esto para hacer lo que quieras en la función de actualización de Unity
    /// Típicamente, esto se usa para llegar a algún estado de reposo..
    /// ..definido por la clase secundaria
    
    public virtual void OnUpdate()
	{
        // actualizar valor de audio

        m_previousAudioValue = m_audioValue;
		m_audioValue = AudioSpectrum.spectrumValue;

        // si el valor de audio estuvo por debajo del sesgo durante este cuadro
        if (m_previousAudioValue > bias &&
			m_audioValue <= bias)
		{
            // si se alcanza el intervalo de tiempo mínimo
            if (m_timer > timeStep)
				OnBeat();
		}

        // si el valor de audio superó el sesgo durante este cuadro
        if (m_previousAudioValue <= bias &&
			m_audioValue > bias)
		{
            // si se alcanza el intervalo de tiempo mínimo
            if (m_timer > timeStep)
				OnBeat();
		}

		m_timer += Time.deltaTime;
	}

	private void Update()
	{
		OnUpdate();
	}

	public float bias;
	public float timeStep;
	public float timeToBeat;
	public float restSmoothTime;

	private float m_previousAudioValue;
	private float m_audioValue;
	private float m_timer;

	protected bool m_isBeat;
}
