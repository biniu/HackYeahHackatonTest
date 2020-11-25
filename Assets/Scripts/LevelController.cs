﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	[SerializeField] private string _nextLevelName;

	private Monster[] _monsters;

	// OnEnable is called when the object becomes enabled and active.
	private void OnEnable()
	{
		_monsters = FindObjectsOfType<Monster>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (MonstersAreAllDead())
			GoToNextLevel();
	}

	private void GoToNextLevel()
	{
		Debug.Log("Go to level " + _nextLevelName);
		SceneManager.LoadScene(_nextLevelName);
	}

	private bool MonstersAreAllDead()
	{
		foreach (var monster in _monsters)
		{
			if (monster.gameObject.activeSelf)
				return false;
		}

		return true;
	}
}
