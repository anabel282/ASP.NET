using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    interface UsuarioRepository
    {

        IList<Usuario> getAll();

        Usuario getById(Guid codigo);

        void delete(Guid codigo);

        Usuario create(Usuario usuario);

        Usuario update(Usuario usuario);


    }
}