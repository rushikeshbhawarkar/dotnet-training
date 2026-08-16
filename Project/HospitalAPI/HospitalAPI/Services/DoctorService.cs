using HospitalAPI.DTOs;
using HospitalAPI.Model;
using HospitalAPI.Repositories;

namespace HospitalAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public List<DoctorDto> GetAll()
        {
            var doctors = _repository.GetAll();

            var doctorDtos = doctors.Select(doctor => new DoctorDto
            {
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DepartmentId = doctor.DepartmentId
            }).ToList();

            return doctorDtos;
        }

        public DoctorDto? GetById(int id)
        {
            var doctor = _repository.GetById(id);

            if (doctor == null)
            {
                return null;
            }

            return new DoctorDto
            {
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DepartmentId = doctor.DepartmentId
            };
        }

        public DoctorDto Add(DoctorDto doctorDto)
        {
            // DTO → Model

            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Specialization = doctorDto.Specialization,
                Email = doctorDto.Email,
                Phone = doctorDto.Phone,
                DepartmentId = doctorDto.DepartmentId
            };

            // Model → Repository

            var savedDoctor = _repository.Add(doctor);

            // Model → DTO

            return new DoctorDto
            {
                Name = savedDoctor.Name,
                Specialization = savedDoctor.Specialization,
                Email = savedDoctor.Email,
                Phone = savedDoctor.Phone,
                DepartmentId = savedDoctor.DepartmentId
            };
        }

        public DoctorDto? Update(int id, DoctorDto doctorDto)
        {
            // DTO → Model

            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Specialization = doctorDto.Specialization,
                Email = doctorDto.Email,
                Phone = doctorDto.Phone,
                DepartmentId = doctorDto.DepartmentId
            };

            var updatedDoctor = _repository.Update(id, doctor);

            if (updatedDoctor == null)
            {
                return null;
            }

            // Model → DTO

            return new DoctorDto
            {
                Name = updatedDoctor.Name,
                Specialization = updatedDoctor.Specialization,
                Email = updatedDoctor.Email,
                Phone = updatedDoctor.Phone,
                DepartmentId = updatedDoctor.DepartmentId
            };
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}