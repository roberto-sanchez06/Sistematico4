using PepitoSchoolDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.AppCore.Interfaces
{
    public interface IEstudianteService : IService<Estudiante>
    {
        Estudiante FindById(int id);
        double CalcularPromedio(Estudiante estudiante);
        Estudiante FindByEmail(string email);
        Estudiante FindByPhone(string phone);
        Estudiante FindByCarnet(string carnet);
    }
}
