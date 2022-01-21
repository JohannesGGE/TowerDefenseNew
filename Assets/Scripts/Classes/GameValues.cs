using static Classes.BirdLevel;
namespace Classes {
    public abstract class GameValues {
        
        
        // GameManager -------------------------------------------
        public const int LivesInitial = 100;
        public const int CoinsInitial = 500;
        public const bool PausedInitial = true;
        
        
        
        
        // Enemy -------------------------------------------
        public const float EnemyInitialSpeed = 5f;
        public const int ReducedSpeed = 2;

        public const int SmallBirdHealth = 50;
        public const int SmallBirdWorth = 10;
        public const int SmallBirdDamage = 1;

        public const int MediumBirdHealth = 75;
        public const int MediumBirdWorth = 25;
        public const int MediumBirdDamage = 5;

        public const int BigBirdHealth = 100;
        public const int BigBirdWorth = 50;
        public const int BigBirdDamage = 10;


        public const float TimeBetweenWaves = 5f;
        public const float CountdownBeforeFirstBird = 2f;
        
        
        
        
        
        // Tower -------------------------------------------

        public const float TowerTurnSpeed = 10f;

        public const int PriceBasicTower = 100;
        public const int PriceFireTower = 150;
        public const int PriceIceTower = 120;

        // Basic ----
        //Level 1
        public const int UpgradeCostBasicTower1 = 125;
        public const int DamageBasicTower1 = 5;
        public const float RangeBasicTower1 = 300f;
        public const float FireRateBasicTower1 = 1f;
        public const float FireCountdownBasicTower1 = 0f;
        
        //Level 2
        public const int UpgradeCostBasicTower2 = 150;
        public const int DamageBasicTower2 = 7;
        public const float RangeBasicTower2 = 300f;
        public const float FireRateBasicTower2 = 1f;
        public const float FireCountdownBasicTower2 = 0f;
        
        //Level 3
        public const int UpgradeCostBasicTower3 = 200; //überflüssig?
        public const int DamageBasicTower3 = 10;
        public const float RangeBasicTower3 = 300f;
        public const float FireRateBasicTower3 = 1f;
        public const float FireCountdownBasicTower3 = 0f;
        
        // Fire ----
        //Level 1
        public const int UpgradeCostFireTower1 = 175;
        public const int DamageFireTower1 = 3;
        public const float RangeFireTower1 = 300f;
        public const float FireRateFireTower1 = 1f;
        public const float FireCountdownFireTower1 = 0f;
        
        //Level 2
        public const int UpgradeCostFireTower2 = 200;
        public const int DamageFireTower2 = 5;
        public const float RangeFireTower2 = 300f;
        public const float FireRateFireTower2 = 1f;
        public const float FireCountdownFireTower2 = 0f;
        
        //Level 3
        public const int UpgradeCostFireTower3 = 250; //überflüssig? da Stufe 3 nicht upgegraded werden kann? 
        public const int DamageFireTower3 = 7;
        public const float RangeFireTower3 = 300f;
        public const float FireRateFireTower3 = 1f;
        public const float FireCountdownFireTower3 = 0f;
        
        // Ice ----
        //Level 1
        public const int UpgradeCostIceTower1 = 140;
        public const int DamageIceTower1 = 0;
        public const float RangeIceTower1 = 300f;
        public const float FireRateIceTower1 = 1f;
        public const float FireCountdownIceTower1 = 0f;
        public const float IceDelayIceTower1 = 0.2f;
        public const float IceDurationIceTower1 = 2f;
        
        //Level 2
        public const int UpgradeCostIceTower2 = 175;
        public const int DamageIceTower2 = 0;
        public const float RangeIceTower2 = 300f;
        public const float FireRateIceTower2 = 1f;
        public const float FireCountdownIceTower2 = 0f;
        public const float IceDelayIceTower2 = 0.15f;
        public const float IceDurationIceTower2 = 3f;
        
        //Level 3
        public const int UpgradeCostIceTower3 = 200; //überflüsssig? 
        public const int DamageIceTower3 = 0;
        public const float RangeIceTower3 = 300f;
        public const float FireRateIceTower3 = 1f;
        public const float FireCountdownIceTower3 = 0f;
        public const float IceDelayIceTower3 = 0.2f;
        public const float IceDurationIceTower3 = 5f;

        
        
        
        
        // Sting ---------------------------------------
        
        public const float StingSpeed = 800f;
        public const float StingTurnSpeed = 100f;
        
        
        
        
        // LevelMenu -------------------------------------------
        public const int LivesToGet1Star = 0;
        public const int LivesToGet2Star = 51;
        public const int LivesToGet3Star = 96;


        
        
        // Level (Wellen mit Enemys) -------------------------------------------
        public static Level GetLevel1() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            return new Level(new []{wave1, wave2}, true);
        }
        public static Level GetLevel2() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel3() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel4() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel5() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel6() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel7() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel8() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel9() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        public static Level GetLevel10() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small}, 1f);
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium}, 1f);
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Big, Big}, 2f);
            return new Level(new []{wave1, wave2, wave3}, false);
        }
        
        
    }
}