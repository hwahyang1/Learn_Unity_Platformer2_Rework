using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Props
 * EventProp의 상호작용을 관리합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Props
{
	/*
	 * [Class] Lantern
	 * 랜턴의 상호작용을 관리합니다.
	 */
	public class Lantern : EventProp
	{
		[SerializeField]
		private GameObject removeObject;

		[Header("해당 스크립트에서 giveItem 변수는 사용되지 않습니다!!!!")]
		[SerializeField]
		private bool dummy;

		public override void OnInteract()
		{
			if (takeItem.Length == 0)
			{
				script.PrintScript(new string[] { "평범한 랜턴이다." });
				return;
			}

			if (isUsed)
			{
				script.PrintScript(new string[] { "랜턴 안의 기계장치는 정상적으로 작동하고 있는 듯 하다." });
			}
			else
			{
				int response = playerInventory.TakeItem(takeItem);
				if (response == 0)
				{
					script.PrintScript(new string[] { "랜턴 안에 " + getItemNames(takeItem) + "(을)를 끼워넣자 무언가 큰 소리가 났다!", "계단을 막고 있던 바위가 사라졌다!" });

					Destroy(removeObject);

					isUsed = true;
				}
				else
				{
					script.PrintScript(new string[] { "평범한 랜턴이다.\n...........................자세히 살펴보니 무언가 열 수 있는 틈이 있다!", "안쪽에 " + getItemNames(takeItem) + "(이)가 빠져있는 것 같다.\n주변에서 구할 수 있지 않을까?" });
				}
			}
		}
	}
}
