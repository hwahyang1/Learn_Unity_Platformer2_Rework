using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Managers
 * 
 */
namespace _20220531_Platform2Rework.GameScene.Managers
{
	/*
	 * [Enum] ItemCode
	 * 게임 내에서 사용되는 아이템의 목록을 정의합니다.
	 */
	public enum ItemCode
	{
		None,
		Book,
		Gear,
		Envelop,
		Ruby,
		Emerald
	}

	/*
	 * [Class] ItemManager
	 * 게임 내에서 사용되는 아이템의 목록을 관리합니다.
	 */
	public class ItemManager : MonoBehaviour
	{
		private static ItemManager instance = null;

		public static ItemManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<ItemManager>();

					if (instance == null)
					{
						instance = new GameObject("ItemManager").AddComponent<ItemManager>();
					}
				}

				return instance;
			}

			/*set
			{
				instance = value;
			}*/
		}

		private void Awake()
		{
			ItemManager[] managers = FindObjectsOfType<ItemManager>();

			if (managers.Length != 1) // 0이 될수는 없음 (최소한 자기 자신은 있기 때문)
			{
				Destroy(gameObject);
				return;
			}

			DontDestroyOnLoad(gameObject);
		}

		[SerializeField, Tooltip("ItemCode와 동일한 순서로 항목을 입력하세요.")]
		private List<string> itemNames = new List<string>();
		[SerializeField, Tooltip("ItemCode와 동일한 순서로 항목을 입력하세요.")]
		private List<Sprite> itemImages = new List<Sprite>();

		/*
		 * [Method] GetItemName(ItemCode item): string
		 * 입력된 ItemCode의 이름을 반환합니다.
		 * 
		 * <ItemCode item>
		 * 반환을 원하는 ItemCode를 입력합니다.
		 * 
		 * <RETURN: string>
		 * 아이템의 이름을 반환합니다.
		 */
		public string GetItemName(ItemCode item)
		{
			return itemNames[(int)item];
		}

		/*
		 * [Method] GetItemImage(ItemCode item): Sprite
		 * 입력된 ItemCode의 이미지를 반환합니다.
		 * 
		 * <ItemCode item>
		 * 반환을 원하는 ItemCode를 입력합니다.
		 * 
		 * <RETURN: Sprite>
		 * 아이템의 Sprite를 반환합니다.
		 */
		public Sprite GetItemImage(ItemCode item)
		{
			return itemImages[(int)item];
		}
	}
}
