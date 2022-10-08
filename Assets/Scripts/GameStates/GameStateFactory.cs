using System;

public class GameStateFactory
{
    /// <summary>
    /// Creates the requested game state entity
    /// </summary>
    /// <param name="gameState">State we want to create</param>
    /// <returns>The requested game state entity</returns>
    private static GameStateEntity _currentState = null;
    public static void LoadState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
            _currentState =  new MenuState();
                return;

            case GameState.Play:
            _currentState = new PlayState();
                return;

            default:
                return;
        }
    }
}
