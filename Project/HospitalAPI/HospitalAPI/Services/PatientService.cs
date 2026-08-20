using HospitalAPI.DTOs;
using HospitalAPI.Model;
using HospitalAPI.Repositories;

namespace HospitalAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public List<PatientDto> GetAll()
        {
            var patients = _repository.GetAll();

            var patientDtos = patients.Select(patient => new PatientDto
            {
                Id = patient.PatientId, // Maps PatientId -> Id
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Email = patient.Email,
                Phone = patient.Phone,
                Address = patient.Address
            }).ToList();

            return patientDtos;
        }

        public PatientDto? GetById(int id)
        {
            var patient = _repository.GetById(id);

            if (patient == null)
            {
                return null;
            }

            var patientDto = new PatientDto
            {
                Id = patient.PatientId, // Maps PatientId -> Id
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Email = patient.Email,
                Phone = patient.Phone,
                Address = patient.Address
            };

            return patientDto;
        }

        public PatientDto Add(PatientDto patientDto)
        {
            // DTO → Model
            var patient = new Patient
            {
                Name = patientDto.Name,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Email = patientDto.Email,
                Phone = patientDto.Phone,
                Address = patientDto.Address
            };

            // Business rule
            if (patient.DateOfBirth > DateTime.Now)
            {
                throw new Exception("Date of birth cannot be in the future.");
            }

            // Model → Repository
            var savedPatient = _repository.Add(patient);

            // Model → DTO
            var result = new PatientDto
            {
                Id = savedPatient.PatientId, // Maps PatientId -> Id
                Name = savedPatient.Name,
                DateOfBirth = savedPatient.DateOfBirth,
                Gender = savedPatient.Gender,
                Email = savedPatient.Email,
                Phone = savedPatient.Phone,
                Address = savedPatient.Address
            };

            return result;
        }

        public PatientDto? Update(int id, PatientDto patientDto)
        {
            // DTO → Model
            var patient = new Patient
            {
                PatientId = id, // Maps id parameter -> PatientId
                Name = patientDto.Name,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Email = patientDto.Email,
                Phone = patientDto.Phone,
                Address = patientDto.Address
            };

            if (patient.DateOfBirth > DateTime.Now)
            {
                throw new Exception("Date of birth cannot be in the future.");
            }

            var updatedPatient = _repository.Update(id, patient);

            if (updatedPatient == null)
            {
                return null;
            }

            // Model → DTO
            return new PatientDto
            {
                Id = updatedPatient.PatientId, // Maps PatientId -> Id
                Name = updatedPatient.Name,
                DateOfBirth = updatedPatient.DateOfBirth,
                Gender = updatedPatient.Gender,
                Email = updatedPatient.Email,
                Phone = updatedPatient.Phone,
                Address = updatedPatient.Address
            };
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}