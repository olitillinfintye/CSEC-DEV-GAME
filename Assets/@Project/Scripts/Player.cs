using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
	
	public GameObject m_playerHitPrefab;

	
	public AudioClip m_jumpClip;

	
	public AudioClip m_hitClip;

	
	public bool IsSkipJumpSe;

	
	public void Dead()
	{
		
		gameObject.SetActive( false );

		
		var cameraShake = FindObjectOfType<CameraShaker>();

		
		cameraShake.Shake();

		
		Invoke( "OnRetry", 2 );

		
		Instantiate
		(
			m_playerHitPrefab,
			transform.position,
			Quaternion.identity
		);

		
		var audioSource = FindObjectOfType<AudioSource>();
		audioSource.PlayOneShot( m_hitClip );
	}

	
	private void OnRetry()
	{
		
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}

	
	private void Awake()
	{
		
		var motor = GetComponent<PlatformerMotor2D>();

		
		motor.onJump += OnJump;
	}

	
	private void OnJump()
	{
		
		if ( IsSkipJumpSe )
		{
			
			IsSkipJumpSe = false;
		}
		
		else
		{
			
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_jumpClip );
		}
	}
}