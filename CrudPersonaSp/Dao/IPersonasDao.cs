using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudPersonaSp.Models;

namespace CrudPersonaSp.Dao
{
    interface IPersonasDao
    {
        string Crear(Personas persona);
        string Eliminar(int idPersona);
        string Actualizar(Personas persona);
        Personas BuscarId(int id);
        Personas BuscarNombre(string nombre);
        List<Personas> Listar();
        bool Existe(int id);
        int ObtenerId();
    }
}
