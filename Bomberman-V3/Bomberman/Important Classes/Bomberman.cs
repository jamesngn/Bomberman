using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// This class functions as the Game Manager and is instantiate in the Game class.
    /// Contain three mains functions: Draw, Update and Control
    /// </summary>
    class Bomberman : IGameManager
    {
        private DrawManager drawManager;
        private CollisionManager collisionManager;
        private EnemyMovementHandler enemyMovementHandler;
        private ExplosionManager explosionManager;
        private Tile[,] map;
        private GameMode mode;
        /// <summary>
        /// Map, Players and Enemies are created in this constructor
        /// the manager classes are also instantiated
        /// </summary>
        /// <param name="w">
        /// Use this parameter to instantiate Floor class, it needs to know the window's width and height to create map
        /// </param>
        public Bomberman(Window w, GameMode gameMode)
        {
            Floor floor = new Floor(w, mode);
            map = floor.Map;
            mode = gameMode;
            Initialise();

            drawManager = new DrawManager();
            collisionManager = new CollisionManager();
            enemyMovementHandler = new EnemyMovementHandler();
            explosionManager = new ExplosionManager(map);
        }
        /// <summary>
        /// call draw manager class to execute the drawing on the list of gameobjects that is taken from GameObjectManager class.
        /// </summary>
        public void Draw()
        {
            List<GameObject> gameObjects = GameObjectManager.Instance().GameObjectsList;
            drawManager.Execute(gameObjects);
        }
        /// <summary>
        /// execute collision manager with list of gameobjects
        /// execute enemy movement with list of enemies
        /// execute explosion manager with list of bombs and explosions
        /// remove required game objects during the game
        /// </summary>
        public void Update()
        {
            List<GameObject> gameObjects = GameObjectManager.Instance().GameObjectsList;
            collisionManager.Execute(gameObjects);
            //---
            List<Enemy> enemies = GameObjectManager.Instance().EnemiesList;
            enemyMovementHandler.Execute(enemies);
            //--
            List<Bomb> bombs = GameObjectManager.Instance().BombsList;
            List<Explosion> explosions = GameObjectManager.Instance().ExplosionsList;
            explosionManager.Execute(bombs, explosions);
            //--
            GameObjectManager.Instance().RefreshObjectList();
            CheckWinOrLose();
        }
        /// <summary>
        /// execute command processor class to control the player movement and place bomb command
        /// </summary>
        public void Control()
        {
            CommandProcessor.Instance().Execute();
        }
        private void Initialise()
        {
            switch (mode)
            {
                case GameMode.ONEPLAYERVSBOT:
                    Factory.Instance().InstantiatePlayer("p1", mode);
                    Factory.Instance().InstantiateEnemies(map, 10);
                    break;
                case GameMode.TWOPLAYERSVSBOT:
                    Factory.Instance().InstantiatePlayer("p1", mode);
                    Factory.Instance().InstantiatePlayer("p2", mode);
                    Factory.Instance().InstantiateEnemies(map, 20);
                    break;
                case GameMode.PVP:
                    Factory.Instance().InstantiatePlayer("p1", mode);
                    Factory.Instance().InstantiatePlayer("p2", mode);
                    break;
                default:
                    break;
            }
        }
        private void CheckWinOrLose()
        {
            if (mode == GameMode.ONEPLAYERVSBOT || mode == GameMode.TWOPLAYERSVSBOT)
            {
                int remainingPlayer = GameObjectManager.Instance().PlayersList.Count;
                if (remainingPlayer == 0)
                {
                    Console.WriteLine("YOU LOST !");
                    Environment.Exit(0);
                }
                int remainingEnemy = GameObjectManager.Instance().EnemiesList.Count;
                if (remainingEnemy == 0)
                {
                    Console.WriteLine("YOU WON !");
                    Environment.Exit(0);
                }
            }
            else if (mode == GameMode.PVP)
            {
                int remainingPlayer = GameObjectManager.Instance().PlayersList.Count;
                if (remainingPlayer == 1)
                {
                    string playerWin = GameObjectManager.Instance().PlayersList[0].ID;
                    Console.WriteLine("Player " + playerWin + " WON !");
                    Environment.Exit(0);
                } 
                else if (remainingPlayer == 0)
                {
                    Console.WriteLine("You two TIED !");
                    Environment.Exit(0);
                }
            }
        }
    }
}
