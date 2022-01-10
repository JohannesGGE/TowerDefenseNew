using System.Collections;
using Classes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TestsPlayMode {
    public class BackBoneTests {
        private LevelManager _levelManager;
        private GameManager _gameManager;
        
        [SetUp]
        public void Setup() {
            _levelManager = LevelManager.GetInstance();
            _gameManager = GameManager.GetInstance();
        }
        
        [TearDown]
        public void Teardown() {
            
        }
        
        [UnityTest]
        public IEnumerator LevelManagerInit() {
            
            Assert.IsNotNull(_levelManager.Levels);
            
            foreach(Level level in _levelManager.Levels) {
                Assert.IsNotNull(level.Waves);
            }
            
            Assert.Greater(_levelManager.Levels.Count, 0);
            Assert.AreEqual(0, _levelManager.Levels[0].Stars);
            Assert.AreEqual(true, _levelManager.Levels[0].Unlocked);
            
            Assert.AreEqual(0, _levelManager.Levels[1].Stars);
            Assert.AreEqual(false, _levelManager.Levels[1].Unlocked);
            
            _levelManager.LoadLevelStatus();
            
            Assert.Greater(_levelManager.Levels.Count, 0);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator GameManagerInit() {
            
            _gameManager.ResetGameManager();
            _gameManager.PrepareLevel(_levelManager.Levels[0]);
            
            Assert.NotNull(_gameManager.Level);
            Assert.AreEqual(0, _gameManager.Coins);
            Assert.AreEqual(100, _gameManager.Lives);
            Assert.AreEqual(false, _gameManager.AllEnemySpawned);
            Assert.AreEqual(false, _gameManager.LastEnemyKilled);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator GamePause() {
            Assert.AreEqual(true, _gameManager.Paused);
            _gameManager.StartGame();
            Assert.AreEqual(false, _gameManager.Paused);
            _gameManager.PauseGame();
            Assert.AreEqual(true, _gameManager.Paused);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator GameSetCoinsAndLives() {
            _gameManager.AddCoins(50);
            _gameManager.AddCoins(50);
            
            Assert.AreEqual(100, _gameManager.Coins);
            _gameManager.ReduceCoins(200);
            Assert.AreEqual(-100, _gameManager.Coins);
            _gameManager.ReduceLives(20);
            Assert.AreEqual(80, _gameManager.Lives);
            
            yield return null;
        }
    }
}