namespace Patterns.Behavior.Memento
{
    class Hero
    {
        private int patrons = 10;
        private int lives = 5;

        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("Shoot. Patrons count {0}", patrons);
            }
            else
                Console.WriteLine("No patrons");
        }
        public HeroMemento SaveState()
        {
            Console.WriteLine("Saving game. Params: {0} patrons, {1} lifes", patrons, lives);
            return new HeroMemento(patrons, lives);
        }

        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Restoring game. Params: {0} patrons, {1} lifes", patrons, lives);
        }
    }
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
