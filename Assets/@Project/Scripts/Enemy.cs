using PC2D;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	
	public GameObject m_hitPrefab;

	
	public AudioClip m_hitClip;

	
	private PlatformerMotor2D m_motor;

	
	private SpriteRenderer m_renderer;

	
	private BoxCollider2D m_collider;

	
	private void Awake()
	{
		
		m_motor = GetComponent<PlatformerMotor2D>();

		
		m_motor.normalizedXMovement = -1;

		
		m_renderer = GetComponent<SpriteRenderer>();

		
		m_renderer.flipX = false;

	
		m_collider = GetComponent<BoxCollider2D>();
	}

	// 毎フレーム呼び出される関数
	private void Update()
	{
		// 現在の進行方向を取得する
		var dir = 0 < m_motor.normalizedXMovement
			? Vector3.right
			: Vector3.left;

		// 進行方向にタイルマップが存在するかどうかを確認する
		var offset = m_collider.size.y * 0.5f;
		var hit = Physics2D.Raycast
		(
			transform.position - new Vector3( 0, offset, 0 ),
			dir,
			m_collider.size.x * 0.55f,
			Globals.ENV_MASK
		);

		// 進行方向にタイルマップが存在する場合
		if ( hit.collider != null )
		{
			// 移動方向を反転させる
			m_motor.normalizedXMovement = -m_motor.normalizedXMovement;

			// 画像の向きを反転させる
			m_renderer.flipX = !m_renderer.flipX;
		}
	}

	//他のオブジェクトと当たった時に呼び出される関数
	private void OnTriggerEnter2D( Collider2D other )
	{
		//名前に「Player」が含まれるオブジェクトと当たったら
		if ( other.name.Contains( "Player" ) )
		{
			// プレイヤーの移動を制御するコンポーネントを取得する
			var motor = other.GetComponent<PlatformerMotor2D>();

			// プレイヤーが落下中の場合
			if ( motor.IsFalling() )
			{
				// 敵を削除する
				Destroy( gameObject );

				// プレイヤーをジャンプさせる
				motor.ForceJump();

				// シーンに存在する CameraShaker スクリプトを検索する
				var cameraShake = FindObjectOfType<CameraShaker>();

				// CameraShaker を使用してカメラを揺らす
				cameraShake.Shake();

				// やられアニメーションのオブジェクトを生成する
				Instantiate( m_hitPrefab, transform.position, Quaternion.identity );

				// やられた時の SE を再生する
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_hitClip );

				// プレイヤーがジャンプした時の SE は再生しないようにする
				var player = other.GetComponent<Player>();
				player.IsSkipJumpSe = true;
			}
			// プレイヤーが落下中ではない場合
			else
			{
				// プレイヤーから Player スクリプトを取得する
				var player = other.GetComponent<Player>();

				// プレイヤーがやられた時に呼び出す関数を実行する
				player.Dead();
			}
		}
	}
}