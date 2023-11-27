using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
	
	public float m_duration = 0.25f;

	
	public float m_magnitude = 0.1f;

	
	public void Shake()
	{
		StartCoroutine( DoShake() );
	}

	
	private IEnumerator DoShake()
	{
		var pos = transform.localPosition;

		var elapsed = 0f;

	
		while ( elapsed < m_duration )
		{
		
			var x = pos.x + Random.Range( -1f, 1f ) * m_magnitude;
			var y = pos.y + Random.Range( -1f, 1f ) * m_magnitude;

			transform.localPosition = new Vector3( x, y, pos.z );

			
			elapsed += Time.deltaTime;

			
			yield return null;
		}

		
		transform.localPosition = pos;
	}
}