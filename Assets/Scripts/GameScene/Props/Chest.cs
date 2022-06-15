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
	 * [Class] Chest
	 * 상자, 항아리 등의 상호작용을 관리합니다.
	 */
	public class Chest : EventProp
	{
		[SerializeField]
		private string propName = "상자";

		[Header("해당 스크립트에서 takeItem 변수는 사용되지 않습니다!!!!")]
		[SerializeField]
		private bool dummy;

		public override void OnInteract()
		{
			if (isUsed)
			{
				script.PrintScript(new string[] { propName + " 안에 다른 물건은 없는 듯 하다..." });
			}
			else
			{
				if (giveItem.Length == 0)
				{
					script.PrintScript(new string[] { "아무것도 들어있지 않다.\n어쩌다가 생긴 " + propName + "일까?" });
					isUsed = true;
				}
				else
				{
					int response = playerInventory.GiveItem(giveItem);
					if (response == 0)
					{
						script.PrintScript(new string[] { propName + " 안에서 " + getItemNames(giveItem) + "(을)를 획득했다!" });
						isUsed = true;
					}
					else
					{
						script.PrintScript(new string[] { propName + " 안에 무언가가 있다!\n하지만 가방에 충분한 공간이 없는 듯 하다..." });
					}
				}
			}
		}
	}
}
