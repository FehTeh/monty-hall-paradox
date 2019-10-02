using System;
using JarvisFT.MontyHallParadox.interfaces;

namespace JarvisFT.MontyHallParadox.Services
{
    public class MontyHall : IMontyHall
    {
        private Random _random;

        public MontyHall()
        {
            _random = new Random();
        }

        public bool Play(int pickedDoor)
        {
            int moneyDoor = _random.Next(3);
            int goatDoorToRemove = _random.Next(1);
            int leftGoat  = 0;
            int rightGoat = 2;

            switch (moneyDoor)
            {
                case 0: leftGoat = 1; rightGoat = 2; break;
                case 1: leftGoat = 0; rightGoat = 2; break;
                case 2: leftGoat = 0; rightGoat = 1; break;
            }

            int keepGoat = goatDoorToRemove == 0 ? rightGoat : leftGoat;

            return pickedDoor != keepGoat;
        }

    }
}