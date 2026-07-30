using jul_29.Model;

namespace jul_29.Services
{
     public class VehicleService : IVehicleService
        {
            private static List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle { Id = 1, Name = "Civic", Price = 25000, Type = "Car", Brand = "Honda" },
            new Vehicle { Id = 2, Name = "Ninja 400", Price = 5500, Type = "Bike", Brand = "Kawasaki" }
        };

            public List<Vehicle> GetVehicles()
            {
                return vehicles;
            }

            public Vehicle? GetVehicleById(int id)
            {
                return vehicles.FirstOrDefault(v => v.Id == id);
            }

            public Vehicle AddVehicle(Vehicle vehicle)
            {
                vehicles.Add(vehicle);
                return vehicle;
            }

            public bool UpdateVehicle(int id, Vehicle updatedVehicle)
            {
                var existingVehicle = vehicles.FirstOrDefault(v => v.Id == id);
                if (existingVehicle == null)
                {
                    return false;
                }

                existingVehicle.Name = updatedVehicle.Name;
                existingVehicle.Price = updatedVehicle.Price;
                existingVehicle.Type = updatedVehicle.Type;
                existingVehicle.Brand = updatedVehicle.Brand;

                return true;
            }
        }
    }

