using EFcoreWebAPi.Models;

namespace EFcoreWebAPi.Services;

public interface IDoctor
{
    Task<bool> CreateDoctor(Doctors doctor);
    Task<bool> UpdateDoctor(Doctors doctor);
    Task<bool> DeleteDoctor(int id);
    Task<Doctors> GetDoctorById(int id);
    Task<IEnumerable<Doctors>> GetAllDoctors();
}