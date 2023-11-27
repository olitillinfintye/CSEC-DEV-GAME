using UnityEngine;

public class Background : MonoBehaviour
{
	public Vector2 m_speed;

	
	private void Update()
	{
		
		var spriteRenderer = GetComponent<SpriteRenderer>();

		
		var material = spriteRenderer.material;

		material.mainTextureOffset += m_speed * Time.deltaTime;
	}
}