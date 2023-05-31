using System;
using System.Collections.Generic;
using System.Linq;

namespace Top_Server_Players
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Work();
        }
    }

    class Player 
    {
        public Player(string name) 
        {
            int minLevel = 1;
            int maxLevel = 20;
            int minPower = 10;
            int maxPower = 100;
            Name= name;
            Level = UserUtils.GenerateRandomNumber(minLevel, maxLevel);
            Power = UserUtils.GenerateRandomNumber(minPower, maxPower);
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} .Уровень - {Level} . Сила - {Power} .");
        }
    }

    class Server 
    {
        private List<Player> _players = new List<Player>();

        public Server() 
        {
            CreatePlayers();
        }

        public void Work()
        {
            const string CommandDefineTopLevelPlayers = "1";
            const string CommandDefineTopPowerPlayers = "2";
            const string CommandExit = "3";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Все игроки на сервере: ");
                ShowAllPlayers();
                Console.WriteLine($"\nНажмите - {CommandDefineTopLevelPlayers}. Чтобы определить топ игроков по уровню.");
                Console.WriteLine($"Нажмите - {CommandDefineTopPowerPlayers}. Чтобы определить топ игроков по силе.");
                Console.WriteLine($"Нажмите - {CommandExit}. Чтобы завершить работу.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandDefineTopLevelPlayers:
                        DefineTopLevelPlayers();
                        break; 

                    case CommandDefineTopPowerPlayers:
                        DefineTopPowerPlayers();
                        break;

                        case CommandExit:
                            isWork = false; 
                        break;

                    default:
                        Console.WriteLine("Нет такой команды...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreatePlayers()
        {
            _players.Add(new Player("Артиллерист"));
            _players.Add(new Player("Тьма"));
            _players.Add(new Player("Ваня123"));
            _players.Add(new Player("Злодей"));
            _players.Add(new Player("НаГиБаТоР"));
            _players.Add(new Player("Чума"));
            _players.Add(new Player("Роэн"));
            _players.Add(new Player("Ботиран"));
            _players.Add(new Player("Зеле"));
            _players.Add(new Player("Стелла"));
        }

        private void DefineTopLevelPlayers() 
        {
            int quantityTopPlayers = 3;
            var topPlayers = _players.OrderByDescending(player => player.Level).ToList();

            for (int i = 0; i < quantityTopPlayers; i++)
            {
                Console.Write(i +1 + ") ");
                topPlayers[i].ShowInfo();
            }
        }

        private void DefineTopPowerPlayers() 
        {
            int quantityTopPlayers = 3;
            var topPlayers = _players.OrderByDescending(player => player.Power).ToList();

            for (int i = 0; i < quantityTopPlayers; i++)
            {
                Console.Write(i + 1 + ") ");
                topPlayers[i].ShowInfo();
            }
        }

        private void ShowAllPlayers()
        {
            foreach (Player player in _players)
            {
                player.ShowInfo();
            }
        }
    }

    class UserUtils
    {
        private static Random _random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
