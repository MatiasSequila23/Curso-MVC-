using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DepartamentoDALC
    {
        public void Agregar(Departamento dpto) 
        {
            using (var db = new PROYECTOSDBEntities ())
            {
                db.Departamento.Add(dpto);
                db.SaveChanges();
            }
        } 
        public List<Departamento> ListarDepartamentos()
        {
            using (var db= new PROYECTOSDBEntities())
            {
                return db.Departamento.ToList();
            }
        }
        public Departamento GetDepartamento(int id) 
        {
            using (var db = new PROYECTOSDBEntities())
            {
                //return db.Departamento.Find;
                return db.Departamento.Where(d => d.DepartamentoId == id).FirstOrDefault();
            }
        }
        public void Editar(Departamento dpto)
        {
            using (var db = new PROYECTOSDBEntities())
            {
                var d = db.Departamento.Find(dpto.DepartamentoId);
                d.NombreDepartamento = dpto.NombreDepartamento;
                db.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            using (var db = new PROYECTOSDBEntities())
            {
                var dpto = db.Departamento.Find(id);
                db.Departamento.Remove(dpto);
                db.SaveChanges();
            }
        }
    }
}
