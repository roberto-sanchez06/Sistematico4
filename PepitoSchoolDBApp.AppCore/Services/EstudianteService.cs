using PepitoSchoolDBApp.AppCore.Interfaces;
using PepitoSchoolDBApp.Domain.Entities;
using PepitoSchoolDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.AppCore.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IEstudianteRepository estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        public double CalcularPromedio(Estudiante estudiante)
        {
            return estudianteRepository.CalcularPromedio(estudiante);
        }

        public void Create(Estudiante t)
        {
            estudianteRepository.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            return estudianteRepository.Delete(t);
        }

        public Estudiante FindByCarnet(string carnet)
        {
            return estudianteRepository.FindByCarnet(carnet);
        }

        public Estudiante FindByEmail(string email)
        {
            return estudianteRepository.FindByEmail(email);
        }

        public Estudiante FindById(int id)
        {
            return estudianteRepository.FindById(id);
        }

        public Estudiante FindByPhone(string phone)
        {
            return estudianteRepository.FindByPhone(phone);
        }

        public List<Estudiante> GetAll()
        {
            return estudianteRepository.GetAll();
        }

        public int Update(Estudiante t)
        {
            return estudianteRepository.Update(t);
        }
    }
}
