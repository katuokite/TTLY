﻿/*
 *
 *	Adventure Creator
 *	by Chris Burton, 2013-2018
 *	
 *	"ActionDocumentOpen.cs"
 * 
 *	This action makes a Document active for display in a Menu.
 * 
 */

using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionDocumentOpen : Action
	{

		public int documentID;
		public bool addToCollection = false;

		
		public ActionDocumentOpen ()
		{
			this.isDisplayed = true;
			category = ActionCategory.Document;
			title = "Open";
			description = "Openss a document, causing any Menu of Appear type: On Container to open.";
		}


		override public float Run ()
		{
			Document document = KickStarter.inventoryManager.GetDocument (documentID);

			if (document != null)
			{
				if (addToCollection)
				{
					KickStarter.runtimeDocuments.AddToCollection (document);
				}
				KickStarter.runtimeDocuments.OpenDocument (document);
			}

			return 0f;
		}
		

		#if UNITY_EDITOR

		override public void ShowGUI (List<ActionParameter> parameters)
		{
			documentID = InventoryManager.DocumentSelectorList (documentID);
			addToCollection = EditorGUILayout.Toggle ("Add to collection?", addToCollection);

			AfterRunningOption ();
		}


		override public string SetLabel ()
		{
			Document document = KickStarter.inventoryManager.GetDocument (documentID);
			if (document != null)
			{
				return " (" + document.Title + ")";
			}
			return string.Empty;
		}

		#endif
		
	}

}