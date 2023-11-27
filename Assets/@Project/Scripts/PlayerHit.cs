using UnityEngine;


public class PlayerHit : MonoBehaviour
{
	
	public Vector3 m_velocity = new Vector3( 0, 15, 0 );

	
	public float m_gravity = 30;

	
	private void Update()
	{
		
		transform.localPosition += m_velocity * Time.deltaTime;

		
		m_velocity.y -= m_gravity * Time.deltaTime;
	}
}