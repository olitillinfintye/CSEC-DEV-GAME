using UnityEngine;


public class Trampoline : MonoBehaviour
{
	
	public float m_jumpHeight = 10;

	
	private void OnTriggerEnter2D( Collider2D other )
	{
		
		if ( other.name.Contains( "Player" ) )
		{
			
			var motor = other.GetComponent<PlatformerMotor2D>();

			
			motor.ForceJump( m_jumpHeight );

			
			var animator = GetComponent <Animator >();

			
			animator.Play( "Jump" );
		}
	}
}