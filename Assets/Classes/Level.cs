namespace Classes {
    public class Level {
        private Wave[] _waves;

        public Level(Wave[] waves) {
            _waves = waves;
        }

        public Wave[] Waves => _waves;
    }
}