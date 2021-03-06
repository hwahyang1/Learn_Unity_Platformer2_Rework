using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

using _20220531_Platform2Rework.GameScene.Props;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Player
 * 플레이어와 관련한 내용들을 정의합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Player
{
	/*
	 * [Class] PlayerInteract
	 * 플레이어의 상호작용 가능 여부를 관리합니다.
	 */
	public class PlayerInteract : MonoBehaviour
	{
		[ShowNonSerializedField]
		private bool _isInteractable = false;
		public bool isInteractable
		{
			get
			{
				return _isInteractable;
			}
			private set
			{
				_isInteractable = value;
			}
		}

		[ShowNonSerializedField]
		private GameObject interactableObject = null;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (isInteractable)
				{
					interactableObject.GetComponent<EventProp>().OnInteract();
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			ChageInteractable(true, collision);
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			ChageInteractable(false, collision);
		}

		/*
		 * [Method] ChageInteractable(bool interactable, Collider2D collision = null): void
		 * 플레이어의 상호작용 가능 여부를 정의합니다.
		 * 
		 * <bool interactable>
		 * 상호작용 가능 여부를 정의합니다.
		 * 
		 * <Collider2D collision = null>
		 * 상호작용이 가능한 GameObject를 담습니다.
		 */
		private void ChageInteractable(bool interactable, Collider2D collision)
		{
			if (collision.tag == "Interactable")
			{
				isInteractable = interactable;
				interactableObject = (interactable) ? collision.gameObject : null;
			}
		}
	}
}

