namespace Classes {
    public class Level {
        private Wave[] _waves;
        private int _stars;

        public Level(Wave[] waves) {
            _waves = waves;
            _stars = 0;
        }

        public Wave[] Waves => _waves;

        public int Stars {
            get => _stars;
            set => _stars = value;
        }
    }
}