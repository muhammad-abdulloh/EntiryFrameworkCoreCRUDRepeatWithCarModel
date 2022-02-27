using System;
using System.Threading.Tasks;
using static System.Console;
#pragma warning disable
namespace RepeatGenericCrud
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ICarRepository car = new CarRepository();

            /** Create Done
            var entryCar = await car.CreateAsync(
                new Car 
                {
                    Name = "Lambarghini",
                    Model = "RedBull",
                    Year = 2020,
                    Color = "Yellow"
                }
            );
            */

            /** Get All Done*/
            var cars = await car.GetAllAsync();
            foreach (var item in cars)
            {
                Console.WriteLine(item.Name + " " + item.Model);
            }
            
            
            /** Get Done
            var getCar = await car.GetAsync( x => x.Id == 1);
            WriteLine(getCar.Name);
            */
            

            /** Update Done
            var enter = await car.UpdateAsync(
                new Car
                {
                    Id = 3,
                    Name = "Jiguli",
                    Model = "Lada",
                    Year = 1965,
                    Color = "White"
                }
            );

            WriteLine(enter.Name);
            */

            /** Delete Done
            bool deleted = await car.DeleteAsync(x => x.Id == 3);
            WriteLine(deleted);
            */

        }
    }
}

#pragma warning restore