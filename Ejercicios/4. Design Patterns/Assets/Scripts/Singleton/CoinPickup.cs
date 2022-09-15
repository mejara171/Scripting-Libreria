using UnityEngine;

namespace Patterns
{
	public class CoinPickup : MonoBehaviour 
	{
		public string coinTag;
		public int pointsPerCoin;

		private void OnTriggerEnter2D (Collider2D other)
		{
			if (other.CompareTag (coinTag))
			{
				Score.Instance.AddPoints (pointsPerCoin);
				Destroy (other.gameObject);
			}
		}
	}
}