using System;
using Microsoft.Extensions.DependencyInjection;
using JarvisFT.MontyHallParadox.Services;
using JarvisFT.MontyHallParadox.interfaces;

namespace JarvisFT.MontyHallParadox
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMontyHall, MontyHall>()
                .BuildServiceProvider();


            var montyService = serviceProvider.GetService<IMontyHall>();

            Random random = new Random();
            int wins   = 0;
            int losses = 0;

            for (int i = 0; i < 1000000; i++)
            {

                bool result = montyService.Play(random.Next(3));

                if (result) 
                    wins++;
                else
                    losses++;
            }

            Console.WriteLine("Wins: {0}%",  wins * 100 / (wins + losses));
        }

    }
    
}
