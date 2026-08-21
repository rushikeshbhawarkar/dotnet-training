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
                Id = patient.PatientId,
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
                throw new KeyNotFoundException(
                    "Patient with the given ID was not found."
                );
            }

            return new PatientDto
            {
                Id = patient.PatientId,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Email = patient.Email,
                Phone = patient.Phone,
                Address = patient.Address
            };
        }

        public PatientDto Add(PatientDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Email = patientDto.Email,
                Phone = patientDto.Phone,
                Address = patientDto.Address
            };

            if (patient.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(
                    "Date of birth cannot be in the future."
                );
            }

            var savedPatient = _repository.Add(patient);

            return new PatientDto
            {
                Id = savedPatient.PatientId,
                Name = savedPatient.Name,
                DateOfBirth = savedPatient.DateOfBirth,
                Gender = savedPatient.Gender,
                Email = savedPatient.Email,
                Phone = savedPatient.Phone,
                Address = savedPatient.Address
            };
        }

        public PatientDto? Update(
            int id,
            PatientDto patientDto)
        {
            var patient = new Patient
            {
                PatientId = id,
                Name = patientDto.Name,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Email = patientDto.Email,
                Phone = patientDto.Phone,
                Address = patientDto.Address
            };

            if (patient.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(
                    "Date of birth cannot be in the future."
                );
            }

            var updatedPatient =
                _repository.Update(id, patient);

            if (updatedPatient == null)
            {
                throw new KeyNotFoundException(
                    "Patient with the given ID was not found."
                );
            }

            return new PatientDto
            {
                Id = updatedPatient.PatientId,
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
            var deleted = _repository.Delete(id);

            if (!deleted)
            {
                throw new KeyNotFoundException(
                    "Patient with the given ID was not found."
                );
            }

            return true;
        }
    }
}