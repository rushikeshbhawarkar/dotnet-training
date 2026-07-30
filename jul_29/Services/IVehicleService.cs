using jul_29.Model;

namespace jul_29.Services
{
    public interface IVehicleService
    {
       
            List<Vehicle> GetVehicles();

            Vehicle? GetVehicleById(int id);

            Vehicle AddVehicle(Vehicle vehicle);

            bool UpdateVehicle(int id, Vehicle vehicle);
        }
    }

