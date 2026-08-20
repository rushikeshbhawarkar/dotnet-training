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

            return doctors.Select(d => new DoctorDto
            {
                DoctorId = d.DoctorId,
                Name = d.Name,
                Specialization = d.Specialization,
                Email = d.Email,
                Phone = d.Phone,
                DepartmentId = d.DepartmentId
            }).ToList();
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
                DoctorId = doctor.DoctorId,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DepartmentId = doctor.DepartmentId
            };
        }

        public DoctorDto Add(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Specialization = doctorDto.Specialization,
                Email = doctorDto.Email,
                Phone = doctorDto.Phone,
                DepartmentId = doctorDto.DepartmentId
            };

            var addedDoctor = _repository.Add(doctor);

            doctorDto.DoctorId = addedDoctor.DoctorId;

            return doctorDto;
        }

        public DoctorDto? Update(int id, DoctorDto doctorDto)
        {
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

            return new DoctorDto
            {
                DoctorId = updatedDoctor.DoctorId,
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