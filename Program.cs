
var main = new Practical4.Sound.Pianino();
main.Main();


namespace Practical4.Sound
{
    public class Setting
    {
        //http://www.overcloser.narod.ru/notes/
        public int[] ContrActava = new int[] { 41, 43, 46, 49, 51, 55, 58, 61 };
        public int[] BigActava = new int[] { 65, 69, 73, 77, 82, 87, 92, 98, 103, 110, 116, 123 };
        public int[] SmallActava = new int[] { 130, 138, 146, 155, 164, 174, 185, 196, 207, 220, 233, 246 };
        public int[] FirstActava = new int[] { 261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 493 };
        public int[] SecondActava = new int[] { 523, 554, 587, 622, 659 };

        public IEnumerable<ConsoleKey> Keys = new List<ConsoleKey>
        {
            ConsoleKey.Q,
            ConsoleKey.W,
            ConsoleKey.E,
            ConsoleKey.R,
            ConsoleKey.T,
            ConsoleKey.Y,
            ConsoleKey.U,
            ConsoleKey.I,
            ConsoleKey.O,
            ConsoleKey.P,
            ConsoleKey.A,
            ConsoleKey.S
        };
        public IEnumerable<ConsoleKey> ButtonsActava = new List<ConsoleKey>
        {
            ConsoleKey.F1,
            ConsoleKey.F2,
            ConsoleKey.F3,
            ConsoleKey.F4,
            ConsoleKey.F5
        };
        public int Duration = 400;
    }
    public class Pianino
    {
        Setting? _setting { get; set; }
        public ConsoleKey? _activeF { get; set; }
        public ConsoleKey? _actava { get; set; }
       
        public void Main()
        {
            _setting = new Setting();
            if (_setting == null) return;
            RessetActave();
        }
        private void RessetActave()
        {
            while (true)
            {
                Console.WriteLine("Укажите актаву");
                ConsoleKey actava = Console.ReadKey().Key;
                if (_setting.ButtonsActava.Count(c => c == actava) > 0)
                {
                    _actava = actava;
                    PlayControll();
                    return;
                }
              else
                {
                    Console.WriteLine("Неправильная команда");
                }
             
            }
        }
        private void PlayControll()
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                return;
            }
            if (_setting.ButtonsActava.Count(c => c == key) > 0)
            {
                Console.Clear();
                _actava = key;
                PlayControll();
                return;
            }
            _activeF = key;
            PlaySoud(400);
        }
        private int GetIndex()
        {
            int getKey = 0;
            foreach (var elem in _setting.Keys)
            {
                if (elem.Equals(_activeF)) return getKey+1 ;
                getKey++;
            }
            return 0;
        }
        private int ProtectedInt(int[] actavaArray, int index )
        {
            if(actavaArray.Length <= index)
            {
                return actavaArray.Last();
            }
            return actavaArray[index];
        }
        private void PlaySoud(int duration)
        {
            int indexKey = GetIndex();
            if (indexKey == 0)
            {
                _activeF = Console.ReadKey().Key;
                PlayControll();
                return;
            }
            switch (_actava)
            {
                case ConsoleKey.F1:
                    Console.Beep(ProtectedInt(_setting.ContrActava, indexKey), duration);
                    break;
                case ConsoleKey.F2:
                    Console.Beep(ProtectedInt(_setting.BigActava, indexKey), duration);
                    break;
                case ConsoleKey.F3:
                    Console.Beep(ProtectedInt(_setting.SmallActava, indexKey), duration);
                    break;
                case ConsoleKey.F4:
                    Console.Beep(ProtectedInt(_setting.FirstActava, indexKey), duration);
                    break;
                case ConsoleKey.F5:
                    Console.Beep(ProtectedInt(_setting.SecondActava, indexKey), duration);
                    break;
            }
            PlayControll();
        }
    }
}


