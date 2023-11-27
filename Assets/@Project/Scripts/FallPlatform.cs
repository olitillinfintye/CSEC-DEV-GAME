using UnityEngine;


public class FallPlatform : MonoBehaviour
{
	
	public float m_speed = 0.3f;

	
	private bool m_isHit;

	
	private void Awake()
	{
		
		var motor = GetComponent<MovingPlatformMotor2D>();

		
		motor.onPlatformerMotorContact += OnContact;
	}

	
	private void OnContact( PlatformerMotor2D player )
	{
		
		if ( player.IsFalling() )
		{
			
			m_isHit = true;
		}
	}

	
	private void Update()
	{
		
		if ( m_isHit )
		{
			
			var motor = GetComponent<MovingPlatformMotor2D>();

			
			motor.velocity = Physics2D.gravity * m_speed;
		}
	}
}