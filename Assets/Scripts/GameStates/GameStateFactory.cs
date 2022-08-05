using System;

public class GameStateFactory
{
    /// <summary>
    /// Creates the requested game state entity
    /// </summary>
    /// <param name="gameState">State we want to create</param>
    /// <returns>The requested game state entity</returns>
    public static void LoadState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
                MenuState.Instance.OnEnter();
                return;

            case GameState.Play:
                PlayState.Instance.OnEnter();
                return;

            default:
                return;
        }
    }
}
