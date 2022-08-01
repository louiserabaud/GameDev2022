using UnityEngine;
using System.Collections;

// Game States
public enum GameState { INTRO, MAIN_MENU, PAUSED, GAME, CREDITS, HELP }

public delegate void OnStateChangeHandler();

public class GameManager: Object {
	protected GameManager() {}
	private static GameManager instance = null;
	public event OnStateChangeHandler OnStateChange;
	public  GameState gameState { get; private set; }

	public static GameManager Instance{
		get {
			if (GameManager.instance == null){
				GameManager.instance = new GameManager();
				DontDestroyOnLoad(GameManager.instance);
			}
			return GameManager.instance;
		}

	}

	public void SetGameState(GameState state){
		this.gameState = state;
		OnStateChange();
	}

	public void OnApplicationQuit(){
		GameManager.instance = null;
	}

}